using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(c => c.UserName).NotEmpty();
            RuleFor(c => c.UserName).MaximumLength(50);
            RuleFor(c => c.UserName).MinimumLength(2);

            RuleFor(c => c.Content).NotEmpty();
            RuleFor(c => c.Content).MaximumLength(500);
            RuleFor(c => c.Content).MinimumLength(2);
        }
    }
}
