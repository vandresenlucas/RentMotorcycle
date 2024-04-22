using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentMotorcycle.Domain.RentalPlansAggregate;

namespace RentMotorcycle.Data.Mappings
{
    public sealed class RentalPlanMapping : IEntityTypeConfiguration<RentalPlan>
    {
        public void Configure(EntityTypeBuilder<RentalPlan> builder)
        {
            builder.Property(property => property.Period).IsRequired();
            builder.Property(property => property.Price).IsRequired();
        }
    }
}
