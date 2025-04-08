using Dapr.Client;
using Dapr.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);


// ��� Dapr ֧��
builder.Services.AddDaprClient();

// ���� Dapr ���ô洢���� Nacos��
builder.Configuration.AddDaprConfigurationStore(
    store: "nacos",
    keys: new[] { "myconfig" }, // ����Ҫ�� Nacos ��������� key
    client: new DaprClientBuilder().Build(),
    sidecarWaitTimeout: TimeSpan.FromSeconds(5)
);

builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();
app.Run();