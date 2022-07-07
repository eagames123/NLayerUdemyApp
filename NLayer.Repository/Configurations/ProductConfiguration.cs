using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Stock).IsRequired();
            //Not: Decimal türünde price kolonu ve toplam 18 karakter olacak , virgülden sonra 2 karakter tutmasını söylüyoruz.
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.ToTable("Products");

            //ManuelTanımlama işlemi belirtme işlemi.
            //Bir Product ın bir kategorisi olabilir. HasOne
            //withMany bir kategorininde birden fazla products olabilir
            //hasforeignkey productta yer alan categoryId
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
        }
    }
}
