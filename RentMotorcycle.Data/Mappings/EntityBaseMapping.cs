using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentMotorcycle.Data.Base;

namespace RentMotorcycle.Repository.Mappings
{
    public class EntityBaseMapping<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(property => property.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(property => property.CreatedDate).IsRequired();
            builder.Property(property => property.UpdatedDate);
        }
    }
}
