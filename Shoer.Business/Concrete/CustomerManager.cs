using Shoer.Business.Abstract;
using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity.Customer;
using System.Collections.Generic;

namespace Shoer.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerRepository _CustomerRepository;


        public CustomerManager(ICustomerRepository CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
        }
        public Customer GetById(int id)
        {
            return _CustomerRepository.GetById(id);
        }

        public List<Customer> GetAll()
        {
            return _CustomerRepository.GetAll();
        }

        public void Create(Customer entity)
        {
            _CustomerRepository.Create(entity);
        }

        public void Update(Customer entity)
        {
            _CustomerRepository.Update(entity);
        }

        public void Delete(Customer entity)
        {
            _CustomerRepository.Delete(entity);
        }

        public Customer GetCustomerOfTheMonth()
        {
            throw new System.NotImplementedException();
        }
    }
}
