using OutboxPattern.Application.Contract.Customer;

namespace OutboxPattern.Application.Interfaces
{
    public interface ICustomerService
    {
        Task AddAsnyc(CustomerDto entity);

    }
}
