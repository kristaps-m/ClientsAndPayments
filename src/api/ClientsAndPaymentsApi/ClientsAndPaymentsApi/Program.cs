using ClientsAndPayments.Core.Interfaces;
using ClientsAndPayments.Data;
using ClientsAndPayments.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add connection string;
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ClientsAndPaymentsDbContext>(x => x.UseSqlite(connectionString));
// Register services and interfaces;
builder.Services.AddScoped<IClientsAndPaymentsDbContext, ClientsAndPaymentsDbContext>();
builder.Services.AddScoped<IDbService, DbService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

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
