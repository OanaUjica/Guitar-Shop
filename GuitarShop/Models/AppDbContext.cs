using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarShop.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Guitar> Guitars { get; set; }
        public DbSet<GuitarSpecification> GuitarSpecifications { get; set; }
        public DbSet<Contact> Contacts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuitarSpecification>(gs =>
            {
                gs.ToTable("Guitars");
            });

            modelBuilder.Entity<Guitar>(guitar =>
            {
                guitar.ToTable("Guitars");
                guitar.HasOne(g => g.Specifications).WithOne()
                    .HasForeignKey<GuitarSpecification>(gs => gs.Id);
            });

            //modelBuilder.Entity<Guitar>()
            //    .HasOne(g => g.Specifications).WithOne(spec => spec.Guitar)
            //    .HasForeignKey<GuitarSpecification>(spec => spec.GuitarId);
            //modelBuilder.Entity<Guitar>().ToTable("Guitars");
            //modelBuilder.Entity<GuitarSpecification>().ToTable("Guitars");
        }
    }
}
