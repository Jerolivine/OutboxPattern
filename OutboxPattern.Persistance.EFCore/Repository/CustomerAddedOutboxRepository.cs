using Microsoft.EntityFrameworkCore;
using OutboxPattern.Domain.Customer;
using OutboxPattern.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutboxPattern.Persistance.EFCore.Repository
{
    public class CustomerAddedOutboxRepository(EFCoreDbContext _dbContext) : ICustomerAddedOutboxRepository, IBusinessRepository
    {
        public async Task AddAsnyc(CustomerAddedOutbox entity)
        {
            await _dbContext.CustomerAddedOutbox.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<CustomerAddedOutbox>> GetAsnyc() 
            => await _dbContext.CustomerAddedOutbox.AsQueryable().OrderByDescending(x => x.TimeStamp).Take(20).ToListAsync();
    }
}
