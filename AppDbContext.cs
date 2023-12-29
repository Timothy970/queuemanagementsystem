using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<ServicePoint> ServicePoints { get; set; }
    public DbSet<ServiceProvider> ServiceProviders { get; set; }

    // Add your DbSet properties and other configurations here
}

public class ServicePoint
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class ServiceProvider : IdentityUser
{
    [Key]
    public new int Id { get; set; }
    public string? ServiceProviderName { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }

}