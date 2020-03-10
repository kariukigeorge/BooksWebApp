using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WaterMS.Models;

namespace WaterMS.Data
{
    public class LibraryContext : DbContext
    {

        public LibraryContext(DbContextOptions<LibraryContext> options)
         : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Books> Books { get; set; }

      /*  protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>()
                   .HasOptional(j => j.JournalEntries)
                   .WithMany()
                   .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        } */


    }
}
