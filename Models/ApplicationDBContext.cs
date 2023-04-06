using Microsoft.EntityFrameworkCore;

namespace AppTwelve.Models
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options){
            
        }
        public DbSet<Shares> Shares { get; set; }
    }
}
