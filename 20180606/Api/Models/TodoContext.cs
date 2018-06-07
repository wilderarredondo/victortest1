using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class AllContext : DbContext
    {
        public AllContext(DbContextOptions<AllContext> options)
            : base(options)
        {

        }

        public DbSet<AllItem> AllItems {get; set;}
    }
}