namespace NLayer.Core
{
    public class Product:BaseEntity
    {
        public string? Name { get; set; }

        //Not:int, bool ve decimal değer tiplerinde olduğu için default olarak 0 (sınıf) değeri geldiğinden uyarı vermemekte.
        public int Stock { get; set; }

        public decimal Price { get; set; }

        //Not:Entity isimlendirme standartında İlgili nesne isminin yanına Id belirtirsek otomatik ForeignKey olarak algılamaktadır.
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        //Not:Class ve string referans değer olduğu için NULL olabilir .net6 ile gelen bu uyarı sayesinde ? (soru işareti) ile belirtiyoruz null geçilebilir olduğunu ve uyarıyı geçiyoruz.
        public ProductFeature? ProductFeature { get; set; }
    }
}
