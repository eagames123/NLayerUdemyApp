using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NLayer.Core;

namespace NLayer.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Not:Her Proje bir assemly dir.
            //Calısmıs olduğumuz assembly getexecuting "IEntityTypeConfiguration" bakıp ilgili çalışmaları buluyor.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Tek tek tanımlamak için aşağıda yer alan kod calıstırılabilir.
            //Yüzlerce olduğunu düşürsek bu kullanım uygun degıl. 
            //Yukarıda yer aldığı gibi çalışılan assemly üzerinden hepsini bulması uygun olacaktır.
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());


            //Best practise açısından burada yazılması uygun değil. 
            //Seeds klasoru üzerinde yapılan çalışmayı burada da yapabilirdik. Fakat burada kalabalık bir kod yapısı oluşturmamak için ayrı dosyada işlem yapıldı.
            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id = 1,
                Color = "Kırmızı",
                Height = 100,
                Width = 100,
                ProductId = 1,
            }, new ProductFeature()
            {
                Id = 2,
                Color = "Sarı",
                Height = 200,
                Width = 200,
                ProductId = 2,
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
