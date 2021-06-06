using Shoer.Business.Abstract;
using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity.Admin_Manages_Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Business.Concrete
{
    public class AdminManagesOrdersManager : IAdminManagesOrdersService
    {

        private IAdminManagesOrdersRepository _adminManagesOrdersRepository;

        public AdminManagesOrdersManager(IAdminManagesOrdersRepository adminManagesOrdersRepository)
        {
            _adminManagesOrdersRepository = adminManagesOrdersRepository;
        }
        public void Create(Admin_Manages_Orders entity)
        {
            _adminManagesOrdersRepository.Create(entity);
        }

        public void Delete(Admin_Manages_Orders entity)
        {
            _adminManagesOrdersRepository.Delete(entity);
        }

        public List<Admin_Manages_Orders> GetAll()
        {
          return _adminManagesOrdersRepository.GetAll();
        }

        public Admin_Manages_Orders GetById(int id)
        {
          return _adminManagesOrdersRepository.GetById(id);
        }

        public void Update(Admin_Manages_Orders entity)
        {
            _adminManagesOrdersRepository.Update(entity);
        }
    }
}
