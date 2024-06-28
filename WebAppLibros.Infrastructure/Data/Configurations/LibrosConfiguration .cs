using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppLibros.Core.Entities;

namespace WebAppLibros.Infrastructure.Data.Configurations
{
    public class LibrosConfiguration : IEntityTypeConfiguration<Libros>
    {
        public void Configure(EntityTypeBuilder<Libros> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(255);
            builder
               .Property(x => x.Title)
               .IsRequired()
               .HasMaxLength(255);
            builder
               .Property(x => x.Url)
               .IsRequired()
               .HasMaxLength(255);

            builder
              .Property(x => x.Count);
            
            builder
             .Property(x => x.IsDeleted);


            builder
                .ToTable("Libros");
        }
    }
}
