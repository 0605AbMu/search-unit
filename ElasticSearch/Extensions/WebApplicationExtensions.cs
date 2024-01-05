using System;
using System.Threading.Tasks;
using Elastic.Clients.Elasticsearch;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.DependencyInjection;

namespace ElasticSearch.Extensions;

public static class WebApplicationExtensions
{
    public static async Task PingElasticSearch(this WebApplication app)
    {
        var client = app.Services.GetService<ElasticsearchClient>();
        var pingResult = await client.PingAsync();

        if (!pingResult.IsSuccess())
            throw new ConnectionAbortedException("Unable to connect elastic search service at " +
                                                 pingResult.ApiCallDetails.Uri?.ToString());
        
        Console.WriteLine(pingResult.ToString());
    }
}