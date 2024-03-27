using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class EntityContext<T> : DbContext
        where T : Entity
    {
        public EntityContext(DbContextOptions<EntityContext<T>> options) : base(options)
        {

        }

        public DbSet<T> Items { get; private set; }
    }
}
