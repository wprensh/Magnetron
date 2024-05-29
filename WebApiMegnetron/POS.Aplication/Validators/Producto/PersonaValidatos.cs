using FluentValidation;
using POS.Aplication.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Aplication.Validators.Producto
{
    public class PersonaValidatos:AbstractValidator<PersonaRequestDto>
    {
        public PersonaValidatos()
        {
            RuleFor(x => x.per_nombre)
            .NotNull().WithMessage("El campo nombre no pude ser nulo.")
            .NotEmpty().WithMessage("El campo nombre no pude ser vacio.");
        }
    }
}
