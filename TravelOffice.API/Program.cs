using Microsoft.EntityFrameworkCore;
using TravelOffice.Infrastructure.Context;
using TravelOffice.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MainContext>(options =>
    options.UseSqlite("DataSource=dbo.TravelOffice.db",
        sqlOptions => sqlOptions.MigrationsAssembly("TravelOffice.Infrastructure")
    )
);

builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<ITouristAttractionRepository, TouristAttractionRepository>();
builder.Services.AddScoped<ITransportRepository, TransportRepository>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();

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