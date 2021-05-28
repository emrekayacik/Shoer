using Shoer.Entity.Brand;

namespace Shoer.Data.Abstract.EntityRepos
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Brand GetMostPopularBrand();
    }
}
