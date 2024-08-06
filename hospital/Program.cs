using hospital.Domain;
using hospital.UseCase;
using hospital.UseCase.UseCaseImpl;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<HospitalDbContext>(opcion => opcion.UseSqlServer(builder.Configuration.GetConnectionString("hospital_Conecction")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DoctorUseCase, DoctorUseCaseImpl>();
builder.Services.AddScoped<CitaUseCase, CitaUseCaseImpl>();
builder.Services.AddScoped<ConsultaUseCase, ConsultaUseCaseImpl>();


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
