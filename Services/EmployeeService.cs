using PracticingCleanCode.Models;
using PracticingCleanCode.Repositories;

namespace PracticingCleanCode.Services;

public class EmployeeService
{
    private readonly EmployeeRepository _employeeRepository;

    public EmployeeService(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    // Bad example
    public void SendNotification()
    {
        List<Notification> eligibleEmployees = GetElegibleEmplyees();

        _employeeRepository.Notifications.AddRange(eligibleEmployees);
        _employeeRepository.SaveChanges();
    }

    // Good Example
    public void SendVacationNotificationToEligibleEmployees()
    {
        List<Notification> eligibleEmployees = GetElegibleEmplyees();

        _employeeRepository.Notifications.AddRange(eligibleEmployees);
        _employeeRepository.SaveChanges();
    }

    private List<Notification> GetElegibleEmplyees()
    {
        return _employeeRepository.Employees
                .Where(e => e.MonthsWorked == 12)
                .Select(employee => new Notification(Guid.NewGuid(), $"{employee.Name} {employee.Lastname}"))
                .ToList();
    }

    // Bad example
    public decimal CalculateAbsenceDiscount(decimal a, int p)
    {
        if (a != 0) 
        {
            int days = DateTime.DaysInMonth(DateTime.Today.Month, DateTime.Today.Year);

            return p / days * p;
        }
        return 0;
    }

    // Good Example
    public decimal CalculateAbsenceDiscountBetter(decimal absences, int paycheck)
    {
        if (absences != 0)
        {
            int totalDaysOfMonth = DateTime.DaysInMonth(DateTime.Today.Month, DateTime.Today.Year);

            return paycheck / totalDaysOfMonth * absences;
        }
        return 0;
    }
}