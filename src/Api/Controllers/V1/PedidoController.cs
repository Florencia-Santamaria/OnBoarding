using Andreani.ARQ.Pipeline.Clases;
using Andreani.ARQ.WebHost.Controllers;
using onboardingback.Application.UseCase.V1.PersonOperation.Commands.Create;
using onboardingback.Application.UseCase.V1.PersonOperation.Queries.GetList;
using onboardingback.Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace WebApi.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class PedidoController : ApiControllerBase
{
    /// <summary>
    /// Creación de un nuevo pedido
    /// </summary>
    /// <param name="body"></param>
    /// <returns></returns>
    
    [HttpPost]
    [ProducesResponseType(typeof(CreatePedidoResponse), StatusCodes.Status201Created)] //documentacion
    [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)] //documentacion
    public async Task<IActionResult> Create(CreatePedidoCommand body) => Result(await Mediator.Send(body));

    /// <summary>
    /// Listado de pedidos de la base de datos
    /// </summary>
    /// <remarks>en los remarks podemos documentar información más detallada</remarks>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PedidoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(Guid id) => Result(await Mediator.Send(new PedidoById(id)));


}
