using Microsoft.AspNetCore.Mvc;

namespace ComputerService.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}