using Microsoft.AspNetCore.Mvc;
using PassON.Models;
using PassON.ViewModels;

namespace PassON.Controllers
{
    public class HomeController : Controller
    {

        private readonly IItemRepository _itemRepository;

        public HomeController(IItemRepository itemRepository){
            _itemRepository = itemRepository;
            }

        /// <summary>
        /// Go to Home/Index view
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var promotedItem = _itemRepository.GetAll().Where(c => c.IsPromoted).OrderBy(c => c.Name);
            var homeViewModel = new HomeViewModel(promotedItem);

            return View(homeViewModel);
        }
    }
}
