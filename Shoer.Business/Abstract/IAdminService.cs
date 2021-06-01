using Shoer.Entity.Admin;
using System.Collections.Generic;

namespace Shoer.Business.Abstract
{
    public interface IAdminService
    {
        Admin GetById(int id);

        List<Admin> GetAll();

        void Create(Admin entity);

        void Update(Admin entity);
        void Delete(Admin entity);
    }
}
