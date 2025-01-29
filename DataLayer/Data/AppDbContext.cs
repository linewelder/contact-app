using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Data;

/// <summary>
/// Database context for the app
/// </summary>
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<ContactGroup> ContactGroups { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
}
