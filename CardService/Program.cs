using Microsoft.EntityFrameworkCore;
using Steeltoe.Common.Discovery; 
using Steeltoe.Discovery.Eureka; 
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDiscoveryClient(builder.Configuration);
builder.Services.AddControllers();
//builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDbContext<CardDB>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("docker_db1")));
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
