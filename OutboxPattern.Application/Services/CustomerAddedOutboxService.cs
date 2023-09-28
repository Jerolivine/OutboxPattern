using OutboxPattern.Application.Contract.Customer;
using OutboxPattern.Application.Core.Interfaces;
using OutboxPattern.Application.Interfaces;
using OutboxPattern.Domain.Customer;

namespace OutboxPattern.Application.Services
{
    public class CustomerAddedOutboxService(ICustomerAddedOutboxRepository _repository) : ICustomerAddedOutboxService, IBusinessService
    {
        public async Task AddAsnyc(CustomerAddedOutboxDto entity)
        {
            await _repository.AddAsnyc(MapToEntity(entity));
        }

        private static CustomerAddedOutbox MapToEntity(CustomerAddedOutboxDto entity)
        {
            return new CustomerAddedOutbox()
            {
                EventId = entity.EventId,
                EventStatus = entity.EventStatus,
                EventType = entity.EventType,
                ExchangeName = entity.ExchangeName,
                Payload = entity.Payload
            };
        }
    }
}
