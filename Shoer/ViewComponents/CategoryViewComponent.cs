using Microsoft.AspNetCore.Mvc;
using Shoer.Business.Abstract;

namespace Shoer.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_categoryService.GetAll());
        }
    }
}
