using PracticigCleanCode.Models;
using PracticigCleanCode.Models.Dtos;
using PracticingCleanCode.Models;
using PracticingCleanCode.Repositories;

namespace PracticingCleanCode.Services;

public class EmployeeService
{
    // Good example
    private readonly EmployeeRepository _employeeRepository;
    private readonly ILogger<EmployeeService> _logger;

    public EmployeeService(EmployeeRepository employeeRepository, ILogger<EmployeeService> logger)
    {
        _employeeRepository = employeeRepository;
        _logger = logger;
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

    public void SearchableName()
    {
        // Bad example
        int[] comp_Cod_Elegibles = { 398431, 339292, 394939, 919281, 929191, 382811 };

        // Good example
        int[] companyCodesEligibleForInvoicing = { 398431, 339292, 394939, 919281, 929191, 382811 };
    }

    // Bad example
    public void DisrespectingNamingConventions(Employee employee)
    {
        string _completeName = $"{employee.Name} {employee.Lastname}";
    }

    // Bad example
    public void ProcessNationalEmployeeVerification()
    {
        var nationalEmployees = from employee in _employeeRepository.Employees
                                join company in _employeeRepository.Companies on employee.CompanyId equals company.Id
                                where company.National
                                select new
                                {
                                    EmployeeId = employee.Id,
                                    EmployeeName = employee.Name,
                                    EmployeeLastname = employee.Lastname,
                                    EmployeePaycheck = employee.Paycheck,
                                    CompanyName = company.Name
                                };

        var nonNationalEmployees = from employee in _employeeRepository.Employees
                                   join company in _employeeRepository.Companies on employee.CompanyId equals company.Id
                                   where company.National == false
                                   select new
                                   {
                                       EmployeeId = employee.Id,
                                       EmployeeName = employee.Name,
                                       EmployeeLastname = employee.Lastname,
                                       EmployeePaycheck = employee.Paycheck,
                                       CompanyName = company.Name
                                   };

        var rates = new List<Rate>();
        var notifications = new List<Notification>();

        foreach (var nationalEmployee in nationalEmployees)
        {
            decimal totalRateAmount = nationalEmployee.EmployeePaycheck * (decimal)TaxRates.NationalEmployee / 100;

            rates.Add(new Rate(Guid.NewGuid(), totalRateAmount, nationalEmployee.EmployeeId, false));

            notifications.Add(new Notification()
            {
                Id = Guid.NewGuid(),
                EmployeeName = nationalEmployee.EmployeeName,
                NotificationType = NotificationType.RatesRegistration
            });
        }

        foreach (var nonNationalEmployee in nonNationalEmployees)
        {
            decimal totalRateAmount = nonNationalEmployee.EmployeePaycheck * (decimal)TaxRates.NonNationalEmployee / 100;

            rates.Add(new Rate(Guid.NewGuid(), totalRateAmount, nonNationalEmployee.EmployeeId, false));

            notifications.Add(new Notification()
            {
                Id = Guid.NewGuid(),
                EmployeeName = nonNationalEmployee.EmployeeName,
                NotificationType = NotificationType.RatesRegistration
            });
        }

        _employeeRepository.Notifications.AddRange(notifications);
        _employeeRepository.SaveChanges();
    }

    // Good example
    public void ProcessEmployee()
    {
        ProcessEmployeeRates();

        ProcessNotification();

        _employeeRepository.SaveChanges();
    }

    public void ProcessEmployeeRates()
    {
        var nationalEmployees = GetEmployeesByNationality(true).ToList();
        var nonNationalEmployees = GetEmployeesByNationality(false).ToList();

        CalculateEmployeesRates(nationalEmployees, true);
        CalculateEmployeesRates(nonNationalEmployees, false);
    }

    private IQueryable<Employee> GetEmployeesByNationality(bool isNational)
    {
        return from employee in _employeeRepository.Employees
               join company in _employeeRepository.Companies on employee.CompanyId equals company.Id
               where company.National == isNational
               select employee;
    }

    private void CalculateEmployeesRates(IEnumerable<Employee> employees, bool isNational)
    {
        decimal taxRate = isNational ? (decimal)TaxRates.NationalEmployee : (decimal)TaxRates.NonNationalEmployee;
        var rates = new List<Rate>();

        foreach (var employee in employees)
        {
            decimal totalRateAmount = CalculateRateAmount(taxRate, employee);

            rates.Add(new Rate(Guid.NewGuid(), totalRateAmount, employee.Id, false));
        }
    }

    private decimal CalculateRateAmount(decimal taxRate, Employee employee)
    {
        return employee.Paycheck * taxRate / 100;
    }

    private void ProcessNotification()
    {
        var notifications = _employeeRepository.Employees
           .Select(employee => new Notification()
           {
               Id = Guid.NewGuid(),
               EmployeeName = employee.Name,
               NotificationType = NotificationType.RatesRegistration
           })
           .ToList();

        _employeeRepository.Notifications.AddRange(notifications);
    }

    // Bad example
    public void ProcessAbsenteeismNotification(List<Employee> employeesWithAbsenteeism, decimal taxRate, string notificationText, bool isNational, List<string> receivers)
    {
        //...rest of the code
    }

    // Good example
    public void ProcessAbsenteeismNotification(NotificationData data)
    {
        List<Employee> employeesWithAbsenteeism = data.Employees;
        decimal taxRate = data.TaxRate;
        string notificationText = data.NotificationText;
        bool isNational = data.IsNational;
        List<string> receivers = data.Receivers;

        //...rest of the code
    }

    // Bad example
    public void UpdateEmployeeStatus(Employee employee)
    {
        if (employee.Absences >= 3)
        {
            employee.Status = (int)EmployeeStatus.OnLeave;
        }
        else
        {
            employee.Status = (int)EmployeeStatus.Active;
        }

        _employeeRepository.Update(employee);
        _employeeRepository.SaveChanges();
    }


    // Good example
    public void UpdateEmployeeStatusClean(Employee employee)
    {
        employee.Status = (int)GetEmployeeStatus(employee.Absences);
    }

    public EmployeeStatus GetEmployeeStatus(int absenteeismCount)
    {
        if (absenteeismCount >= 3)
        {
            return EmployeeStatus.OnLeave;
        }
        else
        {
            return EmployeeStatus.Active;
        }
    }

    // Bad example
    // This method calculates an employee's salary deduction based on their category
    // TODO refactor this method later
    public decimal CalculateSalaryDiscount(Employee employee)
    {
        // TODO this variable is for testing only, remember to remove it
        int[] arrayTest = { 1, 4, 39, 44, 93, 203 };

        decimal discount = 0;

        if (employee.Category == 3)
        {
            // Category 3 has a 10% discount for salaries above $1000            
            discount = employee.Salary * 0.1m;
        }
        else if (employee.Category == 2)
        {
            // Category 2 has a fixed discount of $200
            discount = 200;
        }
        else if (employee.Category == 1)
        {
            // Category 1 has a fixed discount of $100
            discount = 100;
        }
        else
        {
            // Other categories do not have a discount
            discount = 0;
        }

        return discount;
    }

    // Good Example
    public decimal CalculateSalaryDiscountClean(Employee employee)
    {
        decimal discount = 0;
        const decimal tenPercentDiscountRate = 0.1m;

        switch (employee.Category)
        {
            case (int)EmployeeCategory.Senior:
                discount = employee.Salary * tenPercentDiscountRate;
                break;
            case (int)EmployeeCategory.MidLevel:
                discount = 200;
                break;
            case (int)EmployeeCategory.Junior:
                discount = 100;
                break;
            default:
                break;
        }
        return discount;
    }

    // Bad example
    public void CalculateEmployeeSalaries(List<Employee> employees, Company company)
    {
        try
        {

            foreach (var employee in employees)
            {
                decimal totalSalary = 0;

                if (employee.Status == (int)EmployeeStatus.Active)
                {
                    for (int i = 0; i < employee.MonthsWorked; i++) { totalSalary += employee.Salary; }
                    if (employee.Absences > 0)
                    {
                        totalSalary -= (employee.Salary / 30)
                        * employee.Absences;
                    }


                    if (employee.Category == (int)EmployeeCategory.Junior)
                    {
                        totalSalary += (totalSalary * 0.1m);
                    }



                    if (company.National)
                    {
                        totalSalary += 1000;
                    }
                    employee.Salary = totalSalary;


                }
            }

        }
        catch (Exception ex)
        {

            _logger.LogError(ex.Message, "Error when calculating employee salaries");
        }
    }

    // Good example
    public void CalculateEmployeeSalariesBetter(List<Employee> employees, Company company)
    {
        try
        {
            foreach (var employee in employees)
            {
                if (employee.Status == (int)EmployeeStatus.Active)
                {
                    decimal totalSalary = 0;

                    for (int i = 0; i < employee.MonthsWorked; i++)
                    {
                        totalSalary += employee.Salary;
                    }

                    if (employee.Absences > 0)
                    {
                        totalSalary -= (employee.Salary / 30) * employee.Absences;
                    }

                    if (employee.Category == (int)EmployeeCategory.Junior)
                    {
                        totalSalary += (totalSalary * 0.1m);
                    }

                    if (company.National)
                    {
                        totalSalary += 1000;
                    }

                    employee.Salary = totalSalary;
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, "Error when calculating employee salaries");
        }
    }

    private void SendNotification(List<Employee> employees)
    {
        var notifications = new List<Notification>();

        try
        {
            foreach (var employee in employees)

            {
                var notification = new Notification(Guid.NewGuid(), employee.Name, NotificationType.Payment);
                notifications.Add(notification);
            }

            _employeeRepository.Notifications.AddRange(notifications);
        }
        catch (Exception ex)
        {

            _logger.LogError(ex.Message, "Error sending notification");
        }
    }

}