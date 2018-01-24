using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;
using PairingTest.Web.Services.Contracts;

namespace PairingTest.Web.Services
{
    [ExcludeFromCodeCoverage]
    // It could be tested by an Integration test, or through a HttpSelfHost Server
    public class ApiRequestService : IApiRequestService
    {
        private const string BaseRequest = "REST GET request on {0}";

        private readonly Func<string, string, string> _errorMessage = (s, s1) =>
            string.Concat("Error during ", string.Format(s, s1));

        public async Task<T> GetAsync<T>(string serviceUrl)
        {
            try
            {
                var uri = new Uri(serviceUrl);

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(uri);

                    if (!response.IsSuccessStatusCode)
                        throw new InvalidOperationException(_errorMessage(BaseRequest, serviceUrl));

                    return await response.Content.ReadAsAsync<T>();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(_errorMessage(BaseRequest, serviceUrl), ex);
            }
        }
    }
}