namespace lab2.Repository.Interfaces;

public interface IVersionRepository
{
    void Add(Version version);
    Version GetById(int versionId);
    IEnumerable<Version> GetAll();
    void Update(Version version);
    void Delete(int versionId);
}