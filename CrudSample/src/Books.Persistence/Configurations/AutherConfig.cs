using Books.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Books.Persistence.Configurations
{
    public class AutherConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);

            builder.OwnsOne(pi => pi.FullName, builder =>
            {
                builder.Property(p => p.Value)
                .HasColumnName("FullName")
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired();
            });
        }
    }
}


