using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElasticSearch.Services;

public interface IElasticService<in T> where T : class
{
    Task<string> CreateIndexAsync(string indexName);
    Task IndexAsync(string indexName, T doc);
    Task IndexManyAsync(string indexName, IEnumerable<T> doc);
    Task SearchForSuggestionAsync(string index, string term);
}