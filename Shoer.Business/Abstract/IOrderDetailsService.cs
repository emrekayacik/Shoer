using Shoer.Entity.OrderDetails;
using System.Collections.Generic;

namespace Shoer.Business.Abstract
{
    public interface IOrderDetailsService
    {
        OrderDetails GetById(int id);

        List<OrderDetails> GetAll();

        void Create(OrderDetails entity);

        void Update(OrderDetails entity);
        void Delete(OrderDetails entity);
    }
}
