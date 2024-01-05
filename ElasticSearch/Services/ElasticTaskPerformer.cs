using System;
using System.Threading.Tasks;
using Elastic.Clients.Elasticsearch;

namespace ElasticSearch.Services;

public class ElasticTaskPerformer
{
    public async Task<IndexResponse> PerformTaskAsync(Task<IndexResponse> task)
    {
        try
        {
            var result = await task;

            if (!result.IsSuccess())
                throw new InvalidOperationException(result.ElasticsearchServerError?.Error.Reason);

            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<BulkResponse> PerformBulkTaskAsync(Task<BulkResponse> task)
    {
        try
        {
            var result = await task;

            if (!result.IsSuccess())
                throw new InvalidOperationException(result.ElasticsearchServerError?.Error.Reason);

            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}