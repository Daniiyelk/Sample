using MediatR;
using Microsoft.Extensions.Logging;
using Sample.Application.Common;

namespace Sample.Application.Customer.Queries.GetCustomers;

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, Response<List<Domain.Entities.Customer>>>
{
    private readonly IApplicationUnitOfWork unitOfWork;
    private readonly ILogger<GetCustomersQueryHandler> logger;
    public GetCustomersQueryHandler(IApplicationUnitOfWork unitOfWork, ILogger<GetCustomersQueryHandler> logger)
    {
        this.unitOfWork = unitOfWork;
        this.logger = logger;
    }

    public async Task<Response<List<Domain.Entities.Customer>>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var queryRepo = unitOfWork.QueryRepository<Domain.Entities.Customer>();
            var res = await queryRepo.GetAllAsync();

            return new Response<List<Domain.Entities.Customer>>(res);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return new Response<List<Domain.Entities.Customer>>(ex.Message);
        }
    }
}
