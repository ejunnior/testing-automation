namespace FrontEnd.Services
{
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IFinanceHttpClient
    {
        Task<HttpClient> GetClient();
    }
}