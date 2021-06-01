using Shoer.Business.Abstract;
using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity.Shoe;
using System.Collections.Generic;

namespace Shoer.Business.Concrete
{
    public class ShoeManager : IShoeService
    {
        private IShoeRepository _shoeRepository;

        public ShoeManager(IShoeRepository shoeRepository)
        {
            _shoeRepository = shoeRepository;
        }
        public Shoe GetById(int id)
        {
            return _shoeRepository.GetById(id);
        }

        public List<Shoe> GetAll()
        {
            return _shoeRepository.GetAll();
        }

        public void Create(Shoe entity)
        {
            _shoeRepository.Create(entity);
        }

        public void Update(Shoe entity)
        {
            _shoeRepository.Update(entity);
        }

        public void Delete(Shoe entity)
        {
            _shoeRepository.Delete(entity);
        }

        public Shoe GetMostPopularShoe()
        {
            return _shoeRepository.GetMostPopularShoe();
        }
    }
}
