using BookingApp.DTO;
using BookingApp.DTO.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Repository;

public class BookingAppDbContext : IdentityDbContext
{
    public BookingAppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Salon> Salons { get; set; }
    public DbSet<Spa> Spas { get; set; }
    public DbSet<Post> Posts { get; set; }
}