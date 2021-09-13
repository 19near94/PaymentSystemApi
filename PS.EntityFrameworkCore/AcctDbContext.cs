using Microsoft.EntityFrameworkCore;
using PS.Domain.Entities;
using System.Threading.Tasks;

namespace PS.EntityFrameworkCore
{
    public class AcctDbContext : DbContext
    {
        public AcctDbContext(DbContextOptions<AcctDbContext> options) : base(options)
        {

        }

        public DbSet<AcctBalance> Accounts { get; set; }
        public DbSet<AcctTransaction> AccountTransaction { get; set; }

    }
}
