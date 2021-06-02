using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoer.Business.Abstract;
using Shoer.Entity.Order;
using Shoer.Entity.OrderDetails;
using Shoer.Models;
using System;
using System.Linq;

namespace Shoer.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly IOrderDetailsService _orderDetailsService;

        public OrderController(IOrderService orderService, ICustomerService customerService, IOrderDetailsService orderDetailsService)
        {
            _orderService = orderService;
            _customerService = customerService;
            _orderDetailsService = orderDetailsService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddOrder()
        {
            var shoes = GetCart();
            _orderService.Create(new Order()
            {
                CustomerId = _customerService.GetAll().FirstOrDefault(x => x.UserName == HttpContext.Session.GetString("UserName")).Id,
                OrderDate = DateTime.Now,
                IsDeleted = false,
                OrderStatus = "WAITING APPROVAL",
                TotalPayment = GetTotal()
            });
            foreach (var item in GetCart().Shoes)
            {
                _orderDetailsService.Create(new OrderDetails()
                {
                    CreatedDate = DateTime.Now,
                    OrderId = _orderService.GetAll().Last().Id,
                    Price = item.Price,
                    Quantity = 1,
                    ShoeId = item.Id
                });
            }
            HttpContext.Session.Remove("Cart");
            TempData["Success"] = "Order succesfully created.";
            return RedirectToAction("Index", "Customer");
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

        public double GetTotal()
        {
            double total = 0;
            foreach (var item in GetCart().Shoes)
            {
                total += item.Price;
            }

            return total;
        }
    }
}
