using Microsoft.AspNetCore.Mvc;

namespace Shoer.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Summary()
        {
            return PartialView();
        }
    }
}
