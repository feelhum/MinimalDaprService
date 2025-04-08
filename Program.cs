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
// ʾ������ȡ����
var configValue = builder.Configuration["myapp/config/mykey"];
Console.WriteLine($"����ֵ��{configValue}");
builder.Services.AddControllers().AddDapr(); // ע�� Dapr ��ط���;
var app = builder.Build();
app.MapSubscribeHandler(); // ��ѡ������ Dapr Pub/Sub
app.MapControllers();
app.Run();