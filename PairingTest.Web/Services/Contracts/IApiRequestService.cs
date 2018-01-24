using System.Threading.Tasks;

namespace PairingTest.Web.Services.Contracts
{
    public interface IApiRequestService
    {
        Task<T> GetAsync<T>(string serviceUrl);
    }
}