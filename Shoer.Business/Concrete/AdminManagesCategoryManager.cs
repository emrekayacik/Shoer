using Shoer.Business.Abstract;
using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Business.Concrete
{
   public class AdminManagesCategoryManager : IAdminManagesCategoryService
    {
        private IAdminManagesCategoryRepository _adminManagesCategoryRepository;

        public AdminManagesCategoryManager(IAdminManagesCategoryRepository adminManagesCategoryRepository )
        {
            _adminManagesCategoryRepository = adminManagesCategoryRepository;
        }
        public void Create(Admin_Manages_Category entity)
        {
            _adminManagesCategoryRepository.Create(entity);
        }

        public void Delete(Admin_Manages_Category entity)
        {
            _adminManagesCategoryRepository.Delete(entity);

        }

        public List<Admin_Manages_Category> GetAll()
        {
            return _adminManagesCategoryRepository.GetAll();
        }

        public Admin_Manages_Category GetById(int id)
        {
            return _adminManagesCategoryRepository.GetById(id);
        }

        public void Update(Admin_Manages_Category entity)
        {
            _adminManagesCategoryRepository.Update(entity);
        }
    }
}
