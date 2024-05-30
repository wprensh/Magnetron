using FluentValidation;
using POS.Aplication.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Aplication.Validators.Producto
{
    public class FacturaValidatos : AbstractValidator<FacturaRequestDto>
    {
        public FacturaValidatos()
        {
            RuleFor(x => x.fenc_numero)
            .NotNull().WithMessage("El campo numero de factura no pude ser nulo.")
            .NotEmpty().WithMessage("El campo numero de factura no pude ser vacio.");
        }
    }
}
