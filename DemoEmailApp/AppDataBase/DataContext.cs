using DemoEmailApp.Database;
using DemoEmailApp.Notifications.Model;

using Microsoft.EntityFrameworkCore;

namespace DemoEmailApp.AppDataBase
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
            
        {

        }
            
       public DbSet<Email> Emails { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
