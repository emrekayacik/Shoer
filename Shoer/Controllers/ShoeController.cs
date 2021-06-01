using Microsoft.AspNetCore.Mvc;
using Shoer.Business.Abstract;
using System.Linq;

namespace Shoer.Controllers
{
    public class ShoeController : Controller
    {
        private readonly IShoeService _shoeService;

        public ShoeController(IShoeService shoeService)
        {
            _shoeService = shoeService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List(int? id)
        {
            return View(id == null ? _shoeService.GetAll() : _shoeService.GetAll().Where(x => x.BrandId == id).ToList());
        }
    }
}
