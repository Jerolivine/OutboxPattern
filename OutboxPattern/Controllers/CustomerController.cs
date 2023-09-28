using Microsoft.AspNetCore.Mvc;
using OutboxPattern.Application.Contract.Customer;
using OutboxPattern.Application.Interfaces;
using OutboxPattern.Domain.Customer;
using OutboxPattern.Domain.Interfaces;

namespace OutboxPattern.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public ICustomerService _service { get; set; }

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CustomerDto customerDto)
        {
            Validation(customerDto);

            await _service.AddAsnyc(customerDto);

            return Ok();
        }

        private static void Validation(CustomerDto customerDto)
        {
            if (customerDto is null)
            {
                throw new Exception("CustomerDto cannot be null");
            }
        }
    }
}
