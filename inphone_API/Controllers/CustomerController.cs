using inphone_API.Dtos;
using inphone_API.Model;
using inphone_API.Repositories.customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerRepositories _customerRepositories;

        public CustomerController(ILogger<CustomerController> logger, ICustomerRepositories customerRepositories)
        {
            _logger = logger;
            _customerRepositories = customerRepositories;
        }

        [HttpGet("SetupsCustomers")]
        public async Task<IActionResult> GetCustomersList()
        {
            try
            {
                return Ok(await _customerRepositories.GetCustomersList());
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
        }

        [HttpGet("SetupCustomer/{customerId}")]
        public async Task<CustomerForDisplayDto> GetSetupCustomerById(int customerId)
        {
            return await _customerRepositories.GetSetupCustomerById(customerId);
        }

        [HttpPost("SetupNewCustomer")]
        public async Task<bool> SetupNewCustomer(CustomerForSetupDto customer)
        {
            try
            {
                return await _customerRepositories.SetupNewCustomer(customer);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        [HttpPost("EditSetupCustomer")]
        public async Task<bool> EditSetupCustomer(CustomerForSetupDto customer)
        {
            return await _customerRepositories.EditSetupCustomer(customer);
        }

        [HttpGet("ButtonsTypes")]
        public async Task<IEnumerable<TypeButton>> FetchButtonsTypes()
        {
            try
            {
                return await _customerRepositories.FetchButtonsTypes();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        [HttpGet("deleteCustomer/{idCustomer}")]
        public async Task<bool> DeleteCustomer(int idCustomer)
        {
            try
            {
                return await _customerRepositories.DeleteCustomer(idCustomer);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        [HttpGet("setupCustomerByUsername/{username}")]
        public async Task<CustomerForDisplayDto> GetSetupCustomerByUsername(string username)
        {
            try
            {
                return await _customerRepositories.GetSetupCustomerByUsername(username);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        [HttpGet("TesteApi")]
        public IActionResult TesteApi()
        {
            return Ok("Soufiane edit");
        }

    }
}
