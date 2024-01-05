using Elastic.Clients.Elasticsearch;

namespace ElasticSearch.Services;

public class DataMigrationService
{
    private readonly ElasticsearchClient _client;

    public DataMigrationService(ElasticsearchClient client)
    {
        _client = client;
    }
}