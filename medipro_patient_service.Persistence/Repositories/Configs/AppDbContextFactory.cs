using medipro_patient_service.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace medipro_patient_service.Persistence.Repositories.Configs;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[]? args = null)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange:true).Build();
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        var connectionString = configuration.GetConnectionString("MediproConnection");
        if (string.IsNullOrEmpty(connectionString))
            throw new ArgumentException("Connection string is empty");
        Console.WriteLine(connectionString);
        builder.UseNpgsql(connectionString);
        return new AppDbContext(builder.Options);
    }
}