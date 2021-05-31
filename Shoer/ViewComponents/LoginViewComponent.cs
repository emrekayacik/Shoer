using Microsoft.AspNetCore.Mvc;

namespace Shoer.ViewComponents
{
    public class LoginViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
