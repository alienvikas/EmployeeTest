using EmployeeApi.Models;
using EmployeeApi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(connectionString, serverOptions =>
{
    serverOptions.EnableRetryOnFailure
    (
        maxRetryCount: 3,       // Maximum number of retry attempts
        maxRetryDelay: TimeSpan.FromSeconds(30), // Maximum delay between retries
        errorNumbersToAdd: null
     ); // Specific error numbers to retry on (null retries on all transient errors)
}));

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
