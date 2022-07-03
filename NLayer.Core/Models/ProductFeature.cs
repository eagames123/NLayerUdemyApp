namespace NLayer.Core
{
    public class ProductFeature
    {
        public int Id { get; set; }

        public string? Color { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        //Not:Entity isimlendirme standartında İlgili nesne isminin yanına Id belirtirsek otomatik ForeignKey olarak algılamaktadır.
        public int ProductId { get; set; }

        public Product? Product { get; set; }
    }
}
