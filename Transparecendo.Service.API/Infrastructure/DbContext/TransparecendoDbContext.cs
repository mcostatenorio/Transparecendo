using Microsoft.EntityFrameworkCore;
using Transparecendo.Service.Domain.Entities;

namespace Transparecendo.Service.API.Infrastructure.DbContext
{
    public class TransparecendoDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public TransparecendoDbContext()
        {
        }

        public TransparecendoDbContext(DbContextOptions<TransparecendoDbContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=infokeydb;user=root;password=Ronaldinho.01");
        }


        public DbSet<CorporateSpending> CorporateSpending { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TransparecendoDbContext).Assembly);

            //Desabilita todos os cascades das tabelas
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
