using MediatR;
using Sample.Application.Common;
using Sample.Application.Dtos;

namespace Sample.Application.Customer.Commands.UpdateCustomer;

public record UpdateCustomerCommand(Guid Id, CustomerDto model) : IRequest<Response<bool>>;
