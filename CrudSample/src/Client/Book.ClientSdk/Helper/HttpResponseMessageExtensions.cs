using Newtonsoft.Json;

namespace Book.ClientSdk.Helper
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<TResponse> DeserializeAsync<TResponse>(this HttpResponseMessage httpResponse)
        {
            string content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(content)!;
        }
        public static async Task<Response<TData>> DeserializeAsync<TData, TErrorEnum>(this HttpResponseMessage httpResponse) where TErrorEnum : Enum 
        {
            string content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<TData>>(content)!;
        }
    }
}
