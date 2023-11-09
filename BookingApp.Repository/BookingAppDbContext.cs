using BookingApp.DTO;
using BookingApp.DTO.Services;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Repository;

public class BookingAppDbContext : DbContext
{
    public BookingAppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Salon> Salons { get; set; }
    public DbSet<Spa> Spas { get; set; }
}