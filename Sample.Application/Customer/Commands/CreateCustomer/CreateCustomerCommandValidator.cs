using FluentValidation;

namespace Sample.Application.Customer.Commands.CreateCustomer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(c => c.model.PhoneNumber)
             .Matches(@"^(\+98|0)?9\d{9}$")
             .WithMessage("Invalid phone number format. Phone number must be 11 digits.");

        RuleFor(c => c.model.Email)
            .EmailAddress()
            .WithMessage("Invalid email format.");

        RuleFor(c => c.model.BankAccountNumber)
            .Must(BeAValidBankAccount)
            .WithMessage("Invalid bank account number format.");
    }
    private bool BeAValidBankAccount(string bankAccountNumber)
    {
        // Some Code to validate the bankAccountNumber

        return true;
    }
}
