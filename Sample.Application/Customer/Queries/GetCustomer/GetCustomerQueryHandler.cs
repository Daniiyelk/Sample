using MediatR;
using Microsoft.Extensions.Logging;
using Sample.Application.Common;

namespace Sample.Application.Customer.Queries.GetCustomer;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Response<Domain.Entities.Customer>>
{
    private readonly IApplicationUnitOfWork unitOfWork;
    private readonly ILogger<GetCustomerQueryHandler> logger;
    public GetCustomerQueryHandler(IApplicationUnitOfWork unitOfWork, ILogger<GetCustomerQueryHandler> logger)
    {
        this.unitOfWork = unitOfWork;
        this.logger = logger;
    }

    public async Task<Response<Domain.Entities.Customer>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var queryRepo = unitOfWork.QueryRepository<Domain.Entities.Customer>();
            var res = await queryRepo.GetByIdAsync(request.Id);
            if (res is null)
                return new Response<Domain.Entities.Customer>("NotFound");
            return new Response<Domain.Entities.Customer>(res);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return new Response<Domain.Entities.Customer>(ex.Message);
        }
    }
}
