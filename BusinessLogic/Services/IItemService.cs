using BusinessLogic.Models;
using Microsoft.AspNetCore.Http;
using TestTaskForFinStar.Dto;

namespace BusinessLogic.Services
{
    public interface IItemService
    {
        /// <summary>
        /// Перезаписать объекты из файла
        /// </summary>
        /// <param name="uploadedFile"></param>
        void RewriteItemsFromFile(IFormFile uploadedFile);

        /// <summary>
        /// Получить объекты по фильтру
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        ItemDto[] GetByFilter(ItemsFilter filter);
    }
}
