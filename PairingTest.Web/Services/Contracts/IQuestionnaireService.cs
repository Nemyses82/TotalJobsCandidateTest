using System.Threading.Tasks;
using PairingTest.Web.Services.Models;

namespace PairingTest.Web.Services.Contracts
{
    public interface IQuestionnaireService
    {
        Task<QuestionnaireModel> GetQuestionnaires(string apiRoute);
    }
}