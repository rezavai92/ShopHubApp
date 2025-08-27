using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Shophub.Server;
using ShopHub.SecondaryPorts.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Register Autofac as the dependency injection container
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");

    containerBuilder.Register(c =>
    {
        var optionsBuilder = new DbContextOptionsBuilder<SqlApplicationDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new SqlApplicationDbContext(optionsBuilder.Options);
    }).As<SqlApplicationDbContext>()
    .InstancePerLifetimeScope();

    using var scanner = new DependencyRegistrarScanner();
    var registrarPaths = DependencyRegistrarScanner.LocateRegistrars();
    foreach (var registrarPath in registrarPaths)
    {
        containerBuilder.RegisterAssemblyModules(Assembly.LoadFrom(registrarPath));
    }
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseCors("AllowAll");
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
