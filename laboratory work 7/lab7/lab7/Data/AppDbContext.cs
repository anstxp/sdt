using lab7.Models;
using lab7.Models.Domain;
using lab7.Models.Domain.Files;
using lab7.Models.Domain.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Version = System.Version;

namespace lab7.Data
{

    public class AppDbContext: IdentityDbContext<AppUser, AppRole, Guid>
    {

        public AppDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }
        
        public DbSet<Project?> Projects { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }
        public DbSet<ReportFile> Reports { get; set; }
        public DbSet<TaskFile> TaskFiles { get; set; }
        public DbSet<UserProfileImage> UserProfileImages { get; set; }
        public DbSet<Version> Versions { get; set; }
        
        public DbSet<Team> Teams { get; set; }
        public DbSet<Methodology> Methodologies { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        
            // Додавання методологій в базу при першому запуску
            modelBuilder.Entity<Methodology>().HasData(
                new Methodology { MethodologyId = Guid.NewGuid(), Name = "Scrum" },
                new Methodology { MethodologyId = Guid.NewGuid(), Name = "Kanban" }
            );
        }
    }
}