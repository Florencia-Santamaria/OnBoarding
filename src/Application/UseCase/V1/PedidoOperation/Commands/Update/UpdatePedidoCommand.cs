using Andreani.ARQ.AMQStreams.Interface;
using Andreani.ARQ.Core.Interface;
using Andreani.ARQ.Pipeline.Clases;
using Andreani.Scheme.Onboarding;
using MediatR;
using Microsoft.Extensions.Logging;
using onboarding_backend.Domain.Enums;
using onboardingback.Domain.Common;
using onboardingback.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace onboardingback.Application.UseCase.V1.PedidoOperation.Commands.Update
{
    public class UpdatePedidoCommand : IRequest<SavePedido>
    {
        public Andreani.Scheme.Onboarding.Pedido Pedido { get; set; }

    }

    public class UpdatePedidoHandler : IRequestHandler<UpdatePedidoCommand, SavePedido>
    {
        private readonly ITransactionalRepository _repository;
        private readonly IReadOnlyQuery _query;
        private readonly ILogger<UpdatePedidoHandler> _logger;

        public UpdatePedidoHandler(ITransactionalRepository repository, IReadOnlyQuery query, ILogger<UpdatePedidoHandler> logger)
        {
            _repository = repository;
            _query = query;
            _logger = logger;
        }

        public async Task<SavePedido> Handle(UpdatePedidoCommand request, CancellationToken cancellationToken)
        {
            Andreani.Scheme.Onboarding.Pedido pedidoActualizado = request.Pedido;

            var pedidoEntidad = new onboardingback.Domain.Entities.Pedido()
            { id = Guid.Parse(pedidoActualizado.id),
                numeroDePedido = pedidoActualizado.numeroDePedido,
                cicloDelPedido = pedidoActualizado.cicloDelPedido,
                codigoDeContratoInterno = pedidoActualizado.codigoDeContratoInterno,
                estadoDelPedido = 2,
                cuentaCorriente = (int)pedidoActualizado.cuentaCorriente,
                cuando = DateTime.Parse(pedidoActualizado.cuando)
            };

                
            _repository.Update(pedidoActualizado);
                
            await _repository.SaveChangeAsync();

            return new SavePedido();
            
        }
    }

   public class SavePedido 
    {
    }
}
