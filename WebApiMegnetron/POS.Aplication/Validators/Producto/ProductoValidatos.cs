using FluentValidation;
using POS.Aplication.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Aplication.Validators.Producto
{
    public class ProductoValidatos : AbstractValidator<ProductoRequestDto>
    {
        public ProductoValidatos()
        {
            RuleFor(x => x.pord_desc)
            .NotNull().WithMessage("El campo descripcion no pude ser nulo.")
            .NotEmpty().WithMessage("El campo descripcion no pude ser vacio.");
        }
    }
}
