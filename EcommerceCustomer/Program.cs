using EcommerceCustomer.Data;
using EcommerceCustomer.Services;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Register DbContext with SQL Server
        builder.Services.AddDbContext<EcommerceDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddHttpClient<CategoryService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5000");
        });
        builder.Services.AddScoped<CategoryService>();  // Add your service here

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}