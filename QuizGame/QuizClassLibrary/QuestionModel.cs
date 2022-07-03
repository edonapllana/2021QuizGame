using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizClassLibrary
{
    public class QuestionModel
    {
        public int questionID { get; set; }
        public string questCont { get; set; }
        public int quizID { get; set; }
        public int userID { get; set; }
        public int points { get; set; }
        public bool played;


        public string CheckFileds(QuestionModel question)
        {
            if (string.IsNullOrEmpty(question.questCont))
                return "Te plotesohet Pytja";
            if(string.IsNullOrEmpty(question.quizID.ToString()))
                return "Te plotesohet kuizi!";


            using (QuizEntities conn = new QuizEntities())
            {
                var questionid = conn.Questions.Where(x => x.questCont == question.questCont).FirstOrDefault();

                if (questionid != null)
                    return "Kjo pytje ekziston, provo nje pytje tjeter!";
            }

            return string.Empty;
        }
        public int Create(QuestionModel question)
        {
            using (QuizEntities conn = new QuizEntities())
            {
                var quest = conn.Questions.Add(new Question()
                {
                    questionID = question.questionID,
                    questCont = question.questCont,
                    quizID = question.quizID,
                    userID = question.userID,
                    points = points
                });
                conn.SaveChanges();
                if (quest == null)
                    return 0;
                else
                    return quest.questionID;
            }
        }
        public List<QuestionModel> getQuestion(int quizID = 0)
        {
            using (QuizEntities conn = new QuizEntities())
            {
                var question = new List<Question>();

                if (quizID != 0)
                    question = conn.Questions.Where(x => x.quizID == quizID).ToList();
                else
                    question = conn.Questions.ToList();

                var questionR = question
                    .Select(x => new QuestionModel()
                    {
                        questionID = x.questionID,
                        questCont = x.questCont,
                        quizID = x.quizID,
                        userID = x.userID,
                        points = x.points
                    })
                    .ToList();

                return questionR;
            }
        }
        public bool Delete(int questionID)
        {
            using (QuizEntities conn = new QuizEntities())
            {
                var question = conn.Questions.Find(questionID);

                if (question == null)
                    return false;
                else
                {
                    conn.Questions.Remove(question);
                    conn.SaveChanges();
                    return true;
                }
            }
        }

        ///function for update on question 
        public bool Update(QuestionModel quest)
        {
            using (QuizEntities conn = new QuizEntities())
            {
                var q = conn.Questions.Find(quest.questionID);

                if (q == null)
                    return false;
                else
                {
                    q.questCont = quest.questCont;
                    conn.SaveChanges();
                    return true;
                }
            }
        }

        public List<QuestionModel> getQuestionsByID(int questionID)
        {
            using (QuizEntities conn = new QuizEntities())
            {
                
                var checkQuestions = conn.Questions.Where(x => x.questionID > questionID).ToList();

                var question = checkQuestions.Select(x => new QuestionModel()
                {
                    questionID = x.questionID,
                    questCont = x.questCont,
                    quizID = x.quizID,
                    userID = x.userID,
                    points = x.points
                }).ToList();
                return question;
            }
        }


        //function Random

      
    }
}
