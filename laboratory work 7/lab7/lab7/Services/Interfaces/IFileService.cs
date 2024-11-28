using lab7.Models.Domain.Files;
using lab7.Models.DTO.FilesDTO;

namespace lab7.Services.Interfaces;

public interface IFileService
{
    Task<string> UploadFileAsync(Stream fileStream, string filePath, bool isPublic);
    Task DeleteFileAsync(string filePath);
    Task<Stream> DownloadFileAsync(string filePath);
    Task<string> GetLatestVersionPathAsync(string projectId, string taskId, string fileName);
    Task<Stream> CompressImageAsync(Stream originalStream);
    Task<UserProfileImage> UploadProfileImageAsync(UserProfileImageDTO profileImageDTO);
    Task<ReportFile> UploadReportAsync(ReportFileDTO reportFileDTO);
    Task<TaskFile> UploadTaskFileAsync(TaskFileDTO taskFileDTO);

}
