using Domain.UseCase.Gateways;
using Domain.UseCase.UseCases;
using Microsoft.EntityFrameworkCore;
using VirtualEducation.DDD.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(DataBaseContext).Assembly.FullName)
                ));

builder.Services.AddScoped(typeof(IStoredEventRepository<>), typeof(StoredEventRepository<>));
builder.Services.AddScoped<IStudentUseCase, StudentUseCase>();

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
