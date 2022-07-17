using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//  SQL server database
//localhost line
//builder.Services.AddDbContext<ItemDb>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("docker_db1")));
//docker line
builder.Services.AddDbContext<ItemDb>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("docker_db2")));

var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
