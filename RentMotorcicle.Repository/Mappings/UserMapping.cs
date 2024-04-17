using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentMotorcicle.Domain;

namespace RentMotorcicle.Repository.Mappings
{
    public sealed class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(user => user.Id).HasName("Id");
            builder.HasIndex(user => user.Email).IsUnique();
            builder.Property(property => property.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(property => property.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            builder.Property(property => property.Email).HasColumnName("Email").HasMaxLength(50).IsRequired();
            builder.Property(property => property.Password).HasColumnName("Password").HasMaxLength(100).IsRequired();
        }
    }
}
