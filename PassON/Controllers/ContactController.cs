using Microsoft.AspNetCore.Mvc;

namespace PassON.Controllers
{
    public class ContactController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
