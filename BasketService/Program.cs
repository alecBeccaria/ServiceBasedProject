using Microsoft.EntityFrameworkCore;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery.Eureka;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();//This line finds the controller we built
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddDiscoveryClient(builder.Configuration);
//builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));//gives connection to db
builder.Services.AddDbContext<BasketDb>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("docker_db1")));//gives up the database handle
var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());



using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BasketDb>();
    
    db.Database.Migrate();
}


app.MapControllers();


app.MapGet("/", () => "Ur mom's a hoe");

app.Run();

