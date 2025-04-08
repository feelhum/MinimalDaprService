using Dapr.Client;
using Dapr.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);


var daprClient = new DaprClientBuilder().Build();

builder.Configuration.AddDaprConfigurationStore(
    store: "configstore",
    keys: new List<string> { "myapp/config/mykey" },
    client: daprClient,
    sidecarWaitTimeout: TimeSpan.FromSeconds(10)
);
// 示例：获取配置
var configValue = builder.Configuration["myapp/config/mykey"];
Console.WriteLine($"配置值：{configValue}");
builder.Services.AddControllers().AddDapr(); // 注册 Dapr 相关服务;
var app = builder.Build();
app.MapSubscribeHandler(); // 可选：用于 Dapr Pub/Sub
app.MapControllers();
app.Run();