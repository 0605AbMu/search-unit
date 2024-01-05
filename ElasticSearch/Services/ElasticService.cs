using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElasticSearch.Services;

public class ElasticService<T> : ElasticTaskPerformer, IElasticService<T> where T : class
{
    public Task<string> CreateIndexAsync(string indexName)
    {
        throw new System.NotImplementedException();
    }

    public Task IndexAsync(string indexName, T doc)
    {
        throw new System.NotImplementedException();
    }

    public Task IndexManyAsync(string indexName, IEnumerable<T> doc)
    {
        throw new System.NotImplementedException();
    }

    public Task SearchForSuggestionAsync(string index, string term)
    {
        throw new System.NotImplementedException();
    }
}