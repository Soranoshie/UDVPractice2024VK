using Microsoft.EntityFrameworkCore;
using UDVPractice2024VK.DAL.Entities;
using UDVPractice2024VK.Infrastructure;

namespace UDVPractice2024VK.DAL;

public class ApplicationDbContext : DbContext
{
    public DbSet<LetterDictionaryDTO> LetterDictionary { get; set; }
    private readonly Config config;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, Config config) : base(options)
    {
        this.config = config;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseNpgsql(config.DatabaseConnectionString,
                builder => { builder.
                    EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null); });
        base.OnConfiguring(optionsBuilder);
    }
}