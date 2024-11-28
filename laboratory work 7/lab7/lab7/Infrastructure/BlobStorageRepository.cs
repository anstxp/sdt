using System.Text;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace lab6.Infrastructure;

public class BlobStorageRepository : IStorageRepository
{
    private readonly BlobServiceClient _blobServiceClient;

    public BlobStorageRepository(IConfiguration configuration)
    {
        var connectionString = configuration["AzureBlobStorage:ConnectionString"];
        _blobServiceClient = new BlobServiceClient(connectionString);
    }

    public async Task<string> UploadFileAsync(string containerName, string filePath, 
        Stream fileStream, bool isPublic = false)
    {
        var container = _blobServiceClient.GetBlobContainerClient(containerName);
        var blob = container.GetBlobClient(filePath);

        await blob.UploadAsync(fileStream, overwrite: true);

        if (isPublic)
        {
            await container.SetAccessPolicyAsync(PublicAccessType.Blob);
        }

        return blob.Uri.ToString();
    }

    public async Task DeleteFileAsync(string containerName, string filePath)
    {
        var container = _blobServiceClient.GetBlobContainerClient(containerName);
        var blob = container.GetBlobClient(filePath);
        await blob.DeleteIfExistsAsync();
    }

    public async Task<Stream> DownloadFileAsync(string containerName, string filePath)
    {
        var container = _blobServiceClient.GetBlobContainerClient(containerName);
        var blob = container.GetBlobClient(filePath);

        var stream = new MemoryStream();
        await blob.DownloadToAsync(stream);
        stream.Position = 0;
        return stream;
    }

    public async Task<List<string>> ListFilesAsync(string containerName, string directoryPath)
    {
        var container = _blobServiceClient.GetBlobContainerClient(containerName);
        var blobs = container.GetBlobsAsync(prefix: directoryPath);

        var fileList = new List<string>();
        await foreach (var blob in blobs)
        {
            fileList.Add(blob.Name);
        }

        return fileList;
    }

    public async Task<bool> FileExistsAsync(string containerName, string filePath)
    {
        var container = _blobServiceClient.GetBlobContainerClient(containerName);
        var blob = container.GetBlobClient(filePath);
        return await blob.ExistsAsync(); 
    }
    
    public async Task CreateDirectoryAsync(string containerName, string directoryPath)
    {
        var container = _blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = container.GetBlobClient($"{directoryPath}/placeholder");
        await blobClient.UploadAsync(new MemoryStream(Encoding.UTF8.GetBytes("placeholder")), overwrite: true);
    }
    
    public async Task DeleteDirectoryAsync(string containerName, string directoryPath)
    {
        var container = _blobServiceClient.GetBlobContainerClient(containerName);
        var blobs = container.GetBlobsAsync(prefix: directoryPath);

        await foreach (var blob in blobs)
        {
            var blobClient = container.GetBlobClient(blob.Name);
            await blobClient.DeleteIfExistsAsync();
        }
    }
}
