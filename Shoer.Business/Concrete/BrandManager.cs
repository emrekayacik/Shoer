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
            throw new System.NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            return _brandRepository.GetAll();
        }

        public void Create(Brand entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Brand entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Brand entity)
        {
            throw new System.NotImplementedException();
        }

        public Brand GetMostPopularBrand()
        {
            throw new System.NotImplementedException();
        }
    }
}
