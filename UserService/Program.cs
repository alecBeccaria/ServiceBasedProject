using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDbContext<UserDB>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("docker_db2")));
builder.Services.AddCors(option =>
      {
        option.AddPolicy("AllCors", builder =>
        {
          builder.AllowAnyOrigin();
          builder.AllowAnyHeader();
          builder.AllowAnyMethod();
        });
      });
var app = builder.Build();
app.MapControllers();



app.UseCors("AllCors");

app.Run();
