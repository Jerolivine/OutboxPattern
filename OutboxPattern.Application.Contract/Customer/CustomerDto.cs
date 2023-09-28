using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutboxPattern.Application.Contract.Customer
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
