using MediatR;
using Sample.Application.Common;

namespace Sample.Application.Customer.Queries.GetCustomers;

public record GetCustomersQuery() : IRequest<Response<List<Domain.Entities.Customer>>>;
