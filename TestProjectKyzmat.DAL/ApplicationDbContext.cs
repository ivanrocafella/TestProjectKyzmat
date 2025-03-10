using Microsoft.EntityFrameworkCore;
using TestProjectKyzmat.Core.Entities;
using TestProjectKyzmat.Core.Entities.Common.Interfaces;

namespace TestProjectKyzmat.DAL
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<IDateFixEntity>()) 
            {
                entry.Entity.Date
            }
        }
    }
}
