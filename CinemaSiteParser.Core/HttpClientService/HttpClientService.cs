﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;

namespace CinemaSiteParser.Core.HttpClientService
{
    public class HttpClientService : IHttpClientService, IDisposable
    {
        readonly HttpClient _httpClient;

        public DefaultContractResolver ContractResolver { get; set; }

        public HttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<string> GetHtmlAsync(string urlRequest)
        {
            var response = await _httpClient.GetAsync(urlRequest);
            if (!response.IsSuccessStatusCode)
            {
                var eror = await response.Content.ReadAsStringAsync();
                throw new Exception(eror);
            }
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<TResult> GetAsync<TResult>(string urlRequest)
        {
            var response = await _httpClient.GetAsync(urlRequest);
            if (!response.IsSuccessStatusCode)
            {
                var eror = await response.Content.ReadAsStringAsync();
                throw new Exception(eror);
            }
            return await ConvertResponseContent<TResult>(response.Content);
        }

        public async Task<TResult> GetAsync<TResult>(Uri uri)
        {
            var response = await _httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception(error);
            }
            return await ConvertResponseContent<TResult>(response.Content);
        }

        protected async virtual Task<TResult> ConvertResponseContent<TResult>(HttpContent content)
        {
            var json = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(json, new JsonSerializerSettings()
            {
                ContractResolver = ContractResolver
            });
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}