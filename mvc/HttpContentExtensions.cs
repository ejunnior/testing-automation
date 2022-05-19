namespace FrontEnd
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Services.Dto;

    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent content)
        {
            return JsonConvert
                .DeserializeObject<T>(await content.ReadAsStringAsync());
        }
    }
}