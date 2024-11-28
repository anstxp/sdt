using lab6.Data;
using lab6.Infrastructure;
using lab6.Models.Domain.Files;
using lab6.Models.DTO.FilesDTO;
using lab6.Repositories.Interfaces;
using lab6.Repositories.Interfaces.IFileRepositories;
using lab6.Services.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace lab6.Services.Implementations;

public class FileService : IFileService
{
    private readonly IStorageRepository _blobStorageRepository;
    private readonly IReportFileRepository _reportFileRepository;
    private readonly ITaskFileRepository _taskFileRepository;
    private readonly IUserProfileImageRepository _userProfileImageRepository;

    public FileService(
        IStorageRepository blobStorageRepository,
        IReportFileRepository reportFileRepository,
        ITaskFileRepository taskFileRepository,
        IUserProfileImageRepository userProfileImageRepository)
    {
        _blobStorageRepository = blobStorageRepository;
        _reportFileRepository = reportFileRepository;
        _taskFileRepository = taskFileRepository;
        _userProfileImageRepository = userProfileImageRepository;
    }
    
    public async Task<string> UploadFileAsync(Stream fileStream, string filePath, bool isPublic) 
    {
        return await _blobStorageRepository.UploadFileAsync("main-container", filePath, fileStream);
    }
    
    public async Task DeleteFileAsync(string filePath)
    {
        await _blobStorageRepository.DeleteFileAsync("main-container", filePath);
    }
    
    public async Task<Stream> DownloadFileAsync(string filePath)
    {
        return await _blobStorageRepository.DownloadFileAsync("main-container", filePath);
    }
    
        public async Task<string> GetLatestVersionPathAsync(string projectId, string taskId, string fileName)
    {
        var versions = await _blobStorageRepository.ListFilesAsync("main-container", 
            $"projects/{projectId}/tasks/{taskId}");
        var latestVersion = versions
            .Where(v => v.Contains(fileName))
            .OrderByDescending(v => v)
            .FirstOrDefault();

        return latestVersion;
    }
    
    public async Task<UserProfileImage> UploadProfileImageAsync(UserProfileImageDTO profileImageDTO)
    {
        var existingProfileImage = await _userProfileImageRepository.
            GetProfileImageByUserIdAsync(profileImageDTO.UserId);
        if (existingProfileImage != null)
        {
            await DeleteFileAsync(existingProfileImage.FileUrl);
        }
        
        var compressedImageStream = await CompressImageAsync(profileImageDTO.FileStream);

        var fileUrl = await UploadFileAsync(compressedImageStream, 
            $"users/{profileImageDTO.UserId}/profile/{profileImageDTO.FileName}", profileImageDTO.IsPublic);

        var userProfileImage = new UserProfileImage
        {
            FileName = profileImageDTO.FileName,
            FileExtension = profileImageDTO.FileExtension,
            FileSizeInBytes = compressedImageStream.Length,
            FileUrl = fileUrl,
            UploadedByUserId = profileImageDTO.UploadedByUserId,
            UploadedAt = DateTime.UtcNow,
            IsPublic = profileImageDTO.IsPublic,
            UserId = profileImageDTO.UserId
        };

        await _userProfileImageRepository.ReplaceProfileImageAsync(userProfileImage);
        return userProfileImage;
    }
    
    public async Task<ReportFile> UploadReportAsync(ReportFileDTO reportFileDTO)
    {
        var fileUrl = await UploadFileAsync(reportFileDTO.FileStream, 
            $"projects/{reportFileDTO.ProjectId}/reports/{reportFileDTO.FileName}", reportFileDTO.IsPublic);

        var reportFile = new ReportFile
        {
            FileName = reportFileDTO.FileName,
            FileExtension = reportFileDTO.FileExtension,
            FileSizeInBytes = reportFileDTO.FileStream.Length,
            FileUrl = fileUrl,
            UploadedByUserId = reportFileDTO.UploadedByUserId,
            UploadedAt = DateTime.UtcNow,
            IsPublic = reportFileDTO.IsPublic,
            Description = reportFileDTO.Description,
            ProjectId = reportFileDTO.ProjectId,
            ReportId = reportFileDTO.ReportId
        };

        await _reportFileRepository.AddAsync(reportFile);
        return reportFile;
    }
    
    public async Task<TaskFile> UploadTaskFileAsync(TaskFileDTO taskFileDTO)
    {
        var filePath = $"projects/{taskFileDTO.ProjectId}/tasks/{taskFileDTO.TaskId}/v{taskFileDTO.VersionNumber}/" +
                       $"{taskFileDTO.FileName}";
        var fileUrl = await UploadFileAsync(taskFileDTO.FileStream, filePath, taskFileDTO.IsPublic);

        var taskFile = new TaskFile
        {
            FileName = taskFileDTO.FileName,
            FileExtension = taskFileDTO.FileExtension,
            FileSizeInBytes = taskFileDTO.FileStream.Length,
            FileUrl = fileUrl,
            UploadedByUserId = taskFileDTO.UploadedByUserId,
            UploadedAt = DateTime.UtcNow,
            IsPublic = taskFileDTO.IsPublic,
            TaskId = taskFileDTO.TaskId,
            ProjectId = taskFileDTO.ProjectId,
            VersionNumber = taskFileDTO.VersionNumber,
            PreviousVersionId = taskFileDTO.PreviousVersionId
        };

        await _taskFileRepository.AddAsync(taskFile);
        return taskFile;
    }

    
    public async Task<Stream> CompressImageAsync(Stream originalStream)
    {
        using var image = Image.Load(originalStream);
        var compressedStream = new MemoryStream();

        image.Mutate(x => x.Resize(new ResizeOptions
        {
            Mode = ResizeMode.Max,
            Size = new Size(800, 800)
        }));
        
        image.Save(compressedStream, new JpegEncoder { Quality = 85 });
        compressedStream.Position = 0;
        
        return compressedStream;
    }
}
