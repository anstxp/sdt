using System.Text.Json;
using DotlyApi.Models.Domain;
using DotlyApi.Models.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace DotlyApi.Data;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<BaseProject> Projects { get; set; }
    public DbSet<BaseTask> Tasks { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TeamMember> TeamMembers { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(t => t.TeamId);


            entity
                .HasOne(t => t.Project)
                .WithMany(p => p.Teams)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasOne(t => t.TeamLead)
                .WithMany()
                .HasForeignKey(t => t.TeamLeadId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<BaseTask>(entity =>
        {
            entity.HasKey(t => t.TaskId);

            entity
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasOne(t => t.Team)
                .WithMany(team => team.Tasks)
                .HasForeignKey(t => t.TeamId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Team>()
                .HasMany(t => t.TeamMembers)
                .WithOne(tm => tm.Team)
                .HasForeignKey(tm => tm.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TeamMember>()
                .HasOne(tm => tm.User)
                .WithMany()
                .HasForeignKey(tm => tm.UserId)
                .OnDelete(DeleteBehavior.Restrict);

        });
    }
}

