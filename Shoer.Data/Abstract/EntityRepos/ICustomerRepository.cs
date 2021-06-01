using Shoer.Entity.Customer;

namespace Shoer.Data.Abstract.EntityRepos
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetCustomerOfTheMonth();
    }
}
