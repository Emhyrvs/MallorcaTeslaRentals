﻿
using MallorcaTeslaRentals.Data;
using MallorcaTeslaRentals.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



var builder = WebApplication.CreateBuilder(args);

// Dodaj kontekst bazy danych SQLite (ApplicationDbContext)
builder.Services.AddDbContext<DataDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); ;

// Dodaj serwis
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyFrontendApp", builder =>
    {
        builder.WithOrigins("http://localhost:4200") // Zastąp tym adresem URL swojej frontendowej aplikacji Angular
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
// Dodaj Endpoints API Explorer i Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // Skonfiguruj Swagger
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MallorcaTeslaRentals v1"));
}
app.UseCors("AllowMyFrontendApp");
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
await PrepDbcs.PrepPopulation(app, true);
app.Run();
