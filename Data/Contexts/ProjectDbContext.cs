using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts
{
    public class ProjectDbContext : DbContext 
    {
        public ProjectDbContext() : base ("DefaultConnection") { }
        public DbSet<Project> projects { get; set; }
    }
}
