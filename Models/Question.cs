using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerService.Models
{
    public class Question
    {
        public List<string> Que { get; set; }
        public List<string> Answer { get; set; }

        public Question ListQust { get; set; }
        public List<bool> SelectedAnswer { get; set; }

    }
}
