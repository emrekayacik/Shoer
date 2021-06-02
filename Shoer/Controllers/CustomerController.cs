using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoer.Business.Abstract;
using Shoer.Entity.Customer;
using Shoer.Models;
using System.Linq;

namespace Shoer.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;

        public CustomerController(ICustomerService customerService, IOrderService orderService)
        {
            _customerService = customerService;
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            return View(_orderService.GetAll().Where(x => x.CustomerId == _customerService.GetAll()
                .FirstOrDefault(c => c.UserName == HttpContext.Session.GetString("UserName")).Id)
                .ToList());
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                _customerService.Create(new Customer()
                {
                    UserName = model.UserName,
                    CustomerPassword = model.CustomerPassword,
                    Firstname = model.Firstname,
                    LastName = model.LastName
                });
                return RedirectToAction("Login", "Customer");
            }
            return View(model);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login model)
        {
            if (ModelState.IsValid && model.UserName != null && model.CustomerPassword != null)
            {
                if (_customerService.GetAll().Any(x => x.UserName == model.UserName && x.CustomerPassword == model.CustomerPassword))
                {
                    HttpContext.Session.SetString("UserName", model.UserName);
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.error = "Your username of password is invalid. Please try again.";
            }
            return View(model);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index", "Home");
        }
    }
}
