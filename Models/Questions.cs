using ComputerService.Interfaces;
using System.Collections.Generic;

namespace ComputerService.Models
{
    public class Questions : IQuestions
    {
        public List<string> AllQuestions { get; set; }
        
        public Questions()
        {
            AllQuestions = new List<string>()
            {
                "Does it turn off?",
                "Has it problem with web-connection?",
                "Has been bought  for more than 5 years?",
                "Does it frezee?",
                "Have it ever any mechanical accident?",
                "Does it overheat?",
                "Is problem with devices detection?"
            };

        }

         

    public List<string> GetQuestions() => AllQuestions;

        public int GetNumberOfQuestions() => AllQuestions.Count;
    }
}
