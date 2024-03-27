using BusinessLogic.Mapping;
using BusinessLogic.Models;
using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;
using System.Text.Json;
using TestTaskForFinStar.Dto;

namespace BusinessLogic.Services
{
    public class ItemService : ServiceBase<Item, ItemDto>, IItemService
    {
        public ItemService(IItemRepository repository, EntityDtoMapping mapper) : base(repository, mapper)
        {
        }

        /// <inheritdoc />
        public ItemDto[] GetByFilter(ItemsFilter filter)
        {
            return GetEntities(GetExpression(filter)).ToArray();
        }

        /// <inheritdoc />
        public void RewriteItemsFromFile(IFormFile uploadedFile)
        {

            using (var fileStream = new StreamReader(uploadedFile.OpenReadStream()))
            {
                var items = JsonSerializer.Deserialize<IEnumerable<ItemDto>>(fileStream.ReadToEnd());
                ClearAll();
                if (items != null && items.Any())
                {
                    CreateMany(items);
                }
            }
        }

        private static Expression<Func<Item, bool>> GetExpression(ItemsFilter filter)
        {
            Expression<Func<Item, bool>> expression = item => true;

            if (filter.Code.HasValue)
            {
                expression = expression.And(item => item.Code == filter.Code.Value);
            }
            if (!string.IsNullOrEmpty(filter.Value))
            {
                expression = expression.And(item => item.Value == filter.Value);
            }
            return expression;
        }
    }
}
