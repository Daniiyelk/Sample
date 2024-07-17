using MediatR;
using Sample.Application.Common;
using Sample.Application.Dtos;

namespace Sample.Application.Customer.Commands.CreateCustomer;

public record CreateCustomerCommand(CustomerDto model) : IRequest<Response<bool>>;
