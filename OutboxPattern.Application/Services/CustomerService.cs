using OutboxPattern.Application.Contract.Customer;
using OutboxPattern.Application.Core.Interfaces;
using OutboxPattern.Application.Interfaces;
using OutboxPattern.Domain.Customer;

namespace OutboxPattern.Application.Services
{
    public class CustomerService : ICustomerService, IBusinessService
    {
        public ICustomerRepository _repository { get; set; }

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsnyc(CustomerDto entity)
        {
            await _repository.AddAsnyc(new Customer()
            {
                Id = entity.Id,
                UserName = entity.UserName,
            });

        }
    }
}
