using HospitalAppointment.WebApi;
using HospitalAppointmentSystem.Repository.Abstract;
using HospitalAppointmentSystem.Repository.Concretes;
using HospitalAppointmentSystem.Service;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
//DI
builder.Services.AddScoped<IDoctorRepository, EfDoctorRepository>();
builder.Services.AddScoped<IAppointmentRepository, EfAppointmentRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
// Add services to the container.

builder.Services.AddControllers();

// Veritaban? ba?lant?s?n? appsettings.json üzerinden sa?lama

builder.Services.AddDbContext<BaseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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