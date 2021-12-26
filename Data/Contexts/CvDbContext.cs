using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CvDbContext : DbContext 
    {
        public CvDbContext() : base ("DefaultConnection")
        { 
        }


         public DbSet<Cv> Cvs { get; set; }
    } 

   
}
