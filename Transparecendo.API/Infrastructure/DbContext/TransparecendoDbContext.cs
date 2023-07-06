using Microsoft.EntityFrameworkCore;
using Transparecendo.API.Entities;

namespace Transparecendo.Service.API.Infrastructure.DbContext
{
    public class TransparecendoDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public TransparecendoDbContext(DbContextOptions<TransparecendoDbContext> options) : base(options)
        {
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(configuration["SqlConnection:SqlConnectionString"]);
        //}


        public DbSet<CorporateSpending> CorporateSpending { get; set; }

        public override int SaveChanges()
        {
            //foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            //{
            //    if (entry.State == EntityState.Added)
            //    {
            //        entry.Property("DataCadastro").CurrentValue = DateTime.Now;
            //    }
            //}
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
