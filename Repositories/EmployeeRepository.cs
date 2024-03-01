using Microsoft.EntityFrameworkCore;
using PracticingCleanCode.Models;

namespace PracticingCleanCode.Repositories;

public class EmployeeRepository : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    public EmployeeRepository(DbContextOptions<EmployeeRepository> options) : base(options)
    {
    }
}