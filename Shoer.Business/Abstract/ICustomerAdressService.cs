using Shoer.Entity.CustomerAdress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Business.Abstract
{
    public interface ICustomerAdressService
    {
        CustomerAdress GetById(int id);

        List<CustomerAdress> GetAll();

        void Create(CustomerAdress entity);

        void Update(CustomerAdress entity);
        void Delete(CustomerAdress entity);
    }
}
