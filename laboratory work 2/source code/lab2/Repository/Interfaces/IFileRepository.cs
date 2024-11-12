namespace lab2.Repository.Interfaces;
using lab2.Models.Domain;

public interface IFileRepository
{
    void Add(File file);
    File GetById(int fileId);
    IEnumerable<File> GetAll();
    void Update(File file);
    void Delete(int fileId);
}