using Shoer.Entity.Admin_Manages_Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoer.Business.Abstract
{
    public interface IAdminManagesCustomerService
    {
        Admin_Manages_Customer GetById(int id);

        List<Admin_Manages_Customer> GetAll();

        void Create(Admin_Manages_Customer entity);

        void Update(Admin_Manages_Customer entity);
        void Delete(Admin_Manages_Customer entity);

    }
}
