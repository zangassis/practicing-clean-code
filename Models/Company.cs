namespace PracticingCleanCode.Models;

public class Company
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? ContactNumber { get; set; }
    public bool National { get; set; }
}