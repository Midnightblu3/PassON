using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassON.Models;

namespace PassON.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController: ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public SearchController(IItemRepository itemRepository)
        {
            _itemRepository= itemRepository;

        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var allItems= _itemRepository.GetAll();
            return Ok(allItems);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if(!_itemRepository.GetAll().Any(i=>i.Id==id))
                return NotFound();
            return Ok(_itemRepository.GetAll().Where(i => i.Id == id));
        }

        [HttpPost]
        public IActionResult SearchItemsByName([FromBody] string searchQuery)
        {
            IEnumerable<Item> items = new List<Item>();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                items = _itemRepository.SearchItems(searchQuery);
            }

            return new JsonResult(items);

        }


    }
}
