using lab5.Models.Domain;
using lab5.Models.Domain.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using File = lab5.Models.Domain.File;
using Task = lab5.Models.Domain.ProjectTask;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain_File = lab5.Models.Domain.File;
using IdentityEntities_UserRole = lab5.Models.Domain.IdentityEntities.UserRole;
using UserRole = lab5.Models.Domain.IdentityEntities.UserRole;


namespace lab5.Data
{

    public class AppDbContext: IdentityDbContext<AppUser, IdentityEntities_UserRole, Guid>
    {

        public AppDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }
        
        public DbSet<Project?> Projects { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }
        public DbSet<Domain_File> Files { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}