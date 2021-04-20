using AutoMapper;
using AutoMapper.QueryableExtensions;
using inphone_API.Dtos;
using inphone_API.Infrastructure;
using inphone_API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inphone_API.Repositories.customer
{
    public class CustomerRepositories : ICustomerRepositories
    {
        private readonly AppDbContext _AppDbContext;
        private readonly IMapper _mapper;

        public CustomerRepositories(AppDbContext appDbContext, IMapper mapper)
        {
            _AppDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerForDisplayDto>> GetCustomersList()
        {
            try
            {
                var customers = await _AppDbContext.Customer
                                     //.Include(x => x.Buttons)
                                     //.ThenInclude(x => x.TypeButton)
                                     .ProjectTo<CustomerForDisplayDto>(_mapper.ConfigurationProvider)
                                     .ToListAsync();
                return customers;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        
        public async Task<CustomerForDisplayDto> GetSetupCustomerById(int idCustomer)
        {
            return await _AppDbContext.Customer
                                      //.Include(x => x.Buttons)
                                      //.ThenInclude(x => x.TypeButton)
                                      .ProjectTo<CustomerForDisplayDto>(_mapper.ConfigurationProvider)
                                      .SingleOrDefaultAsync(x => x.IdCustomer == idCustomer);
        }

        public async Task<bool> SetupNewCustomer(CustomerForSetupDto customer)
        {

            var CustomerToSetup = new Customer
            {
                UserName = Guid.NewGuid().ToString("N"),
                Password = "ToDo: Generate hashed password",
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                CompanyName = customer.CompanyName,
                Email = customer.Email,
                Phone = customer.Phone,
                Logo1 = customer.Logo1,
                Logo2 = customer.Logo2,
                Logo3 = customer.Logo3,
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                Buttons = customer.Buttons.Select(btn => new Button
                {
                    Label = btn.Label,
                    Description = btn.Description,
                    Content = btn.Content,
                    Type = btn.Type,
                    LastModificationDate = DateTime.Now,
                }).ToList(),
            };

            _AppDbContext.Customer.Add(CustomerToSetup);
            return await _AppDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> EditSetupCustomer(CustomerForSetupDto customer)
        {
            var customerInDb = await _AppDbContext.Customer.Include(x => x.Buttons).SingleOrDefaultAsync(x => x.IdCustomer == customer.IdCustomer);
            if (customerInDb == null) return false;

            customerInDb.FirstName = customer.FirstName;
            customerInDb.LastName = customer.LastName;
            customerInDb.CompanyName = customer.CompanyName;
            customerInDb.Email = customer.Email;
            customerInDb.Phone = customer.Phone;
            customerInDb.Logo1 = customer.Logo1;
            customerInDb.Logo2 = customer.Logo2;
            customerInDb.Logo3 = customer.Logo3;
            customerInDb.LastModificationDate = DateTime.Now;
            customerInDb.Buttons = customer.Buttons.Select(btn => new Button
            {
                Label = btn.Label,
                Description = btn.Description,
                Content = btn.Content,
                Type = btn.Type,
                LastModificationDate = DateTime.Now,
            }).ToList();

            var entityTraking = _AppDbContext.Customer.Attach(customerInDb);
            entityTraking.State = EntityState.Modified;
            return await _AppDbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<TypeButton>> FetchButtonsTypes()
        {
            return await _AppDbContext.TypeButton.ToListAsync();
        }

        public async Task<bool> DeleteCustomer(int idCustomer)
        {
            var customerToDelete = _AppDbContext.Customer.SingleOrDefault(x => x.IdCustomer == idCustomer);
            _AppDbContext.Customer.Remove(customerToDelete);
            return await _AppDbContext.SaveChangesAsync() > 0;
        }

        public async Task<CustomerForDisplayDto> GetSetupCustomerByUsername(string username)
        {
            return await _AppDbContext.Customer
                          .ProjectTo<CustomerForDisplayDto>(_mapper.ConfigurationProvider)
                          .SingleOrDefaultAsync(x => x.UserName == username);
        }
    }
}
