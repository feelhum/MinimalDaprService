using Dapr.Client;
using Dapr.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// 使用 Dapr 配置中心，从 Nacos 加载配置
var daprClient = new DaprClientBuilder().Build();
builder.Configuration.AddDaprConfigurationStore(
    store: "appconfig",
    keys: new List<string> { "MinimalDaprService" },
    client: daprClient,
    sidecarWaitTimeout: TimeSpan.FromSeconds(5)
);

builder.Services.AddControllers();

var app = builder.Build();
app.MapGet("/hello", () => "Hello from Minimal Dapr Service with Nacos config!");
app.Run();
