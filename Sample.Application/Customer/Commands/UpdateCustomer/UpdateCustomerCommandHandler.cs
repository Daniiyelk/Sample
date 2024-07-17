using MediatR;
using Microsoft.Extensions.Logging;
using Sample.Application.Common;

namespace Sample.Application.Customer.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Response<bool>>
{
    private readonly IApplicationUnitOfWork unitOfWork;
    private readonly ILogger<UpdateCustomerCommandHandler> logger;
    public UpdateCustomerCommandHandler(IApplicationUnitOfWork unitOfWork, ILogger<UpdateCustomerCommandHandler> logger)
    {
        this.unitOfWork = unitOfWork;
        this.logger = logger;
    }

    public async Task<Response<bool>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var commandRepo = unitOfWork.CommandRepository<Domain.Entities.Customer>();
            var queryRepo = unitOfWork.QueryRepository<Domain.Entities.Customer>();
            var customer = await queryRepo.GetByIdAsync(request.Id);
            if (customer == null)
                return new Response<bool>(false, false, "Customer NotFount");

            // update Customer fields
            customer.FirstName = request.model.FirstName;
            customer.LastName = request.model.LastName;
            customer.Email = request.model.Email;
            customer.DateOfBirth = request.model.DateOfBirth;
            customer.PhoneNumber = request.model.PhoneNumber;
            customer.BankAccountNumber = request.model.BankAccountNumber;

            commandRepo.Update(customer);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return new Response<bool>(true);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return new Response<bool>(false, false, ex.Message);
        }
    }
}

