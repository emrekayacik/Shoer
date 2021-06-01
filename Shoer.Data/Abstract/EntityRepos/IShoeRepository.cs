using Shoer.Entity.Shoe;

namespace Shoer.Data.Abstract.EntityRepos
{
    public interface IShoeRepository : IRepository<Shoe>
    {
        Shoe GetMostPopularShoe();
    }
}
