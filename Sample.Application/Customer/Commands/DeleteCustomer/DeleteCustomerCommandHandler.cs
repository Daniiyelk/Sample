using MediatR;
using Microsoft.Extensions.Logging;
using Sample.Application.Common;

namespace Sample.Application.Customer.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Response<bool>>
{
    private readonly IApplicationUnitOfWork _unitOfWork;
    private readonly ILogger<DeleteCustomerCommandHandler> logger;
    public DeleteCustomerCommandHandler(IApplicationUnitOfWork unitOfWork, ILogger<DeleteCustomerCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        this.logger = logger;
    }

    public async Task<Response<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var repo = _unitOfWork.CommandRepository<Domain.Entities.Customer>();
            await repo.DeleteByIdAsync(request.Id);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new Response<bool>(true);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return new Response<bool>(false, false, ex.Message);
        }
    }
}

