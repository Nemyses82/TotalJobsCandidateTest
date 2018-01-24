using System.Threading.Tasks;
using PairingTest.Web.Services.Contracts;
using PairingTest.Web.Services.Models;

namespace PairingTest.Web.Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly IApiRequestService _apiRequestService;

        public QuestionnaireService(IApiRequestService apiRequestService)
        {
            _apiRequestService = apiRequestService;
        }

        public async Task<QuestionnaireModel> GetQuestionnaires(string serviceUrl)
        {
            var requestMessage = await _apiRequestService.GetAsync<QuestionnaireModel>(serviceUrl);

            return requestMessage;
        }
    }
}