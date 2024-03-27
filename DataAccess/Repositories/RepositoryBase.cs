using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace DataAccess.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        private readonly DbSet<T> _entities;
        protected readonly EntityContext<T> _context;

        public RepositoryBase(EntityContext<T> context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public T Get(int id)
        {
            return _entities.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _entities.AsQueryable();
        }

        public void CreateMany(IEnumerable<T> items)
        {
            _entities.AddRange(items);
            _context.SaveChanges();
        }

        public void Create(T item)
        {
            _entities.Add(item);
            _context.SaveChanges();
        }

        public void Delete(T item)
        {
            _entities.Remove(item);
            _context.SaveChanges();
        }
        public void Update(T item)
        {
            _entities.Update(item);
            _context.SaveChanges();
        }

        public void DeleteMany(IEnumerable<T> items)
        {
            _entities.RemoveRange(items);
            _context.SaveChanges();
        }
    }
}
