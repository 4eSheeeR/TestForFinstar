using TestTaskForFinStar.Dto;

namespace BusinessLogic.Services
{
    public interface IServiceBase<TEntityDto> where TEntityDto : EntityDto
    {
        /// <summary>
        /// Создать несколько моделей
        /// </summary>
        /// <param name="models"></param>
        void CreateMany(IEnumerable<TEntityDto> models);

        /// <summary>
        /// Получить все
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntityDto> GetAll();

        /// <summary>
        /// Очистить список моделей
        /// </summary>
        void ClearAll();
    }
}
