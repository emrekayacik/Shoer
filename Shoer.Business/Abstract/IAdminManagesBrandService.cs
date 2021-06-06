

using Shoer.Entity.Admin_Manages_brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Business.Abstract
{
    public interface IAdminManagesBrandService
    {
        Admin_Manages_Brand GetById(int id);

        List<Admin_Manages_Brand> GetAll();

        void Create(Admin_Manages_Brand entity);

        void Update(Admin_Manages_Brand entity);
        void Delete(Admin_Manages_Brand entity);
    }
}
