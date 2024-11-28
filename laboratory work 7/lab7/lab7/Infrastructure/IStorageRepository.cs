namespace lab6.Infrastructure;

public interface IStorageRepository
{
    Task<string> UploadFileAsync(string containerName, string filePath, 
        Stream fileStream, bool isPublic = false);
    Task DeleteFileAsync(string containerName, string filePath);
    Task<Stream> DownloadFileAsync(string containerName, string filePath);
    Task<List<string>> ListFilesAsync(string containerName, string directoryPath);
    Task<bool> FileExistsAsync(string containerName, string filePath);
    Task CreateDirectoryAsync(string containerName, string directoryPath);
    Task DeleteDirectoryAsync(string containerName, string directoryPath);

}

