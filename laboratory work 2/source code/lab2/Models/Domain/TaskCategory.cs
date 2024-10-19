namespace lab2.Models.Domain;

public class TaskCategory
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }

    public ICollection<Task> Tasks { get; set; }

}