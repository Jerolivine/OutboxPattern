using OutboxPattern.Application.Contract.Customer;
using OutboxPattern.Application.Core.Interfaces;
using OutboxPattern.Application.Interfaces;
using OutboxPattern.Constants.Constants;
using OutboxPattern.Domain.Customer;
using OutboxPattern.Shared;
using System.Text.Json;

namespace OutboxPattern.Application.Services
{
    public class CustomerService(ICustomerRepository _repository, ICustomerAddedOutboxRepository _customerAddedOutboxRepository) : ICustomerService, IBusinessService
    {

        public async Task AddAsnyc(CustomerDto entity)
        {
            // make transaction 

            await _repository.AddAsnyc(MapToEntity(entity));

            await _customerAddedOutboxRepository.AddAsnyc(new CustomerAddedOutbox()
            {
                ExchangeName = ExchangeNameConstants.EXCHANGE_CUSTOMER_ADDED,
                Payload = JsonSerializer.Serialize(new CustomerAddedRequest()
                {
                    Id = entity.Id,
                    UserName = entity.UserName
                }),
                EventType = CustomerAddedRequest.GetTypeName()
            });
        }

        private static Customer MapToEntity(CustomerDto entity)
        {
            return new Customer()
            {
                Id = entity.Id,
                UserName = entity.UserName,
            };
        }
    }
}
