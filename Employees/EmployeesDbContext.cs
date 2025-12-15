using Employees.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employees;

public class EmployeesDbContext : DbContext
{
    private string _connectionString = "Server=localhost;Database=Employees;user=superadmin;password=superadmin;";
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Job> Jobs { get; set; }
    

    override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(_connectionString,  ServerVersion.AutoDetect(_connectionString));
    }
}