using Contact.Models.Entities.Contact;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Context
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {

        }

        public DbSet<Guide> Guides { get; set; }

        public DbSet<ContactInfo> ContactInfos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guide>().Property(x=>x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Guide>().HasMany(x => x.ContactInfos).WithOne(x => x.Guide).HasForeignKey(x => x.GuideId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
