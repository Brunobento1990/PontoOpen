using dotenv.net;
using PontoOpen.Api.Config;
using PontoOpen.IoC.Infrastructure;
using PontoOpen.IoC.Application;
using PontoOpen.Api.Middlewares;
using PontoOpen.Infrastructure.Models;

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load();

var connectionString = VariaveisDeAmbiente.GetVariavel("STRING_CONNECTION");
var urlDiscord = VariaveisDeAmbiente.GetVariavel("URL_DISCORD");
var urlApiGoogle = VariaveisDeAmbiente.GetVariavel("URL_API_GOOGLE");
var configGoogle = new ConfiguracaoApiGoogle()
{
    ApiKey = VariaveisDeAmbiente.GetVariavel("KEY_API_GOOGLE")
};

builder.Services
    .AddSingleton(configGoogle)
    .ConfigureController()
    .InjectContext(connectionString)
    .InjectRepositories()
    .InjectServices()
    .InjectHttpDiscord(urlDiscord, urlApiGoogle);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddMiddlewaresApi();

app.UseAuthorization();

app.UseCors("base");

app.MapControllers();

app.Run();
