using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PassON.Models;
using PassON.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PassON.Controllers
{
    [Authorize]
    public class MyAccountController: Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IOrderRespository _orderRespository;
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;

        public MyAccountController(IOrderRespository orderRespository, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IItemRepository itemRepository, ICategoryRepository categoryRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _orderRespository = orderRespository;
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult MyOrders()
        {
            MyOrderViewModel myOrderViewModel =new MyOrderViewModel();
            string? UserName = _userManager.GetUserName(User);
            if (!string.IsNullOrEmpty(UserName))
            {
                myOrderViewModel = new MyOrderViewModel { myOrders =
                        _orderRespository.GetAllOrders().Where(o => o.Email == UserName)};
            }

            return View(myOrderViewModel);
        }

        public IActionResult Sell()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Sell(SellModel sellModel)
        {

            if (ModelState.IsValid)
            {
               _itemRepository.CreateItem(sellModel);
                return RedirectToAction("PostComplete");
            }

            return View(sellModel);
        }

        public IActionResult PostComplete()
        {

            ViewBag.PostCompleteMessage = "Your item has been posted!";
            return View();
        }

    }
}
