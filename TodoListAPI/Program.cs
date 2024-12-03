using Microsoft.EntityFrameworkCore;
using TodoListAPI.Data;
using TodoListAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodoContext>(options =>
{
    options.UseInMemoryDatabase("TodoDB");
});

builder.Services.AddScoped<ITaskInterface, TaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

builder.WebHost.UseUrls("http://0.0.0.0:5000");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
