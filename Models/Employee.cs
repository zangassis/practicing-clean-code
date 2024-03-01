namespace PracticingCleanCode.Models;

public class Employee
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Lastname { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public int MonthsWorked { get; set; }
    public int Absences { get; set;}
    public decimal Paycheck { get; set; }
}