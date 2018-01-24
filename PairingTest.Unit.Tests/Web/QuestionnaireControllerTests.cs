using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Models;
using PairingTest.Web.Services.Contracts;
using PairingTest.Web.Services.Models;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        private QuestionnaireController _sut;
        private Mock<ITypeMapper> _typeMapper;
        private Mock<IQuestionnaireService> _service;

        [TestFixtureSetUp]
        public void Setup()
        {
            _typeMapper = new Mock<ITypeMapper>();
            _service = new Mock<IQuestionnaireService>();

            _sut = new QuestionnaireController(_service.Object, _typeMapper.Object);
        }

        [Test]
        public void Given_GetQuestionnaireRequest_When_Returns_Then_ResultIsEqualToExpected()
        {
            const string expectedTitle = "My expected quesitons";
            var questionsText = new List<string>
            {
                "Question #1",
                "Question #2",
                "Question #3"
            };
            var questionnaireModel = new QuestionnaireModel {Title = expectedTitle, QuestionsText = questionsText};
            _service.Setup(x => x.GetQuestionnaires("http://localhost:50014/api/Questions"))
                .Returns(Task.FromResult(questionnaireModel)).Verifiable();
            var questionnaireViewModel =
                new QuestionnaireViewModel {QuestionnaireTitle = expectedTitle, QuestionsText = questionsText};
            _typeMapper.Setup(x => x.Convert<QuestionnaireModel, QuestionnaireViewModel>(questionnaireModel))
                .Returns(questionnaireViewModel).Verifiable();

            var result = (QuestionnaireViewModel) _sut.Index().Result.Model;

            Assert.That(result.QuestionnaireTitle, Is.EqualTo(expectedTitle));
            Assert.True(result.QuestionsText.Count == questionsText.Count);
            Assert.True(result.QuestionsText.SequenceEqual(questionsText));
            _service.VerifyAll();
            _typeMapper.VerifyAll();
        }
    }
}