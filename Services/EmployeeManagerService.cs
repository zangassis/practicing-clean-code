using PracticingCleanCode.Models;

public class EmployeeManagerService
{
    public void RegisterNewEmployee()
    {
        //Rest of the code...
    }

    public void UpdateEmployee()
    {
        //Rest of the code...
    }

    public void DeleteEmployee()
    {
        //Rest of the code...
    }

    public void SendVacationNotificationToEligibleEmployees()
    {
        //Rest of the code...
    }

    private List<Notification> GetElegibleEmplyees()
    {
        //Rest of the code...
    }

    public decimal CalculateAbsenceDiscount(decimal absences, int paycheck)
    {
        //Rest of the code...
    }

    public void ProcessEmployeeRates()
    {
        //Rest of the code...
    }

    private IQueryable<Employee> GetEmployeesByNationality(bool isNational)
    {
        //Rest of the code...
    }

    private void CalculateEmployeesRates(IEnumerable<Employee> employees, bool isNational)
    {
        //Rest of the code...
    }

    private void SendNotification(List<Employee> employees)
    {
        //Rest of the code...
    }
}