using System.Collections.Generic;

namespace PairingTest.Web.Services.Models
{
    public class QuestionnaireModel
    {
        public string Title { get; set; }

        public IEnumerable<string> QuestionsText { get; set; }
    }
}