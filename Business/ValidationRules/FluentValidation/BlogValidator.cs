using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(b => b.Title).NotEmpty();
            RuleFor(b => b.Title).MaximumLength(100);
            RuleFor(b => b.Title).MinimumLength(2);

            RuleFor(b => b.Content).NotEmpty();
            RuleFor(b => b.Content).MinimumLength(100);

            RuleFor(b => b.Image).NotEmpty();
        }
    }
}
