using lab2.Models.Domain;

namespace lab2.Repository.Interfaces;

public interface IReportRepository
{
    void Add(Report report);
    Report GetById(int reportId);
    IEnumerable<Report> GetAll();
    void Update(Report report);
    void Delete(int reportId);
}