using Newtonsoft.Json.Serialization;

namespace CinemaSiteParser.Core
{
    public interface IHttpClientService
    {
        DefaultContractResolver ContractResolver { get; set; }

        Task<TResult> GetAsync<TResult>(string urlRequest);

        Task<TResult> GetAsync<TResult>(Uri uri);

        Task<string> GetHtmlAsync(string urlRequest);
    }
}
