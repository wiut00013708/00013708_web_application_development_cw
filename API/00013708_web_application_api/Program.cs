using _00013708_web_application_api.Data;
using _00013708_web_application_api.Models.Domain;
using _00013708_web_application_api.Repositories.Implementation;
using _00013708_web_application_api.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplicationConnectionString"));
});

builder.Services.AddScoped<IContactRepository<PhoneNumber>, PhoneNumberRepository>();
builder.Services.AddScoped<IContactRepository<Contact>, ContactRepository>();

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
