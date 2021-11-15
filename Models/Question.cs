using System.Collections.Generic;

namespace ComputerService.Models
{
    public class Question
    {
        public List<string> Que { get; set; }
        public List<string> Answer { get; set; }
        public List<string> SelectedAnswer { get; set; }

        public Question(List<string> questions)
        {
            Que = new List<string>(questions);
            SelectedAnswer = new List<string>();

            for (int i = 0; i < Que.Count; i++)
            {
                SelectedAnswer.Add("0");
            }
        }
        public Question(){}
    }
}
