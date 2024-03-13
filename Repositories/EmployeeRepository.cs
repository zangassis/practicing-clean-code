using Microsoft.EntityFrameworkCore;
using PracticingCleanCode.Models;

namespace PracticingCleanCode.Repositories;

public class EmployeeRepository : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Rate> Fees { get; set; }

    public EmployeeRepository(DbContextOptions<EmployeeRepository> options) : base(options)
    {
    }
}