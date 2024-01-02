
using Kitaplik.Models;
using Microsoft.EntityFrameworkCore;

namespace Kitaplik.DataAccess.Data
{
    public class AplicationDbContext:DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }

        
    }
}
