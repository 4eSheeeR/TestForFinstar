using DataAccess.Context;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(EntityContext<Item> context): base(context)
        {
        }
    }
}
