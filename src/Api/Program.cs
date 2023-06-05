using Andreani.ARQ.WebHost.Extension;
using onboardingback.Application;
using onboardingback.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Andreani.ARQ.AMQStreams.Extensions;
using Andreani.Scheme.Onboarding;
using Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAndreaniWebHost(args);
builder.Services.ConfigureAndreaniServices();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddKafka(builder.Configuration)
    .CreateOrUpdateTopic(6, "PedidoCreado1")
    .ToProducer<Pedido>("PedidoCreado1")
    .ToConsumer <Subscriber,Pedido>("PedidoAsignado1")
    .Build();

var app = builder.Build();

app.ConfigureAndreani();

app.Run();
