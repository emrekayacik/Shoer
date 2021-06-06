using Shoer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Business.Abstract
{
    public interface IAdminManagesCategoryService
    {
        Admin_Manages_Category GetById(int id);

        List<Admin_Manages_Category> GetAll();

        void Create(Admin_Manages_Category entity);

        void Update(Admin_Manages_Category entity);
        void Delete(Admin_Manages_Category entity);
    }
}