using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerService.Interfaces
{
    interface IQuestions
    {
        List<string> GetQuestions();
        int GetNumberOfQuestions();
    }
}
