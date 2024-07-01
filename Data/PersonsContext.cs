using ElectroTask.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectroTask.Data
{
    public class PersonsContext : DbContext
    {
        public PersonsContext(DbContextOptions<PersonsContext> options) : base(options) { }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                        .HasOne(p => p.Parent)
                        .WithMany()
                        .HasForeignKey(p => p.ParentId);
        }
    }
}
