using System.Security.Cryptography.X509Certificates;
namespace PracticingCleanCode.Models;

public class Employee
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Lastname { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public int MonthsWorked { get; set; }
    public int Absences { get; set; }
    public decimal Paycheck { get; set; }
    public Guid CompanyId { get; set; }
    public int Status { get; set; }
    public int Category { get; internal set; }
    public decimal Salary { get; internal set; }

    public virtual void Work()
    {
        Console.WriteLine($"{Name} is performing general work.");
    }

    private readonly IEmployeeBehavior behavior;

    public Employee(IEmployeeBehavior behavior)
    {
        this.behavior = behavior;
    }

    public void PerformWork()
    {
        behavior.Work();
    }
}