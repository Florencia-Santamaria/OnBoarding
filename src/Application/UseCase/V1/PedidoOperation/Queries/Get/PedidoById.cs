using Andreani.ARQ.Core.Interface;
using Andreani.ARQ.Pipeline.Clases;
using onboardingback.Domain.Dtos;
using onboardingback.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using onboarding_backend.Domain.Enums;
using onboarding_backend.Domain.Entities;
using System;

namespace onboardingback.Application.UseCase.V1.PedidoOperation.Queries.Get {

  public class PedidoById : IRequest<Response<PedidoDto>> //salida del request
  {
   
        public Guid id { get; set; }

        public PedidoById(Guid pedidoId)
        {

            id = pedidoId;
        }

    }

    public class PedidoByIdHandler : IRequestHandler<PedidoById, Response<PedidoDto>>
  {
    private readonly IReadOnlyQuery _query; //inyecta las consultas que hace la bdd

    public PedidoByIdHandler(IReadOnlyQuery query)
    {
      _query = query;
    }

    public async Task<Response<PedidoDto>> Handle(PedidoById request, CancellationToken cancellationToken)
    {
        var result = await _query.GetByIdAsync<Pedido>(request.id);

                var pedido = new PedidoDto
                {
                    id = result.id,
                    numeroDePedido = result.numeroDePedido,
                    cicloDelPedido = result.cicloDelPedido,
                    codigoDeContactoInterno = result.codigoDeContratoInterno,
                    estadoDelPedido = result.estadoDelPedido,
                    cuentaCorriente = result.cuentaCorriente,
                    cuando = result.cuando
                };  

          return new Response<PedidoDto>
          {
            Content = pedido,
            StatusCode = System.Net.HttpStatusCode.OK
          };
    }
  }
}
