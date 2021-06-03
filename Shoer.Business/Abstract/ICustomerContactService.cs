using Shoer.Entity.CustomerContact;
using System.Collections.Generic;

namespace Shoer.Business.Abstract
{
    public interface ICustomerContactService
    {
        CustomerContact GetById(int id);

        List<CustomerContact> GetAll();

        void Create(CustomerContact entity);

        void Update(CustomerContact entity);
        void Delete(CustomerContact entity);
    }
}
