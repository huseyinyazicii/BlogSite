using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(m => m.UserName).NotEmpty();
            RuleFor(m => m.UserName).MaximumLength(50);
            RuleFor(m => m.UserName).MinimumLength(2);

            RuleFor(m => m.UserEmail).NotEmpty();
            RuleFor(m => m.UserEmail).MaximumLength(50);
            RuleFor(m => m.UserEmail).MinimumLength(2);
            RuleFor(m => m.UserEmail).EmailAddress();

            RuleFor(m => m.UserPhone).NotEmpty();
            RuleFor(m => m.UserPhone).MaximumLength(11);
            RuleFor(m => m.UserPhone).MinimumLength(11);

            RuleFor(m => m.UserMessage).NotEmpty();
            RuleFor(m => m.UserMessage).MaximumLength(500);
            RuleFor(m => m.UserMessage).MinimumLength(10);

            RuleFor(m => m.Title).NotEmpty();
            RuleFor(m => m.Title).MaximumLength(50);
            RuleFor(m => m.Title).MinimumLength(3);
        }
    }
}
