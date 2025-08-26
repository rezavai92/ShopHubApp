using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Shophub.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Register Autofac as the dependency injection container
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    using var scanner = new DependencyRegistrarScanner();
    var registrarPaths = DependencyRegistrarScanner.LocateRegistrars();
    foreach (var registrarPath in registrarPaths)
    {   
        containerBuilder.RegisterAssemblyModules(Assembly.LoadFrom(registrarPath));
    }
});

builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
