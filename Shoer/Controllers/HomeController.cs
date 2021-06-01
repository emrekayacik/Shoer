using Microsoft.AspNetCore.Mvc;
using Shoer.Business.Abstract;

namespace Shoer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShoeService _shoeService;

        public HomeController(IShoeService shoeService)
        {
            _shoeService = shoeService;
        }
        public IActionResult Index()
        {
            return View(_shoeService.GetMostPopularShoe());
        }
    }
}
