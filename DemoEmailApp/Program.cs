using DemoEmailApp.AppDataBase;
using DemoEmailApp.EmailService;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;

namespace DemoEmailApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            var emailConfig = builder.Configuration
        .GetSection("EmailConfiguration")
        .Get<EmailConfiguration>();
            builder.Services.AddSingleton(emailConfig);


            builder.Services

               .AddDbContext<DataContext>(o =>
               {
                   o.UseSqlServer("Server=DESKTOP-466PC0V;Database=DataEmail;Trusted_Connection=True;TrustServerCertificate=True;");
               }, ServiceLifetime.Scoped)
                .AddScoped<IEmailSender, EmailSender>()

                .AddMvc();


            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Email}/{action=List}");

            app.Run();








        }
    }
}