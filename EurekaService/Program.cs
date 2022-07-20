using Steeltoe.Common.Discovery;
using Steeltoe.Discovery.Eureka;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDiscoveryClient(builder.Configuration);




var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.MapGet("/test1", async (IDiscoveryClient idc) =>
{
    //return "this is the root of dotnet-eureka-client";
    DiscoveryHttpClientHandler _handler = new DiscoveryHttpClientHandler(idc);
    var client = new HttpClient(_handler, false);
    return await client.GetStringAsync("http://DOTNET-API1/test") + " more from dotnet-api2";
}
);

app.Run();
