using lab2.Repository.Interfaces;
using File = lab2.Models.Domain.File;

namespace lab2.Repository.Implementation;

public class FileRepository : IFileRepository
{
    public void Add(File file)
    {
        // Логіка додавання файлу
    }

    public File GetById(int fileId)
    {
        // Логіка отримання файлу за ідентифікатором
        return null;
    }

    public IEnumerable<File> GetAll()
    {
        // Логіка отримання всіх файлів
        return new List<File>();
    }

    public void Update(File file)
    {
        // Логіка оновлення файлу
    }

    public void Delete(int fileId)
    {
        // Логіка видалення файлу
    }
}
