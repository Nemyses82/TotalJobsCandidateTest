using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;
using PairingTest.Web.Models;
using PairingTest.Web.Services.Contracts;
using PairingTest.Web.Services.Models;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        private readonly IQuestionnaireService _questionnaireService;
        private readonly ITypeMapper _typeMapper;

        public QuestionnaireController(IQuestionnaireService questionnaireService, ITypeMapper typeMapper)
        {
            _questionnaireService = questionnaireService;
            _typeMapper = typeMapper;
        }

        public async Task<ViewResult> Index()
        {
            var serviceUri = ConfigurationManager.AppSettings["QuestionnaireServiceUri"];

            var questionnaire = await _questionnaireService.GetQuestionnaires(serviceUri);

            var viewModel = _typeMapper.Convert<QuestionnaireModel, QuestionnaireViewModel>(questionnaire);

            return View(viewModel);
        }
    }
}