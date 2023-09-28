using OutboxPattern.Domain.Interfaces;

namespace OutboxPattern.Domain.Customer
{
    public interface ICustomerRepository : IBusinessRepository
    {
        Task AddAsnyc(Customer entity);

    }
}
