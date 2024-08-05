using CaseStudy.Product.Domain.Models;
using CaseStudy.Product.Infra.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Options;

namespace CaseStudy.Product.Infra.Data
{
    public class ProductDbContext : DbContext
    {

        private readonly DatabaseSettings _settings;
        public DbSet<ProductEntity> Products { get; set; }

        public ProductDbContext(IOptions<DatabaseSettings> options){
            _settings = options.Value;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // var connectionString = $"Server={_settings.Server}; Database={_settings.Name}; User Id={_settings.User}; Password={_settings.Password};";
            var connectionString = $"Server={_settings.Server},{_settings.Port};Database=master;User Id={_settings.User};Password={_settings.Password};TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString, _ =>
            {
                _.MigrationsHistoryTable(HistoryRepository.DefaultTableName, _settings.Schema);
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
