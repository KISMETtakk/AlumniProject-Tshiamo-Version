using Microsoft.EntityFrameworkCore;

namespace AlumniSpace.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Alumnus> Alumnus { get; set; }
    }
}
