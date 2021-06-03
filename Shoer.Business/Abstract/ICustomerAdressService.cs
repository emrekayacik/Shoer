using Shoer.Entity.CustomerAdress;
using System.Collections.Generic;

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
