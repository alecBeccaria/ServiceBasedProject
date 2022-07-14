using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();//This line finds the controller we built
//builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));//gives connection to db
builder.Services.AddDbContext<BasketDb>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("docker_db1")));//gives up the database handle
var app = builder.Build();
app.MapControllers();

app.MapGet("/", () => "Ur mom's a hoe");

app.Run();

