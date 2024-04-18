using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentMotorcycle.Data.MotorcycleAggregate;

namespace RentMotorcycle.Repository.Mappings
{
    public sealed class MotorcycleMapping : IEntityTypeConfiguration<Motorcycle>
    {
        public void Configure(EntityTypeBuilder<Motorcycle> builder)
        {
            builder.HasIndex(motorcycle => motorcycle.LicensePlate).IsUnique();
            builder.Property(property => property.IdentifyCode).HasMaxLength(6).IsRequired();
            builder.Property(property => property.Year).IsRequired();
            builder.Property(property => property.LicensePlate).HasMaxLength(10).IsRequired();
            builder.Property(property => property.Model).HasMaxLength(30).IsRequired();
        }
    }
}
