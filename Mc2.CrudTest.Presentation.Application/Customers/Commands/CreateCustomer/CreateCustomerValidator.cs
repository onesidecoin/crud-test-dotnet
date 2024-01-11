using FluentValidation;
using Mc2.CrudTest.Presentation.Domain.Constants;
using Mc2.CrudTest.Presentation.Shared.Helpers;

namespace Mc2.CrudTest.Presentation.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(v => v.Firstname)
            .MaximumLength(EntityConfigurationConsts.FirstnameMaxLength)
            .NotEmpty();          
            
            RuleFor(v => v.Lastname)
            .MaximumLength(EntityConfigurationConsts.LastnameMaxLength)
            .NotEmpty();

            RuleFor(v => v.PhoneNumber)
            .NotEmpty()
            .Must(ValidationHelper.BeValidPhoneNumber)
            .MaximumLength(EntityConfigurationConsts.PhoneNumberMaxLength);

            RuleFor(v => v.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(EntityConfigurationConsts.EmailMaxLength);
            
            RuleFor(v => v.BankAccountNumber)
            .GreaterThan(0);
        }

    }

}
