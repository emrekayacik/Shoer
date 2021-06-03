using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoer.Business.Abstract;
using Shoer.Entity.Brand;
using Shoer.Entity.Category;
using Shoer.Entity.Shoe;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shoer.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IAdminService _adminService;
        private readonly IOrderService _orderService;
        private readonly IShoeService _shoeService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;
        private IHostingEnvironment _env;

        public AdminController(ICustomerService customerService, IAdminService adminService, IOrderService orderService,
            IShoeService shoeService, IBrandService brandService, ICategoryService categoryService, IHostingEnvironment env)
        {
            _customerService = customerService;
            _adminService = adminService;
            _orderService = orderService;
            _shoeService = shoeService;
            _brandService = brandService;
            _categoryService = categoryService;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_customerService.GetAll());
        }
        public IActionResult WaitingApproval()
        {
            return View(_orderService.GetAll().Where(x => x.OrderStatus == "WAITING APPROVAL").ToList());
        }
        public IActionResult ApproveOrder(int id)
        {
            var entity = _orderService.GetById(id);
            entity.OrderStatus = "APPROVED";
            _orderService.Update(entity);
            TempData["Success"] = "Başarılı.";
            return RedirectToAction("WaitingApproval");
        }
        public IActionResult RemoveOrder(int id)
        {
            _orderService.Delete(_orderService.GetById(id));
            TempData["Success"] = "Başarılı.";
            return RedirectToAction("WaitingApproval");
        }
        public IActionResult WaitingShipping()
        {
            return View(_orderService.GetAll().Where(x => x.OrderStatus == "APPROVED").ToList());
        }
        public IActionResult ShipOrder(int id)
        {
            var entity = _orderService.GetById(id);
            entity.OrderStatus = "SHIPPED";
            _orderService.Update(entity);
            TempData["Success"] = "Başarılı.";
            return RedirectToAction("WaitingShipping");
        }
        public IActionResult WaitingComplete()
        {
            return View(_orderService.GetAll().Where(x => x.OrderStatus == "SHIPPED").ToList());
        }
        public IActionResult CompleteOrder(int id)
        {
            var entity = _orderService.GetById(id);
            entity.OrderStatus = "COMPLETED";
            _orderService.Update(entity);
            TempData["Success"] = "Başarılı.";
            return RedirectToAction("WaitingComplete");
        }
        public IActionResult Statistics()
        {
            return View();
        }
        public IActionResult Shoes()
        {
            return View(_shoeService.GetAll());
        }
        public IActionResult Brands()
        {
            return View(_brandService.GetAll());
        }
        public IActionResult AddBrand()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBrand(Brand model)
        {
            if (ModelState.IsValid)
            {
                _brandService.Create(model);
                TempData["Success"] = "Başarılı.";
            }
            return RedirectToAction("Brands");
        }
        public IActionResult UpdateBrand(int id)
        {
            return View(_brandService.GetById(id));
        }
        [HttpPost]
        public IActionResult UpdateBrand(Brand model)
        {
            if (ModelState.IsValid)
            {
                _brandService.Update(model);
                TempData["Success"] = "Başarılı.";
            }
            return RedirectToAction("Brands");
        }
        public IActionResult RemoveBrand(int id)
        {
            _brandService.Delete(_brandService.GetById(id));
            TempData["Success"] = "Başarılı.";
            return RedirectToAction("Brands");
        }
        public IActionResult Categories()
        {
            return View(_categoryService.GetAll());
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category model)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Create(model);
                TempData["Success"] = "Başarılı.";
            }
            return RedirectToAction("Categories");
        }
        public IActionResult UpdateCategory(int id)
        {
            return View(_categoryService.GetById(id));
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category model)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(model);
                TempData["Success"] = "Başarılı.";
            }
            return RedirectToAction("Categories");
        }
        public IActionResult RemoveCategory(int id)
        {
            _categoryService.Delete(_categoryService.GetById(id));
            TempData["Success"] = "Başarılı.";
            return RedirectToAction("Categories");
        }
        public IActionResult AddShoe()
        {
            ViewBag.Brands = _brandService.GetAll();
            ViewBag.Categories = _categoryService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult AddShoe(Shoe model, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    string extension = Path.GetExtension(ImageFile.FileName);
                    var uploadPath = Path.Combine(_env.WebRootPath, @"img\ShoeImages");
                    var randomFileName = Path.GetRandomFileName();
                    var fileNameFinal = Path.ChangeExtension(randomFileName, extension);
                    model.ImageText = fileNameFinal;
                    var fullPath = Path.Combine(uploadPath, fileNameFinal);
                    _shoeService.Create(model);
                    Upload(ImageFile, fullPath);
                }
            }
            TempData["Success"] = "Başarılı.";

            return RedirectToAction("Shoes");
        }
        [HttpPost]
        public async Task<bool> Upload(IFormFile files, string fullPath)
        {
            using (Stream fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await files.CopyToAsync(fileStream);
            }

            return true;
        }
        public IActionResult UpdateShoe(int id)
        {
            ViewBag.Brands = _brandService.GetAll();
            ViewBag.Categories = _categoryService.GetAll();
            var item = _shoeService.GetById(id);
            return View(item);
        }
        [HttpPost]
        public IActionResult UpdateShoe(Shoe model)
        {
            if (ModelState.IsValid)
            {
                _shoeService.Update(model);
            }
            TempData["Success"] = "Başarılı.";
            return RedirectToAction("Shoes");
        }
        public IActionResult RemoveShoe(int id)
        {
            string fullPath = Path.Combine(_env.WebRootPath, @"img\ShoeImages\" + _shoeService.GetById(id).ImageText);
            System.IO.File.Delete(fullPath);

            _shoeService.Delete(_shoeService.GetById(id));
            TempData["Success"] = "Başarılı.";
            return RedirectToAction("Shoes");
        }

    }
}
