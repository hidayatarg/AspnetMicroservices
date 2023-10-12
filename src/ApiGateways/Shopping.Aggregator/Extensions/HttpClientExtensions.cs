using System.Net.Http;
using System.Text.Json;

namespace Shopping.Aggregator.Extensions;

public static class HttpClientExtensions
{
    public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
    {
        if(!response.IsSuccessStatusCode)
            throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");
        
        var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
    
    // public static Task<HttpResponseMessage> PostAsJsonAsync<T>(
    //     this HttpClient httpClient, string url, T data)
    // {
    //     var dataAsString = JsonConvert.SerializeObject(data);
    //     var content = new StringContent(dataAsString);
    //     content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    //     return httpClient.PostAsync(url, content);
    // }

    // public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
    // {
    //     var dataAsString = await content.ReadAsStringAsync();
    //     return JsonConvert.DeserializeObject<T>(dataAsString);
    // }
}