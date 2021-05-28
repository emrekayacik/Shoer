using Microsoft.AspNetCore.Mvc;
using Shoer.Business.Abstract;

namespace Shoer.Controllers
{
    public class HomeController : Controller
    {
        private IBrandService _brandService;

        public HomeController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public IActionResult Index()
        {
            var list = _brandService.GetAll();
            return View(list);
        }
    }
}
