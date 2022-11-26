using DemoEmailApp.AppDataBase;
using Microsoft.EntityFrameworkCore;

namespace DemoEmailApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services

                .AddDbContext<DataContext>(o =>
                 {
                     o.UseSqlServer("Server=DESKTOP-466PC0V;Database=DataEmail;Trusted_Connection=True;TrustServerCertificate=True;");
                 }, ServiceLifetime.Transient)
                //.AddScoped<IEmailService, SMTP>()
                //.AddScoped<IEmployeeService, EmployeeService>()
                .AddMvc();

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=home}/{action=index}");

            app.Run();
        }
    }
}