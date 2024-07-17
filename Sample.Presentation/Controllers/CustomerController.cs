using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Customer.Commands.CreateCustomer;
using Sample.Application.Customer.Commands.DeleteCustomer;
using Sample.Application.Customer.Commands.UpdateCustomer;
using Sample.Application.Customer.Queries.GetCustomer;
using Sample.Application.Customer.Queries.GetCustomers;
using Sample.Application.Dtos;

namespace Sample.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator mediator;

    public CustomerController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Get All Customer List
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("GetAll")]
    public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
    {
        var res = await mediator.Send(new GetCustomersQuery(), cancellationToken);
        return Ok(res);
    }

    /// <summary>
    /// Get specified Customer by Id
    /// </summary>
    /// <param name="Id">Customer id</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("GetById/{Id}")]
    public async Task<ActionResult> GetById(Guid Id, CancellationToken cancellationToken)
    {
        var res = await mediator.Send(new GetCustomerQuery(Id), cancellationToken);
        return Ok(res);
    }

    /// <summary>
    /// Add new customer
    /// </summary>
    /// <param name="model">customer model to add</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("Add")]
    public async Task<ActionResult> Add(CustomerDto model, CancellationToken cancellationToken)
    {
        var res = await mediator.Send(new CreateCustomerCommand(model), cancellationToken);
        return Ok(res);
    }

    /// <summary>
    /// Update customer
    /// </summary>
    /// <param name="Id">Customer id to Update</param>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("Update/{Id}")]
    public async Task<ActionResult> Update(Guid Id, CustomerDto model, CancellationToken cancellationToken)
    {
        var res = await mediator.Send(new UpdateCustomerCommand(Id, model), cancellationToken);
        return Ok(res);
    }

    /// <summary>
    /// Delete customer
    /// </summary>
    /// <param name="Id"> Customer id to Delete</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("Delete/{Id}")]
    public async Task<ActionResult> Delete(Guid Id, CancellationToken cancellationToken)
    {
        var res = await mediator.Send(new DeleteCustomerCommand(Id), cancellationToken);
        return Ok(res);
    }
}
