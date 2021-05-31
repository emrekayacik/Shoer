using Shoer.Business.Abstract;
using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity.Category;
using System.Collections.Generic;

namespace Shoer.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _CategoryRepository;


        public CategoryManager(ICategoryRepository CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }
        public Category GetById(int id)
        {
            return _CategoryRepository.GetById(id);
        }

        public List<Category> GetAll()
        {
            return _CategoryRepository.GetAll();
        }

        public void Create(Category entity)
        {
            _CategoryRepository.Create(entity);
        }

        public void Update(Category entity)
        {
            _CategoryRepository.Update(entity);
        }

        public void Delete(Category entity)
        {
            _CategoryRepository.Delete(entity);
        }

        public Category GetMostPopularCategory()
        {
            throw new System.NotImplementedException();
        }
    }
}
