using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Sample.Application.Common;

namespace Sample.Application.Customer.Commands.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<bool>>
{
    private readonly IApplicationUnitOfWork _unitOfWork;
    private readonly IMapper mapper;
    private readonly ILogger<CreateCustomerCommandHandler> logger;

    public CreateCustomerCommandHandler(IApplicationUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateCustomerCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<Response<bool>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var repo = _unitOfWork.CommandRepository<Domain.Entities.Customer>();
            var customer = mapper.Map<Domain.Entities.Customer>(request.model);

            repo.Add(customer);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new Response<bool> { Success = true };
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return new Response<bool>(false, false, ex.Message);
        }

    }
}

