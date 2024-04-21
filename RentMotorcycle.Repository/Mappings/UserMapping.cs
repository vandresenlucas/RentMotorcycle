using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentMotorcycle.Data.UserAggregate;

namespace RentMotorcycle.Repository.Mappings
{
    public sealed class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(user => user.Email).IsUnique();
            builder.Property(property => property.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(property => property.Name).HasMaxLength(50).IsRequired();
            builder.Property(property => property.Email).HasMaxLength(50).IsRequired();
            builder.Property(property => property.Password).HasMaxLength(100).IsRequired();
            builder.Property(property => property.Profile).IsRequired();
        }
    }
}
