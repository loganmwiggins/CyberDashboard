using System;

namespace CyberDashboardProj
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register our DbContext for dependency injection
            //builder.Services.AddDbContext<AppDbContext>(options =>
            //{
            //    // Read connection string from appsettings.json
            //    options.UseNpgsql(builder.Configuration.GetConnectionString("AppDbContext"));
            //});

            var app = builder.Build();

            // Create a scope to get the service provider and run the SeedData.Initialize service
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}