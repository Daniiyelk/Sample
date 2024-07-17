using MediatR;
using Sample.Application.Common;

namespace Sample.Application.Customer.Queries.GetCustomer;

public record GetCustomerQuery(Guid Id) : IRequest<Response<Domain.Entities.Customer>>;
