using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace PassON.Models
{
    public class PassONDbContext:DbContext
    {
        public PassONDbContext(DbContextOptions<PassONDbContext> options) : base(options)
        {

        }

        
        public DbSet<Category> Categories { get; set; }

        public DbSet<Item> Items { get; set; }



    }
}
