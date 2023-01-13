namespace RoyalLib.Infra.EntityFramework;

using Microsoft.EntityFrameworkCore;
using RoyalLib.Domain.Entities;
using RoyalLib.Infra.EntityFramework.Mappings;
using System.Reflection.Emit;


#nullable disable
public class RoyalLibContext : DbContext
{
    // This constructor is used on migrations
    public RoyalLibContext()
    {
    }

    // This constructor is used on web
    public RoyalLibContext(DbContextOptions<RoyalLibContext> options)
        : base(options) { }

    public DbSet<BookEntity> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // This options is not configured on migration flow
        if (!optionsBuilder.IsConfigured)
        {
            // Migrations Config:
            optionsBuilder.UseSqlServer();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookMap());
    }
}
