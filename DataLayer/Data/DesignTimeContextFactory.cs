using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer.Data;

/// <summary>
/// Factory to produce an instance of the DB context when using EF's command line tools
/// </summary>
public class DesignTimeContextFactory
    : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        if (args.Length < 1)
        {
            throw new InvalidOperationException("Missing required argument: connectionString");
        }

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(args[0]);

        return new AppDbContext(optionsBuilder.Options);
    }
}
