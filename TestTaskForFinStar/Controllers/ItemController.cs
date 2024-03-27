using AutoMapper;
using BusinessLogic.Mapping;
using BusinessLogic.Models;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TestTaskForFinStar.Dto;
using TestTaskForFinStar.Models;

namespace TestTaskForFinStar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IMapper _queryMapping;
        public ItemController(IItemService itemService,
           QueryParamsMapping queryMapping)
        {
            _itemService = itemService;
            _queryMapping = queryMapping.Mapper;
        }

        [HttpGet("")]
        public IActionResult Get(int? code, string? value)
        {
            var filter = new ItemsFilter() { Code = code, Value = value };
            return Ok(_itemService.GetByFilter(filter));
        }

        [HttpPost]
        public ActionResult Post(IFormFile file)
        {
            if (file != null)
            {
                try
                {
                    _itemService.RewriteItemsFromFile(file);
                }
                catch
                {
                    return RedirectToPage("Error");
                }
            }

            return Ok();
        }
    }
}
