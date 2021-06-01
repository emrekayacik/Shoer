using Shoer.Business.Abstract;
using Shoer.Data.Abstract;
using Shoer.Entity.Admin;
using System.Collections.Generic;

namespace Shoer.Business.Concrete
{
    public class AdminManager : IAdminService
    {
        private IRepository<Admin> _AdminRepository;


        public AdminManager(IRepository<Admin> AdminRepository)
        {
            _AdminRepository = AdminRepository;
        }
        public Admin GetById(int id)
        {
            return _AdminRepository.GetById(id);
        }

        public List<Admin> GetAll()
        {
            return _AdminRepository.GetAll();
        }

        public void Create(Admin entity)
        {
            _AdminRepository.Create(entity);
        }

        public void Update(Admin entity)
        {
            _AdminRepository.Update(entity);
        }

        public void Delete(Admin entity)
        {
            _AdminRepository.Delete(entity);
        }
    }
}
