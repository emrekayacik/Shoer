using Shoer.Entity.Shoe;
using System.Collections.Generic;

namespace Shoer.Business.Abstract
{
    public interface IShoeService
    {
        Shoe GetById(int id);

        List<Shoe> GetAll();

        void Create(Shoe entity);

        void Update(Shoe entity);
        void Delete(Shoe entity);
        Shoe GetMostPopularShoe();
    }
}
