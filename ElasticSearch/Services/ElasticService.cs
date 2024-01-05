using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElasticSearch.Services;

public class ElasticService<T> : ElasticTaskPerformer, IElasticService where T : class
{
    public Task<string> CreateIndexAsync(string indexName)
    {
        throw new System.NotImplementedException();
    }

    public Task IndexAsync<T1>(string indexName, T1 doc)
    {
        throw new System.NotImplementedException();
    }

    public Task IndexManyAsync<T1>(string indexName, IEnumerable<T1> doc)
    {
        throw new System.NotImplementedException();
    }

    public Task SearchBySuggestion<T1>(string index, string term)
    {
        throw new System.NotImplementedException();
    }
}