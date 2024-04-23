using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentMotorcycle.Domain.RentalMotorcycleAggregate;

namespace RentMotorcycle.Data.Mappings
{
    public sealed class RentalMotorcycleMappingcs : IEntityTypeConfiguration<RentalMotorcycle>
    {
        public void Configure(EntityTypeBuilder<RentalMotorcycle> builder)
        {
            builder.HasOne(rentalMotorcycle => rentalMotorcycle.RentalPlanFk).WithMany();
            builder.Property(property => property.StartDate).HasMaxLength(50).IsRequired();
            builder.Property(property => property.EndDate).HasMaxLength(50).IsRequired();
            builder.Property(property => property.EstimatedCompletionDate).HasMaxLength(100).IsRequired();
            builder.HasOne(rentalMotorcycle => rentalMotorcycle.DeliverymanFk).WithMany();
            builder.HasOne(rentalMotorcycle => rentalMotorcycle.MotorcycleFk).WithMany();
        }
    }
}
