using Microsoft.AspNetCore.Mvc;
using PassON.Models;
using PassON.ViewModels;

namespace PassON.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ItemController(IItemRepository itemRepository, ICategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
        }


        public IActionResult List()
        {
            ItemListViewModel itemListViewModel = new ItemListViewModel(_itemRepository.GetAll(), "Electronic");
            return View(itemListViewModel);
        }
    }
}
