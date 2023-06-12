using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Andreani.ARQ.AMQStreams.Interface;
using Andreani.Scheme.Onboarding;
using onboardingback.Application.UseCase.V1.PedidoOperation.Commands.Update;

namespace Api.Services
{
    public class Subscriber : ISubscriber
    {
        private ILogger<Subscriber> _logger;
        private Andreani.ARQ.AMQStreams.Interface.IPublisher _publisher;
        private readonly ISender _mediator;

        public Subscriber(ILogger<Subscriber> logger, Andreani.ARQ.AMQStreams.Interface.IPublisher publisher, ISender mediator)
        {
            _logger = logger;
            _publisher = publisher;
            _mediator = mediator;
        }
       
        public async Task RecivePedidoCreado(Pedido @event)
        {
           await _mediator.Send(new UpdatePedidoCommand() { Pedido = @event });
        }

    }
}

//Suscriptor de eventos, usa el ILogger. Cuando se invoca el método ReciveCustomEvent se envia un mensaje
