using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppLibros.Core.Entities;

namespace WebAppLibros.Services.Validators
{
    public class LibrosValidator: AbstractValidator<Libros>
    {
        public LibrosValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Classroom MUST have a SchoolId");

        }
    }
}
