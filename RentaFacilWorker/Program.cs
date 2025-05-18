using Infrastructure.Extensions;

var builder = Host.CreateApplicationBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddHostedService<Worker>();
builder.Services.AddInfrastructure(configuration);
builder.Services.AddApplication(configuration);
builder.Services.AddHttpContextAccessor();

var host = builder.Build();
host.Run();
