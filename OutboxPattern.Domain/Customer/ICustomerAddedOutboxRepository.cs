﻿using OutboxPattern.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutboxPattern.Domain.Customer
{
    public interface ICustomerAddedOutboxRepository : IBusinessRepository
    {
        Task AddAsnyc(CustomerAddedOutbox entity);
        Task<List<CustomerAddedOutbox>> GetAsnyc();
    }
}
