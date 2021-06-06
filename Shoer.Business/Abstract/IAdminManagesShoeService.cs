using Shoer.Entity.Admin_Manages_Shoe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Business.Abstract
{
    public interface IAdminManagesShoeService
    {
        Admin_Manages_Shoe GetById(int id);

        List<Admin_Manages_Shoe> GetAll();

        void Create(Admin_Manages_Shoe entity);

        void Update(Admin_Manages_Shoe entity);
        void Delete(Admin_Manages_Shoe entity);
    }
}
