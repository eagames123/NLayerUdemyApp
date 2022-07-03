namespace NLayer.Core.DTOs
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        //Not:int, bool ve decimal değer tiplerinde olduğu için default olarak 0 (sınıf) değeri geldiğinden uyarı vermemekte.
        public int Stock { get; set; }

        public decimal Price { get; set; }

        //Not:Entity isimlendirme standartında İlgili nesne isminin yanına Id belirtirsek otomatik ForeignKey olarak algılamaktadır.
        public int CategoryId { get; set; }
    }
}
