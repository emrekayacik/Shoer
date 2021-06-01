using Shoer.Business.Abstract;
using Shoer.Data.Abstract;
using Shoer.Entity.OrderDetails;
using System.Collections.Generic;

namespace Shoer.Business.Concrete
{
    public class OrderDetailsManager : IOrderDetailsService
    {
        private IRepository<OrderDetails> _OrderDetailsRepository;


        public OrderDetailsManager(IRepository<OrderDetails> OrderDetailsRepository)
        {
            _OrderDetailsRepository = OrderDetailsRepository;
        }
        public OrderDetails GetById(int id)
        {
            return _OrderDetailsRepository.GetById(id);
        }

        public List<OrderDetails> GetAll()
        {
            return _OrderDetailsRepository.GetAll();
        }

        public void Create(OrderDetails entity)
        {
            _OrderDetailsRepository.Create(entity);
        }

        public void Update(OrderDetails entity)
        {
            _OrderDetailsRepository.Update(entity);
        }

        public void Delete(OrderDetails entity)
        {
            _OrderDetailsRepository.Delete(entity);
        }
    }
}
