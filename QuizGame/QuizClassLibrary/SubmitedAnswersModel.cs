using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizClassLibrary
{
    public class SubmitedAnswersModel
    {
        public int submitedAnsID { get; set; }
        public int optionID { get; set; }
        public int questionID { get; set; }
        public int userID { get; set; }

        public bool Create(SubmitedAnswersModel submitedAnswer)
        {
            using (QuizEntities conn = new QuizEntities())
            {
                var answer = conn.SubmitedAnswers.Add(new SubmitedAnswer()
                {
                    optionID = submitedAnswer.optionID,
                    questionID = submitedAnswer.questionID,
                    userID = submitedAnswer.userID
                });

                if (answer == null)
                    return false;


                return true;
            }
        }
    }
}
