using Andreani.ARQ.Core.Interface;
using Andreani.ARQ.Pipeline.Clases;
using Elastic.Apm.Api;
using Moq;
using onboardingback.Application.UseCase.V1.PedidoOperation.Queries.Get;
//using onboardingback.Application.UseCase.V1.PersonOperation.Queries.GetList;
using onboardingback.Domain.Dtos;
using onboardingback.Domain.Entities;
using System.Threading;


namespace Application.Test
{
    public class PedidoByIdTest
    {
        [Fact]
        public async void Handle_ValidRequest_ResponsePedidoDto()
        {
            //Arrange
            var queryMock = new Mock<IReadOnlyQuery>();
            var handler = new PedidoByIdHandler(queryMock.Object);
            var id = new Guid();
            var request = new PedidoById(id);

            var pedido = new Pedido
            {
                id = id,
                numeroDePedido = 123,
                cicloDelPedido=id.ToString(),
                codigoDeContratoInterno=123456789,
                estadoDelPedido=1,
                cuentaCorriente=1234,
                cuando= DateTime.Now

            };

            queryMock.Setup(q => q.GetByIdAsync<Pedido>(id)).ReturnsAsync(pedido);

            //Act
            var resultado = await handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.NotNull(resultado);

        }
    }
}