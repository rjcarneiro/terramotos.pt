using System;
using Carneiro.Terramotos.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Carneiro.Terramotos.Web.Data
{
    public class EarthQuakeDbContext : DbContext
    {
        public DbSet<EarthQuake> EarthQuakes { get; set; }

        public DbSet<Location> Locations { get; set; }

        public EarthQuakeDbContext(DbContextOptions<EarthQuakeDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var dateTimeConverter =
                new ValueConverter<DateTime, DateTime>(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
                foreach (IMutableProperty property in entityType.GetProperties())
                    if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                        property.SetValueConverter(dateTimeConverter);

            builder.Entity<EarthQuake>(table =>
            {
                table.HasKey(t => t.Id);
                table.Property(t => t.Latitude).HasColumnType("decimal(18,5)");
                table.Property(t => t.Longitude).HasColumnType("decimal(18,5)");
                table.Property(t => t.Magnitud).HasColumnType("decimal(18,5)");
                table.ToTable("Spots");
            });
        }
    }
}