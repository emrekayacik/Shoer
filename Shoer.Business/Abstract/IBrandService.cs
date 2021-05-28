using Shoer.Entity.Brand;
using System.Collections.Generic;

namespace Shoer.Business.Abstract
{
    public interface IBrandService
    {
        Brand GetById(int id);

        List<Brand> GetAll();

        void Create(Brand entity);

        void Update(Brand entity);
        void Delete(Brand entity);
        Brand GetMostPopularBrand();
    }
}
