using Shoer.Business.Abstract;
using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity.Brand;
using System.Collections.Generic;

namespace Shoer.Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandRepository _brandRepository;


        public BrandManager(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public Brand GetById(int id)
        {
            return _brandRepository.GetById(id);
        }

        public List<Brand> GetAll()
        {
            return _brandRepository.GetAll();
        }

        public void Create(Brand entity)
        {
            _brandRepository.Create(entity);
        }

        public void Update(Brand entity)
        {
            _brandRepository.Update(entity);
        }

        public void Delete(Brand entity)
        {
            _brandRepository.Delete(entity);
        }

        public Brand GetMostPopularBrand()
        {
            return _brandRepository.GetMostPopularBrand();
        }
    }
}
