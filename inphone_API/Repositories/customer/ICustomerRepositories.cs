using inphone_API.Dtos;
using inphone_API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace inphone_API.Repositories.customer
{
    public interface ICustomerRepositories
    {
        public Task<IEnumerable<CustomerForDisplayDto>> GetCustomersList();
        public  Task<CustomerForDisplayDto> GetSetupCustomerById(int idCustomer);
        public  Task<bool> SetupNewCustomer(CustomerForSetupDto customer);
        public  Task<bool> EditSetupCustomer(CustomerForSetupDto customer);
        public Task<IEnumerable<TypeButton>> FetchButtonsTypes();
        public Task<bool> DeleteCustomer(int idCustomer);
        public Task<CustomerForDisplayDto> GetSetupCustomerByUsername(string username);

    }
}
