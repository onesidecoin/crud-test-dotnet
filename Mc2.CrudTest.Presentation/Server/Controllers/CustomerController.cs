using Mc2.CrudTest.Presentation.Application.Customers.Commands.CreateCustomer;
using Mc2.CrudTest.Presentation.Application.Customers.Commands.DeleteCustomer;
using Mc2.CrudTest.Presentation.Application.Customers.Commands.EditCustomer;
using Mc2.CrudTest.Presentation.Application.Customers.Queries.GetAll;
using Mc2.CrudTest.Presentation.Application.Customers.Queries.GetCusomers;
using Mc2.CrudTest.Presentation.Application.Customers.Queries.GetCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/{action}")]
    public class CustomerController : ControllerBase
    {

        private readonly ISender _sender;

        public CustomerController(ISender sender)
        {
            _sender=sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _sender.Send(new GetAllCustomersQuery());;
            return Ok(result);
        }     
        
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] GetCustomerByIdQuery getCustomerByIdQuery)
        {
            var result = await _sender.Send(getCustomerByIdQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIds([FromBody] GetCustomersQuery getCustomersQuery)
        {
            var result = await _sender.Send(getCustomersQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand createCustomerCommand)
        {
            var result = await _sender.Send(createCustomerCommand);

            if (!result.IsSuccessful)
                return BadRequest(result.ErrorMessage);

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCustomerCommand editCustomerCommand)
        {
            var result = await _sender.Send(editCustomerCommand);

            if (!result.IsSuccessful)
                return BadRequest(result.ErrorMessage);

            return Ok(result.Data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteCustomerCommand deleteCustomerCommand)
        {
            var result = await _sender.Send(deleteCustomerCommand);

            if (!result.IsSuccessful)
                return BadRequest(result.ErrorMessage);

            return Ok(result.Data);
        }
    }
}
