using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class AllContext : DbContext
    {
        public DbSet<AllItem> AllItems { get; set; }

        public AllContext(DbContextOptions<AllContext> options): base(options)
        {

        }
    }
}