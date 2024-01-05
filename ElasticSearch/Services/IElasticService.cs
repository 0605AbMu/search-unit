using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElasticSearch.Services;

public interface IElasticService
{
    Task<string> CreateIndexAsync(string indexName);
    Task IndexAsync<T>(string indexName, T doc);
    Task IndexManyAsync<T>(string indexName, IEnumerable<T> doc);
    Task SearchBySuggestion<T>(string index, string term);
}