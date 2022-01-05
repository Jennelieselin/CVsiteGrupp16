using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data.Contexts
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public virtual ICollection<Project> Project { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Project> projects { get; set; }
        public DbSet<UserInProject> usersInProjects { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<CvProfil> cvs { get; set; }
        public DbSet<Utbildning> utbildningar { get; set; }
        public DbSet<Erfarenhet> erfarenheter { get; set; }
        public DbSet<Kompetens> kompetens { get; set; }



    public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
