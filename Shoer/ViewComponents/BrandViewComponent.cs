using Microsoft.AspNetCore.Mvc;
using Shoer.Business.Abstract;

namespace Shoer.ViewComponents
{
    public class BrandViewComponent : ViewComponent
    {
        private readonly IBrandService _brandService;

        public BrandViewComponent(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public IViewComponentResult Invoke()
        {
            var list = _brandService.GetAll();
            return View(list);
        }
    }
}
