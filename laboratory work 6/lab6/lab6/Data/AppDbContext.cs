using lab6.Models;
using lab6.Models.Domain;
using lab6.Models.Domain.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain_IdentityEntities_UserRole = lab6.Models.Domain.IdentityEntities.UserRole;
using Models_Domain_File = lab6.Models.Domain.File;

namespace lab6.Data
{

    public class AppDbContext: IdentityDbContext<AppUser, Domain_IdentityEntities_UserRole, Guid>
    {

        public AppDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }
        
        public DbSet<Project?> Projects { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }
        public DbSet<Models_Domain_File> Files { get; set; }
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