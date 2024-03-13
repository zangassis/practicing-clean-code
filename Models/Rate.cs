namespace PracticingCleanCode.Models;

public class Rate
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public Guid EmployeeId { get; set; }
    public DateTime PaymentDate { get; set; }
    public bool PaidInFull { get; set; }

    public Rate(Guid id, decimal amount, Guid employeeId, bool paidInFull)
    {
        Id = id;
        Amount = amount;
        EmployeeId = employeeId;
        PaidInFull = paidInFull;
    }
}