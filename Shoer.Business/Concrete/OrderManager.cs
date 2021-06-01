using Shoer.Data.Abstract;
using Shoer.Entity.Order;
using System.Collections.Generic;

namespace Shoer.Business.Concrete
{
    public class OrderManager
    {
        private IRepository<Order> _OrderRepository;


        public OrderManager(IRepository<Order> OrderRepository)
        {
            _OrderRepository = OrderRepository;
        }
        public Order GetById(int id)
        {
            return _OrderRepository.GetById(id);
        }

        public List<Order> GetAll()
        {
            return _OrderRepository.GetAll();
        }

        public void Create(Order entity)
        {
            _OrderRepository.Create(entity);
        }

        public void Update(Order entity)
        {
            _OrderRepository.Update(entity);
        }

        public void Delete(Order entity)
        {
            _OrderRepository.Delete(entity);
        }
    }
}
