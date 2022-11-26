using Microsoft.EntityFrameworkCore;

namespace DemoEmailApp.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
            
        {

        }

    }
}
