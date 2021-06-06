using Shoer.Business.Abstract;
using Shoer.Data.Abstract.EntityRepos;
using Shoer.Entity.Admin_Manages_brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Business.Concrete
{
    public class AdminManagesBrandManager : IAdminManagesBrandService
    {

        private IAdminManagesBrandRepository _adminManagesBrandRepository;

        public AdminManagesBrandManager(IAdminManagesBrandRepository adminManagesBrandRepository)
        {
            _adminManagesBrandRepository = adminManagesBrandRepository;
        }
        public void Create(Admin_Manages_Brand entity)
        {
            _adminManagesBrandRepository.Create(entity);
        }

        public void Delete(Admin_Manages_Brand entity)
        {
            _adminManagesBrandRepository.Delete(entity);
        }

        public List<Admin_Manages_Brand> GetAll()
        {
            return _adminManagesBrandRepository.GetAll();
        }

        public Admin_Manages_Brand GetById(int id)
        {
            return _adminManagesBrandRepository.GetById(id);
        }

        public void Update(Admin_Manages_Brand entity)
        {
            _adminManagesBrandRepository.Update(entity);
        }
    }
}
