using lab4.Models.Domain;
using lab4.Models.Domain.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using File = lab4.Models.Domain.File;
using Task = lab4.Models.Domain.Task;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using UserRole = lab4.Models.Domain.IdentityEntities.UserRole;


namespace lab4.Data
{

    public class AppDbContext: IdentityDbContext<AppUser, UserRole, Guid>
    {

        public AppDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }
        
        public DbSet<Project?> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}