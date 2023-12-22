using Application;
using ApplicationContract;
using Domain.Contract.Repositories;
using Domain.Contract.Repositories.CustomerCommandRepository;
using Domain.Contract.Repositories.CustomerQueryRepository;
using Infrastructure.DbContexts;
using Infrastructure.Repositories;
using Infrastructure.Repositories.CustomerCommandRepository;
using Infrastructure.Repositories.CustomerQueryRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContextFactory<CustomerDbContext>((sp, ob) =>
{
    ob.UseSqlServer("Server=.;Initial Catalog=CustomerDb;Integrated Security=true;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");
}, ServiceLifetime.Scoped);

builder.Services.AddScoped<ICustomerCommandHanlder, CustomerCommandHandler>();
builder.Services.AddScoped<ICustomerQueryHandler, CustomerQueryHandler>();

builder.Services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
builder.Services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
