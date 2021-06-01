using Shoer.Entity.Customer;
using System.Collections.Generic;

namespace Shoer.Business.Abstract
{
    public interface ICustomerService
    {
        Customer GetById(int id);

        List<Customer> GetAll();

        void Create(Customer entity);

        void Update(Customer entity);
        void Delete(Customer entity);
        Customer GetCustomerOfTheMonth();
    }
}
