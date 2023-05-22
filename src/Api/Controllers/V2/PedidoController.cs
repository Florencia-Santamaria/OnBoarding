using Andreani.ARQ.Pipeline.Clases;
using Andreani.ARQ.WebHost.Controllers;
using onboardingback.Application.UseCase.V1.PersonOperation.Queries.GetList;
using onboardingback.Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace WebApi.Controllers.V2;

[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]

public class PedidosController : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<PedidoDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get([FromQuery] Guid id) => this.Result(await Mediator.Send(new PedidoById(id)));



}
