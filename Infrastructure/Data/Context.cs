using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            try
            {
                Database.EnsureCreated();
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        public DbSet<Departaments> Departaments { get; set; }
        public DbSet<MOVIMENTO_MANUAL> MOVIMENTO_MANUAL { get; set; }
        public DbSet<PRODUTO> PRODUTO { get; set; }
        public DbSet<PRODUTO_COSIF> PRODUTO_COSIF { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PRODUTO>()
                .HasKey(p => p.COD_PRODUTO);

            modelBuilder.Entity<MOVIMENTO_MANUAL>()                
                .HasKey(mm => mm.NUM_LANCAMENTO);

            modelBuilder.Entity<PRODUTO_COSIF>()
                .HasKey(pc => pc.COD_COSIF);

            modelBuilder.Entity<MOVIMENTO_MANUAL>()
                .HasOne(mm => mm.PRODUTO_COSIF)
                .WithOne()
                .HasForeignKey<MOVIMENTO_MANUAL>(pc => pc.COD_COSIF);

            modelBuilder.Entity<PRODUTO_COSIF>()
               .HasOne(mm => mm.PRODUTO)
               .WithOne()
               .HasForeignKey<PRODUTO>(pc => pc.COD_PRODUTO);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                if (!optionsBuilder.IsConfigured)
                    optionsBuilder.UseSqlServer(GetStringConectionConfig());
                base.OnConfiguring(optionsBuilder);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private string GetStringConectionConfig()
        {
            string strCon = "Data Source=FERN\\SQLEXPRESS; Initial Catalog=FRN-EC-2021; User Id=Fern;Password=1234";
            return strCon;
        }


     }
}