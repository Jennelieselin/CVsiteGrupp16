using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts
{
    public class UsersProjectDbContext : DbContext
    {
        public UsersProjectDbContext() : base("DefaultConnection") { }
    public DbSet<ApplicationUserProject> usersInProjects { get; set; }
    }
}
