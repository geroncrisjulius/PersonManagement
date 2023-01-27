using Microsoft.EntityFrameworkCore;
using WebAPIPersonManagement;
using WebAPIPersonManagement.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PersonManagerContext>(
    options => options.UseInMemoryDatabase("PersonManagement"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


//Initialize data from web source
var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetService<PersonManagerContext>();
DataInitializer dataInitializer = new DataInitializer(context);
dataInitializer.Initialize();





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
