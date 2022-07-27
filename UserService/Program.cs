using Microsoft.EntityFrameworkCore;
using Steeltoe.Common.Discovery; 
using Steeltoe.Discovery.Eureka; 
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDiscoveryClient(builder.Configuration);
//builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDbContext<UserDB>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("docker_db1")));
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

app.MapGet("/test1", async (IDiscoveryClient idc) => {
 //return "this is the root of dotnet-eureka-client";
DiscoveryHttpClientHandler _handler = new DiscoveryHttpClientHandler(idc);
var client = new HttpClient(_handler, false);
return await client.GetStringAsync("http://CATALOGSERVICE/catalog/test/") + " || Accessed from Users service"; } );


app.UseCors("AllCors");

app.Run();
