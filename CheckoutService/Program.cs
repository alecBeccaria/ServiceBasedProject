using Microsoft.EntityFrameworkCore;
using Steeltoe.Common.Discovery; 
using Steeltoe.Discovery.Eureka; 
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDiscoveryClient(builder.Configuration);
builder.Services.AddControllers();
//builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDbContext<CheckoutDB>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("docker_db2")));

var app = builder.Build();
app.MapControllers();
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapGet("/test1", (IDiscoveryClient idc) => {
    return "Hello from CheckoutService";
    } 
);
app.UseCors("AllCors");

app.Run();
