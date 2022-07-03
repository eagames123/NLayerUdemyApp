//Not:Library Property içerisinden Nullable özelliği disable yapılarak Nullable kontolleri kapatılabilir.
namespace NLayer.Core
{
    //Not:New Alınmaması için Abstract Yapıldı.
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
