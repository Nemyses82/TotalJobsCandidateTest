using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PairingTest.Web.Services;
using PairingTest.Web.Services.Contracts;
using PairingTest.Web.Services.Models;

namespace PairingTest.Unit.Tests.Web.Services
{
    [TestFixture]
    public class QuestionnaireServiceTests
    {
        private QuestionnaireService _sut;
        private Mock<IApiRequestService> _apiRequestService;
        private const string ServiceUri = "http://localhost:50014/api/Questions";

        [TestFixtureSetUp]
        public void Setup()
        {
            _apiRequestService = new Mock<IApiRequestService>();

            _sut = new QuestionnaireService(_apiRequestService.Object);
        }

        [Test]
        public void Given_GetQuestionnairesRequest_When_ReturnsInformations_Then_ResultIsEqualToExpected()
        {
            const string expectedTitle = "My expected quesitons";
            var questionsText = new List<string>
            {
                "Question #1",
                "Question #2",
                "Question #3"
            };
            var questionnaireModel = new QuestionnaireModel {Title = expectedTitle, QuestionsText = questionsText};
            _apiRequestService.Setup(x => x.GetAsync<QuestionnaireModel>(ServiceUri))
                .Returns(Task.FromResult(questionnaireModel)).Verifiable();

            var result = _sut.GetQuestionnaires(ServiceUri).Result;

            Assert.That(result.Title, Is.EqualTo(expectedTitle));
            Assert.True(result.QuestionsText.Count() == questionsText.Count);
            Assert.True(result.QuestionsText.SequenceEqual(questionsText));
            _apiRequestService.VerifyAll();
        }
    }
}