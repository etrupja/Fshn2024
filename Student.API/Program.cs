using Microsoft.EntityFrameworkCore;
using Student.API;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connection string
var connString = "Data Source=ETR\\SQLEXPRESS;Initial Catalog=Fshn2024DB;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=True";

builder.Services
    .AddDbContext<AppDbContext>(o => o.UseSqlServer(connString));


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
