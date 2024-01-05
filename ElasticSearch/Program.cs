using System;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using ElasticSearch.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.WebHost.UseUrls(builder.Configuration["LaunchUrl"]!);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ElasticsearchClient>(provider =>
{
    string? url = builder.Configuration["ElasticsearchUrl"];

    ArgumentNullException.ThrowIfNull(url);

    var settings = new ElasticsearchClientSettings(new Uri(url));
    settings.PrettyJson();
    settings.Authentication(new BasicAuthentication("elastic", "1234"));

    return new ElasticsearchClient(settings);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     
// }
app.UseSwagger();
app.UseSwaggerUI();

// app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();


await app.PingElasticSearch();

await app.RunAsync();