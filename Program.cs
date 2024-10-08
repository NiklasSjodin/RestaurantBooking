using Microsoft.EntityFrameworkCore;
using RestaurantBooking.Data;
using RestaurantBooking.Data.Repos;
using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Services;
using RestaurantBooking.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RestaurantContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();

builder.Services.AddCors(options => // Registrerar CORS-tj�nster f�r f�rfr�gningar
{
    options.AddPolicy("LocalReact", policy => // L�gger till policy f�r "LocalReact"
    {
        policy.WithOrigins("http://localhost:5173") // Till�ter f�rfr�gningar fr�n en specifik URL
        .AllowAnyHeader() // Till�ter alla typer av HTTP-headers i f�rfr�gningarna
        .AllowAnyMethod(); // Till�ter alla typer av HTTP-metoder i f�rfr�gningarna
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddScoped<IMenuItemService, MenuItemService>();

builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<ITableService, TableService>();

builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IReservationService, ReservationService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("LocalReact");

app.UseAuthorization();

app.MapControllers();

app.Run();
