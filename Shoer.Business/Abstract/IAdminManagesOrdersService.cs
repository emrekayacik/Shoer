using Shoer.Entity.Admin_Manages_Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Business.Abstract
{
    public interface IAdminManagesOrdersService
    {
        Admin_Manages_Orders GetById(int id);

        List<Admin_Manages_Orders> GetAll();

        void Create(Admin_Manages_Orders entity);

        void Update(Admin_Manages_Orders entity);
        void Delete(Admin_Manages_Orders entity);
    }
}
