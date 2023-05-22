using Andreani.ARQ.Core.Interface;
using Andreani.ARQ.Pipeline.Clases;
using onboardingback.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System;
using onboardingback.Application.UseCase.V1.PersonOperation.Queries.GetList;

namespace onboardingback.Application.UseCase.V1.PersonOperation.Commands.Create
{
    public class CreatePedidoCommand : IRequest<Response<CreatePedidoResponse>>
    {
        public int cuentaCorriente { get; set; }

        public Int64 codigoDeContratoInterno { get; set; }
      
    }

    public class CreatePedidoCommandHandler : IRequestHandler<CreatePedidoCommand, Response<CreatePedidoResponse>>
    {
        private readonly ITransactionalRepository _repository;
        private readonly ILogger<CreatePedidoCommandHandler> _logger;

        public CreatePedidoCommandHandler(ITransactionalRepository repository, ILogger<CreatePedidoCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Response<CreatePedidoResponse>> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
        {
            var entity = new Pedido
            {
                cuentaCorriente = request.cuentaCorriente,
                codigoDeContratoInterno = request.codigoDeContratoInterno, 
                cuando = DateTime.Now,
                numeroDePedido = null,
                id=Guid.NewGuid(),
                estadoDelPedido= 1
                
            };

            entity.cicloDelPedido = entity.id.ToString();
            _repository.Insert(entity);
            await _repository.SaveChangeAsync();
            _logger.LogDebug("El pedido se agregó correctamente");

            return new Response<CreatePedidoResponse>
            {
                Content = new CreatePedidoResponse
                {
                    Message = "Success",
                    PedidoId = entity.id
                },
                StatusCode = System.Net.HttpStatusCode.Created
            };
        }
    }
}
