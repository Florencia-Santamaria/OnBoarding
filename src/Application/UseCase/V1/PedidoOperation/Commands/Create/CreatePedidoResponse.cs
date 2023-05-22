using System;

namespace onboardingback.Application.UseCase.V1.PersonOperation.Commands.Create
{
    public record struct CreatePedidoResponse(Guid PedidoId, string Message) { }
}
