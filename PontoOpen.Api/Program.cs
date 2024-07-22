using dotenv.net;
using PontoOpen.Api.Config;
using PontoOpen.IoC.Infrastructure;
using PontoOpen.IoC.Application;
using PontoOpen.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load();

var connectionString = VariaveisDeAmbiente.GetVariavel("STRING_CONNECTION");
var urlDiscord = VariaveisDeAmbiente.GetVariavel("URL_DISCORD");

builder.Services
    .ConfigureController()
    .InjectContext(connectionString)
    .InjectRepositories()
    .InjectServices()
    .InjectHttpDiscord(urlDiscord);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddMiddlewaresApi();

app.UseAuthorization();

app.MapControllers();

app.Run();
