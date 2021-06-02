using Shoer.Business.Abstract;
using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity.CustomerAdress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Business.Concrete
{
    public class CustomerAdressManager : ICustomerAdressService
    {

        private ICustomerAdressRepository _customerAdressRepository;

        public CustomerAdressManager(ICustomerAdressRepository customerAdressRepository)
        {
            _customerAdressRepository = customerAdressRepository;
        }
        public void Create(CustomerAdress entity)
        {
          _customerAdressRepository.Create(entity);
        }

        public void Delete(CustomerAdress entity)
        {
           _customerAdressRepository.Delete(entity);
        }

        public List<CustomerAdress> GetAll()
        {
            return _customerAdressRepository.GetAll();
        }

        public CustomerAdress GetById(int id)
        {
            return _customerAdressRepository.GetById(id);
        }

        public void Update(CustomerAdress entity)
        {
            _customerAdressRepository.Update(entity);
        }
    }
}
