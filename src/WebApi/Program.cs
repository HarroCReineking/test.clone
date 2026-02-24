using System.Diagnostics.CodeAnalysis;
using TestClone.DomainApi.Interfaces;

namespace TestClone.WebApi
{
    [ExcludeFromCodeCoverage]
    public partial class Program
    {
        private static void Main(string[] args)
        {
            //Create a WebApplication builder and add services to the container. Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddOpenApi();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IFacade, Facade>();
            //Do all builder stuf before building the app, otherwise you will get an error that the service provider is already built and cannot be modified.
            var app = builder.Build();
            app.MapOpenApi();
            app.UseHttpsRedirection();
            //Map controllers
            app.MapControllers();
            //Create swagger and swagger UI middlewares and run the app
            app.UseSwagger();
            app.UseSwaggerUI();
            app.Run();
        }
    }
}