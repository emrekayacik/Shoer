using Shoer.Entity.Category;
using System.Collections.Generic;

namespace Shoer.Business.Abstract
{
    public interface ICategoryService
    {
        Category GetById(int id);

        List<Category> GetAll();

        void Create(Category entity);

        void Update(Category entity);
        void Delete(Category entity);
        Category GetMostPopularCategory();
    }
}
