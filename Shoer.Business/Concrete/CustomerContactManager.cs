using Shoer.Business.Abstract;
using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity.CustomerContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Business.Concrete
{
    public class CustomerContactManager : ICustomerContactService
    {
        private ICustomerContactRepository _CustomerContactRepository;
        public void Create(CustomerContact entity)
        {
            _CustomerContactRepository.Create(entity);
        }

        public void Delete(CustomerContact entity)
        {
            _CustomerContactRepository.Delete(entity);
        }

        public List<CustomerContact> GetAll()
        {
            return _CustomerContactRepository.GetAll();
        }

        public CustomerContact GetById(int id)
        {
            return _CustomerContactRepository.GetById(id);
        }

        public CustomerContact GetMostPopularCustomerContact()
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerContact entity)
        {
            _CustomerContactRepository.Update(entity);
        }
    }
}
