using EM.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EM.Infrastructure.Data;

public class ApplicationDbContext
    (DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>()
            .HasOne(e => e.Team)
            .WithMany(e => e.Members)
            .HasForeignKey(e => e.TeamId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Team>();
    }
}