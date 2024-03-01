namespace PracticingCleanCode.Models;

public class Notification
{
    public Guid Id { get; set; }
    public string? EmployeeName { get; set; }

    public Notification(Guid id, string employeeName)
    {
        Id = id;
        EmployeeName = employeeName;
    }
}