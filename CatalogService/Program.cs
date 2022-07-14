using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//  SQL server database
builder.Services.AddDbContext<ItemDb>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("docker_db1")));


var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
