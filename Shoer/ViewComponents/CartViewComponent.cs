using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoer.Models;

namespace Shoer.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(GetCart().Shoes.Count);
        }
        public Cart GetCart()
        {
            var key = "Cart";
            var strGet = HttpContext.Session.GetString(key);

            if (strGet == null)
            {
                strGet = JsonConvert.SerializeObject(new Cart());
                HttpContext.Session.SetString(key, strGet);
            }
            var obj = JsonConvert.DeserializeObject<Cart>(strGet);
            return obj;
        }
    }
}
