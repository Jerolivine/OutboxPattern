using OutboxPattern.Application.Contract.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutboxPattern.Application.Interfaces
{
    public interface ICustomerAddedOutboxService
    {
        Task AddAsnyc(CustomerAddedOutboxDto entity);
    }
}
