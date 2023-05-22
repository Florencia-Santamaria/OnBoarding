using AutoFixture;
using FluentAssertions;
using onboardingback.Application.UseCase.V1.PersonOperation.Commands.Create;

namespace Application.Test.PersonOperation.Commands.Create
{
    public class CreatePersonValidationTest
    {
        
        [Fact]
        public async Task Validation_WithPropertyCorrect_IsValidTrue()
        {
            // Arrange
            var request = new Fixture().Create<CreatePedidoCommand>();
            var validator = new CreatePersonValidation();
            // Act
            var result = await validator.ValidateAsync(request);
            // Assert
            result.IsValid.Should().BeTrue();

        }

        [Theory]
        [InlineData("", "test")]
        [InlineData("test", "")]
        [InlineData(null, "test")]
        [InlineData("test",null)]
        [InlineData("","")]
        [InlineData(null,null)]
        public async Task Validation_WithPropertyIncorrect_IsValidFalse(string nombre, string apellido)
        {
            // Arrange
            var request = new CreatePedidoCommand
            {
                Apellido = apellido,
                Nombre = nombre
            };
            var validator = new CreatePersonValidation();
            // Act
            var result = await validator.ValidateAsync(request);
            // Assert
            result.IsValid.Should().BeFalse();
        }
    }
}
