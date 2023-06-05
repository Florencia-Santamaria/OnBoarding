using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Andreani.ARQ.AMQStreams.Interface;
using Andreani.Scheme.Onboarding;

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
        public async Task ReciveCustomEvent(Pedido @event)
        {
            // enviar el evento 
            await _mediator.Send(@event);
        }

        public async Task RecivePedidoCreado(Pedido @event)
        {
           
        }

    }
}

//Suscriptor de eventos, usa el ILogger. Cuando se invoca el método ReciveCustomEvent se envia un mensaje
