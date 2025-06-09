using Microsoft.EntityFrameworkCore;
using APBD_TEST2d.Models;

namespace APBD_TEST2d.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Player> Players => Set<Player>();
    public DbSet<Match> Matches => Set<Match>();
    public DbSet<Map> Maps => Set<Map>();
    public DbSet<Tournament> Tournaments => Set<Tournament>();
    public DbSet<PlayerMatch> PlayerMatches => Set<PlayerMatch>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerMatch>()
            .HasKey(pm => new { pm.PlayerId, pm.MatchId });

        modelBuilder.Entity<PlayerMatch>()
            .HasOne(pm => pm.Player)
            .WithMany(p => p.PlayerMatches)
            .HasForeignKey(pm => pm.PlayerId);

        modelBuilder.Entity<PlayerMatch>()
            .HasOne(pm => pm.Match)
            .WithMany(m => m.PlayerMatches)
            .HasForeignKey(pm => pm.MatchId);
    }
}
