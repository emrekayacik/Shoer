using Shoer.Entity.Category;

namespace Shoer.Data.Abstract.EntityRepos
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetMostPopularCategory();
    }
}
