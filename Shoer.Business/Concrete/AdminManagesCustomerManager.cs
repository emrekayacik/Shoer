using Shoer.Business.Abstract;
using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity.Admin_Manages_Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Business.Concrete
{
    public class AdminManagesCustomerManager : IAdminManagesCustomerService
    {

        private IAdminManagesCustomerRepository _adminManagesCustomerRepository;

        public AdminManagesCustomerManager(IAdminManagesCustomerRepository adminManagesCustomerRepository)
        {
            _adminManagesCustomerRepository = adminManagesCustomerRepository;
        }
        public void Create(Admin_Manages_Customer entity)
        {
            _adminManagesCustomerRepository.Create(entity);
        }

        public void Delete(Admin_Manages_Customer entity)
        {
            _adminManagesCustomerRepository.Delete(entity);
        }

        public List<Admin_Manages_Customer> GetAll()
        {
            return _adminManagesCustomerRepository.GetAll();
        }

        public Admin_Manages_Customer GetById(int id)
        {
            return _adminManagesCustomerRepository.GetById(id);
        }

        public void Update(Admin_Manages_Customer entity)
        {
            _adminManagesCustomerRepository.Update(entity);
        }
    }
}
