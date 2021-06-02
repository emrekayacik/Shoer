using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoer.Business.Abstract;
using Shoer.Models;
using System.Linq;

namespace Shoer.Controllers
{
    public class CartController : Controller
    {
        private readonly IShoeService _shoeService;

        public CartController(IShoeService shoeService)
        {
            _shoeService = shoeService;
        }
        public IActionResult Index()
        {
            return View(GetCart().Shoes);
        }
        public IActionResult Summary()
        {
            return PartialView();
        }
        public IActionResult RemoveFromCart(int Id)
        {

            var key = "Cart";
            var obj = GetCart();

            obj.Shoes.RemoveAt(Id);


            var str = JsonConvert.SerializeObject(obj);
            HttpContext.Session.SetString(key, str);
            return RedirectToAction("Index", "Cart");
        }
        public IActionResult AddToCart(int Id)
        {
            var shoe = _shoeService.GetAll().FirstOrDefault(x => x.Id == Id);
            if (shoe != null)
            {
                var key = "Cart";
                var obj = GetCart();

                obj.Shoes.Add(shoe);


                var str = JsonConvert.SerializeObject(obj);
                HttpContext.Session.SetString(key, str);
            }
            return RedirectToAction("Index", "Cart");
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
