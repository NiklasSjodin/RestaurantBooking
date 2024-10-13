using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestaurantBooking.Data;
using RestaurantBooking.Data.Repos;
using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Services;
using RestaurantBooking.Services.IServices;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RestaurantContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddCors(options => // Registrerar CORS-tjänster för förfrågningar
{
    options.AddPolicy("LocalReact", policy => // Lägger till policy för "LocalReact"
    {
        policy.WithOrigins("http://localhost:5173") // Tillåter förfrågningar från en specifik URL
        .AllowAnyHeader() // Tillåter alla typer av HTTP-headers i förfrågningarna
        .AllowAnyMethod() // Tillåter alla typer av HTTP-metoder i förfrågningarna

        .AllowCredentials();
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
app.UseAuthentication();
app.UseAuthorization();

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
