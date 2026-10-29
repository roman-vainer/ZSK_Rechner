using Microsoft.EntityFrameworkCore;
namespace ZSK_Rechner.Models
{
    public class ZSKDBContext : DbContext
    {
        public ZSKDBContext(DbContextOptions<ZSKDBContext> options) : base(options) { }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
    }
}
