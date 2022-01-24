using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(w => w.FirstName).NotEmpty();
            RuleFor(w => w.FirstName).MaximumLength(50);
            RuleFor(w => w.FirstName).MinimumLength(2);

            RuleFor(w => w.LastName).NotEmpty();
            RuleFor(w => w.LastName).MaximumLength(50);
            RuleFor(w => w.LastName).MinimumLength(2);

            RuleFor(w => w.Email).NotEmpty();
            RuleFor(w => w.Email).MaximumLength(50);
            RuleFor(w => w.Email).MinimumLength(2);
            RuleFor(w => w.Email).EmailAddress();

            RuleFor(w => w.Password).NotEmpty();
            RuleFor(w => w.Password).MaximumLength(50);
            RuleFor(w => w.Password).MinimumLength(6);
        }
    }
}
