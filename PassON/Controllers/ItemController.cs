using Microsoft.AspNetCore.Mvc;
using PassON.Models;
using PassON.ViewModels;

namespace PassON.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="itemRepository"> an item reposity</param>
        /// <param name="categoryRepository"> a category repository</param>
        public ItemController(IItemRepository itemRepository, ICategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
        }


        /// <summary>
        /// Go to Item/List view with ItemListViewModel
        /// </summary>
        /// <returns></returns>
        public IActionResult List()
        {
            ItemListViewModel itemListViewModel = new ItemListViewModel(_itemRepository.GetAll(), "All items");
            return View(itemListViewModel);
        }

        /// <summary>
        /// Go to Item/Details View with item model
        /// </summary>
        /// <param name="id">Pass in the item Id</param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var item = _itemRepository.Get(id);
            if(item == null)
            {
                return NotFound();
            }
            return View(item);
        }
    }
}
