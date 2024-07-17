using FluentValidation;

namespace Sample.Application.Customer.Queries.GetCustomer;

public class GetCustomerQueryValidator : AbstractValidator<GetCustomerQuery>
{
    public GetCustomerQueryValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage("This field is Required");
    }
}
