using lab2.Models.Domain;
using lab2.Repository.Interfaces;

namespace lab2.Repository.Implementation;

public class ReportRepository : IReportRepository
{
    public void Add(Report report)
    {
        // Логіка додавання звіту
    }

    public Report GetById(int reportId)
    {
        // Логіка отримання звіту за ідентифікатором
        return null;
    }

    public IEnumerable<Report> GetAll()
    {
        // Логіка отримання всіх звітів
        return new List<Report>();
    }

    public void Update(Report report)
    {
        // Логіка оновлення звіту
    }

    public void Delete(int reportId)
    {
        // Логіка видалення звіту
    }
}
