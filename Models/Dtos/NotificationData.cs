using PracticingCleanCode.Models;

namespace PracticigCleanCode.Models.Dtos;

public class NotificationData
{
    public List<Employee> Employees { get; set; }
    public decimal TaxRate { get; set; }
    public string NotificationText { get; set; }
    public bool IsNational { get; set; }
    public List<string> Receivers { get; set; }
}
