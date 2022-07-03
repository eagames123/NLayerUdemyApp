using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        IQueryable<T> GetAll();

        //Not:Daha performanslı çalışabilmek için IQueryable yapıldı.
        //Not:Yazmıs olduğumuz sorgular dırekt verı tabanına gitmez. Where kosulu ile bu sağlanılabilir ve donsute tolist vb cagrılabilir.
        //Not:List vb direkt veritabanına gidiyor.
        //productRepository.where(x=>x.id=5).orderby veritabanından istek yapılmıyor
        //productRepository.where(x=>x.id=5).ToListAsync() denildiği zaman veritabanından istek yapılacak.
        //Delegeler methodları işaret eden yapılardır.
        //Expression<Func<>> Func bir delegedir.
        //x entity olmaktadır
        //x.id>5 ise lambda bool alanımızdır. Donus tipidir
        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        //Add tarafında süreç var ekleme ypaıldığından o yüzden async method ozellıgı war
        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        //Update ve Delete Uzun süren bir işlem olmadığından async methodları yok ef core tarafında
        //takıp edılen entity state değişiminden 
        //Memory de ef core tarafında entity takıp ediliyor
        void Update(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

    }
}
