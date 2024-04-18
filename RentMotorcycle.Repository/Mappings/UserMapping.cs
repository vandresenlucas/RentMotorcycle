﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentMotorcycle.Domain.UserAggregate;

namespace RentMotorcycle.Repository.Mappings
{
    public sealed class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
            builder.HasIndex(user => user.Email).IsUnique();
            builder.Property(property => property.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(property => property.Name).HasMaxLength(50).IsRequired();
            builder.Property(property => property.Email).HasMaxLength(50).IsRequired();
            builder.Property(property => property.Password).HasMaxLength(100).IsRequired();
            builder.Property(property => property.CreatedDate).IsRequired();
            builder.Property(property => property.UpdatedDate);
        }
    }
}
