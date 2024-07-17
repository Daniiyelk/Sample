using MediatR;
using Sample.Application.Common;

namespace Sample.Application.Customer.Commands.DeleteCustomer;

public record DeleteCustomerCommand(Guid Id) : IRequest<Response<bool>>;
