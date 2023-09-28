using OutboxPattern.Domain.Customer;
using OutboxPattern.Domain.Interfaces;

namespace OutboxPattern.Persistance.EFCore.Repository
{
    public class CustomerRepository(EFCoreDbContext _dbContext) : ICustomerRepository, IBusinessRepository
    {
        public async Task AddAsnyc(Customer entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
