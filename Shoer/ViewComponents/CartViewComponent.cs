using Microsoft.AspNetCore.Mvc;

namespace Shoer.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
