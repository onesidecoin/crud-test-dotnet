using FluentValidation;
using Mc2.CrudTest.Presentation.Application.Customers.Commands.CreateCustomer;
using Mc2.CrudTest.Presentation.Domain.Constants;
using Mc2.CrudTest.Presentation.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Application.Customers.Commands.EditCustomer
{
    public class EditCustomerValidator : AbstractValidator<EditCustomerCommand>
    {
        public EditCustomerValidator()
        {
            RuleFor(v => v.Id)
            .Must(id => id != Guid.Empty);
                     
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
