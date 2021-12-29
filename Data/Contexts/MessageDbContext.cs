using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts
{
    public class MessageDbContext : DbContext
    {
        public MessageDbContext() : base("DefaultConnection") { }

        public DbSet<Message> messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Author>().HasMany(x => x.Books)
            //    .WithOptional(x => x.AuthoredBy)
            //    .HasForeignKey(x => x.AuthoredById)
            //    .WillCascadeOnDelete(false);
        }
    }
}

