using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoer.Business.Abstract;
using Shoer.Entity.Customer;
using Shoer.Entity.CustomerAdress;
using Shoer.Entity.CustomerContact;
using Shoer.Models;
using System.Linq;

namespace Shoer.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerContactService _customerContactService;
        private readonly ICustomerAdressService _customerAdressService;
        private readonly IAdminService _adminService;
        private readonly IOrderService _orderService;

        public CustomerController(ICustomerService customerService, IOrderService orderService, IAdminService adminService,
            ICustomerAdressService customerAdressService, ICustomerContactService customerContactService)
        {
            _customerService = customerService;
            _orderService = orderService;
            _adminService = adminService;
            _customerContactService = customerContactService;
            _customerAdressService = customerAdressService;
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
                _customerContactService.Create(new CustomerContact()
                {
                    CustomerId = _customerService.GetAll().Last().Id,
                    Email = model.Email,
                    PhoneNo = model.Phone
                });
                _customerAdressService.Create(new CustomerAdress()
                {
                    CustomerId = _customerService.GetAll().Last().Id,
                    ApartmentNo = model.ApartmentNo,
                    City = model.City,
                    FlatNo = model.FlatNo,
                    PostalCode = model.Postalcode,
                    Street = model.Street
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
                if (_adminService.GetAll().Any(x => x.UserName == model.UserName && x.AdminPassword == model.CustomerPassword))
                {
                    HttpContext.Session.SetString("Admin", model.UserName);
                    return RedirectToAction("Index", "Admin");
                }
                else if (_customerService.GetAll().Any(x => x.UserName == model.UserName && x.CustomerPassword == model.CustomerPassword))
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
            HttpContext.Session.Remove("Admin");
            return RedirectToAction("Index", "Home");
        }
    }
}
