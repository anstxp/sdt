using System.Text.Json;
using DotlyApi.Models.Domain;
using DotlyApi.Models.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotlyApi.Data;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }
    
    public DbSet<AppUser> AppUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data
        var roles = new List<AppRole>
        {
            new AppRole
            {
                Id = Guid.Parse("4DA819B8-8CF0-4469-913F-D468B2D8E8CC"),
                ConcurrencyStamp = "4DA819B8-8CF0-4469-913F-D468B2D8E8CC",
                Name = "user",
                NormalizedName = "USER"
            },
            new AppRole
            {
                Id = Guid.Parse("938976C5-B4D3-4537-9B70-D97406608370"),
                ConcurrencyStamp = "938976C5-B4D3-4537-9B70-D97406608370",
                Name = "admin",
                NormalizedName = "ADMIN"
            }
        };

        modelBuilder.Entity<AppRole>().HasData(roles);
    }
}

