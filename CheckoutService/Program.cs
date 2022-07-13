using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDbContext<CheckoutDB>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("docker_db1")));

var app = builder.Build();
app.MapControllers();
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());


app.UseCors("AllCors");

app.Run();
