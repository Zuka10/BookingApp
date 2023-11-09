using BookingApp.Facade;
using BookingApp.Facade.Repositories;
using BookingApp.Repository;
using BookingApp.Service;
using Microsoft.EntityFrameworkCore;

namespace BookingApp;

public static class Startup
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews();
        services.AddMvc();
        services.AddDbContext<BookingAppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("MSSQLTest")));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICustomerService, CustomerService>();
    }

    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}