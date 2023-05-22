using onboarding_backend.Domain.Enums;
using System;

namespace onboardingback.Domain.Entities;


public class Pedido
{
    public Guid id { get; set; }
    public int? numeroDePedido { get; set; }
    public string cicloDelPedido { get; set; }
    public Int64 codigoDeContratoInterno { get; set; }
    public int? estadoDelPedido { get; set; }
    public int cuentaCorriente { get; set; }
    public DateTime cuando { get; set; }
}
