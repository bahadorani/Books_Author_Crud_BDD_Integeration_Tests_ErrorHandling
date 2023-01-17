using Books.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Books.Persistence.Configurations
{
    public class BookConfig : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(c => c.Description)
              .IsRequired()
              .HasMaxLength(500);

            builder.OwnsOne(pi => pi.Title, builder =>
            {
                builder.Property(p => p.Value)
                .HasColumnName("Title")
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired();
            });

            builder.OwnsOne(pi => pi.Price, builder =>
            {
                builder.Property(p => p.Value)
                .HasColumnName("Price")
                .HasColumnType("decimal")
                .IsRequired();
            });

            builder.HasOne(b => b.BookAuthor)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
