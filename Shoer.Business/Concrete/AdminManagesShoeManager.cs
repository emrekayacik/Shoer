using Shoer.Business.Abstract;
using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity.Admin_Manages_Shoe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Business.Concrete
{
    public class AdminManagesShoeManager : IAdminManagesShoeService
    {
        private IAdminManagesShoeRepository _adminManagesShoeRepository;

        public AdminManagesShoeManager(IAdminManagesShoeRepository adminManagesShoeRepository)
        {
            _adminManagesShoeRepository = adminManagesShoeRepository;
        }
        public void Create(Admin_Manages_Shoe entity)
        {
            _adminManagesShoeRepository.Create(entity);
        }

        public void Delete(Admin_Manages_Shoe entity)
        {
            _adminManagesShoeRepository.Delete(entity);
        }

        public List<Admin_Manages_Shoe> GetAll()
        {
           return _adminManagesShoeRepository.GetAll();
        }

        public Admin_Manages_Shoe GetById(int id)
        {
            return _adminManagesShoeRepository.GetById(id);
        }

        public void Update(Admin_Manages_Shoe entity)
        {
            _adminManagesShoeRepository.Update(entity);
        }
    }
}
