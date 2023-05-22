using FluentValidation;
using System;

namespace onboardingback.Application.UseCase.V1.PersonOperation.Commands.Create
{
    public class CreatePedidoValidation : AbstractValidator<CreatePedidoCommand>
    {
        

        public CreatePedidoValidation()
        {
            //RuleFor(x => x.cuentaCorriente)
            //    .Cascade(CascadeMode.Stop)
            //    .GetType()
            //    .WithMessage("Apellido is invalid");

            //RuleFor(x => x.codigoDeContratoInterno)
            //    .Cascade(CascadeMode.Stop)
            //    .
            //    .WithMessage("Nombre is invalid");
        }
    }
}
