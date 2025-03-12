using Microsoft.EntityFrameworkCore;
using TestProjectKyzmat.Core.Entities;
using TestProjectKyzmat.Core.Entities.Common.Interfaces;

namespace TestProjectKyzmat.DAL
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(o => o.UserName);         
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "user",
                    DateCreate = new DateTime(2025, 3, 10, 15, 45, 23, DateTimeKind.Utc),
                    PasswordHash = "$2a$11$ilZsBJ46DXogvezFCtbWN.WHMtdSqL9IEvBaR73Ge6jxMVh1/3.ku", // password: qwerty12345 
                    Balance = 8m
                });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<IDateFixEntity>()) 
            {
                entry.Entity.DateCreate = entry.State switch
                {
                    EntityState.Added => DateTime.UtcNow,
                    _ => entry.Entity.DateCreate,
                };
                entry.Entity.DateUpdate = entry.State switch
                {
                    EntityState.Modified => DateTime.UtcNow,
                    _ => entry.Entity.DateUpdate,
                };
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
