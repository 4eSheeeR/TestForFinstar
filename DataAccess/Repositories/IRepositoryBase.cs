
namespace DataAccess.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void CreateMany(IEnumerable<T> items);
        void Update(T item);
        void Delete(T item);
        void DeleteMany(IEnumerable<T> items);
    }
}
