using Shoer.Entity.CustomerContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Business.Abstract
{
   public interface ICustomerContactService
    {
        CustomerContact GetById(int id);

        List<CustomerContact> GetAll();

        void Create(CustomerContact entity);

        void Update(CustomerContact entity);
        void Delete(CustomerContact entity);
        CustomerContact GetMostPopularCustomerContact();
    }
}
