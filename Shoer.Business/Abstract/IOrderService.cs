using Shoer.Entity.Order;
using System.Collections.Generic;

namespace Shoer.Business.Abstract
{
    public interface IOrderService
    {
        Order GetById(int id);

        List<Order> GetAll();

        void Create(Order entity);

        void Update(Order entity);
        void Delete(Order entity);
    }
}
