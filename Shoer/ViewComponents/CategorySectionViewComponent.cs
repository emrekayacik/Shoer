using Microsoft.AspNetCore.Mvc;
using Shoer.Business.Abstract;

namespace Shoer.ViewComponents
{
    public class CategorySectionViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategorySectionViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            var action = RouteData?.Values["action"];
            if (action?.ToString() == "Category")
            {
                ViewBag.SelectedCategory = RouteData?.Values["id"] + "category";
            }
            return View(_categoryService.GetAll());
        }
    }
}
