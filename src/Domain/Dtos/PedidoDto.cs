using onboarding_backend.Domain.Entities;
using onboarding_backend.Domain.Enums;
using onboardingback.Domain.Enums;
using System;

namespace onboardingback.Domain.Dtos;

public record struct PedidoDto(
        Guid id,
        int? numeroDePedido,
        string cicloDelPedido,
        Int64? codigoDeContactoInterno,
        int? estadoDelPedido,
        int? cuentaCorriente,
        DateTime cuando
        ) { }
