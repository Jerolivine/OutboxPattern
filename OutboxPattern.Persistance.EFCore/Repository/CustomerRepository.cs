using OutboxPattern.Domain.Customer;

namespace OutboxPattern.Persistance.EFCore.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public EFCoreDbContext _dbContext { get; set; }
        public CustomerRepository(EFCoreDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task AddAsnyc(Customer entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
