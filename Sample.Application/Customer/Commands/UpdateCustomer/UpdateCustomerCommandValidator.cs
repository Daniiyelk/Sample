using FluentValidation;

namespace Sample.Application.Customer.Commands.UpdateCustomer;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
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
