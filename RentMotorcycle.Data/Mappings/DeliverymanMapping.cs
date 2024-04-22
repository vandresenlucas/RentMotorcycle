using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentMotorcycle.Data.DeliveryManAggregate;

namespace RentMotorcycle.Repository.Mappings
{
    public sealed class DeliverymanMapping : IEntityTypeConfiguration<Deliveryman>
    {
        public void Configure(EntityTypeBuilder<Deliveryman> builder)
        {
            builder.HasIndex(deliveryman => deliveryman.Cnpj).IsUnique();
            builder.HasIndex(deliveryman => deliveryman.LicenseDriverNumber).IsUnique();
            builder.Property(property => property.IdentifyCode).HasMaxLength(6).IsRequired();
            builder.Property(property => property.Cnpj).HasMaxLength(18).IsRequired();
            builder.Property(property => property.LicenseDriverNumber).HasMaxLength(20).IsRequired();
            builder.Property(property => property.LicenseType).IsRequired();
            builder.Property(property => property.LicenseImage);
            builder.HasOne(a => a.UserFk).WithOne();
        }
    }
}