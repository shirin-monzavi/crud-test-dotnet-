using ApplicationContract;
using ApplicationContract.Commands;
using ApplicationContract.ServiceModels;
using Crud.Presentation.Server.Models;
using Domain.Entity;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Presentation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerCommandHanlder customerCommandHanlder;
        private readonly ICustomerQueryHandler customerQueryHandler;

        public CustomerController(ICustomerCommandHanlder customerCommandHanlder, ICustomerQueryHandler customerQueryHandler)
        {
            this.customerCommandHanlder = customerCommandHanlder;
            this.customerQueryHandler = customerQueryHandler;
        }

        [HttpGet("{id}")]
        public async Task<CustomerVM> Get(Guid id)
        {
            var result = await customerQueryHandler.GetCustomerById(id);

            return result.Adapt<CustomerVM>();
        }


        [HttpGet]
        public async Task<IEnumerable<CustomerVM>> Get()
        {
            var result = await customerQueryHandler.GetCustomers();

            return result.Adapt<IEnumerable<CustomerVM>>();
        }


        [HttpPost]
        public async Task<CustomerVM> Post([FromBody] CustomerVM customer)
        {
            var command = customer.Adapt<AddCustomerCommand>();

            var result = await customerCommandHanlder.AddCommand(command);

            return result.Adapt<CustomerVM>();
        }

        [HttpPut("{id}")]
        public async Task<CustomerVM> Put(Guid id, [FromBody] CustomerVM customer)
        {
            var command = customer.Adapt<UpdateCustomerCommand>();
            command.Id = id;

            await customerCommandHanlder.UpdateCommand(command);

            return customer;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCustomerCommand()
            {
                Id = id
            };

            await customerCommandHanlder.DeleteCommand(command);

            return Ok();
        }

    }
}
