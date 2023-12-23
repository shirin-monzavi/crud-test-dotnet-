using Castle.Windsor;
using Castle.Windsor.Extensions.DependencyInjection;
using Infrastructure;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContextFactory<CustomerDbContext>((sp, ob) =>
{
    ob.UseSqlServer("Server=.;Initial Catalog=CustomerDb;Integrated Security=true;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");
}, ServiceLifetime.Scoped);

//Castle
builder.Host.UseServiceProviderFactory(new WindsorServiceProviderFactory());

builder.Host.ConfigureContainer<WindsorContainer>(c =>
{
    c.WindsorDependencyHolder();
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
