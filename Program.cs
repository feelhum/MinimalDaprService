using Dapr.Client;
using Dapr.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);


// 添加 Dapr 支持
builder.Services.AddDaprClient();

// 加载 Dapr 配置存储（如 Nacos）
builder.Configuration.AddDaprConfigurationStore(
    store: "nacos",
    keys: new[] { "myconfig" }, // 你需要在 Nacos 中设置这个 key
    client: new DaprClientBuilder().Build(),
    sidecarWaitTimeout: TimeSpan.FromSeconds(5)
);

builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();
app.Run();