using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizClassLibrary
{
    public class QuizModel
    {
        public int quizID { get; set; }
        public string quizName { get; set; }
        public int QuestionCount { get; set; }
        public int userID { get; set; }


        //function
        public string CheckFileds(QuizModel quiz)
        {
            if (string.IsNullOrEmpty(quiz.quizName))
                return "Fill the quiz name.";
            
  
            using (QuizEntities conn = new QuizEntities())
            {
                var quize = conn.Quizs.Where(x => x.quizName == quiz.quizName).FirstOrDefault();

                if (quize != null)
                    return "This quiz exist! Create a new one.";
            }


            return string.Empty;
        }
        public bool Create(QuizModel quiz)
        {
            using (QuizEntities conn = new QuizEntities())
            {
                var createquiz = conn.Quizs.Add(new Quiz()
                {
                    quizName = quiz.quizName,
                    userID = quiz.userID
                });
                conn.SaveChanges();
                if (createquiz == null)
                    return false;
                else
                    return true;
            }
        }
       //funksionet
        //public bool Update(QuizModel creatquiz)
        //{
        //    using (QuizEntities conn = new QuizEntities())
        //    {
        //        var cr = conn.Quizs.Find(creatquiz.quizID);

        //        if (cr == null)
        //            return false;
        //        else
        //        {
        //            cr.quizName = creatquiz.quizName;
        //            cr.userID = creatquiz.userID;

        //            conn.SaveChanges();
        //            return true;
        //        }
        //    }
        //}
        
        public bool Update(QuizModel quiz)
        {

            using (QuizEntities conn = new QuizEntities())
            {
                var cr = conn.Quizs.Find(quiz.quizID);

                if (cr == null)
                    return false;
                else
                {
                    cr.quizName = quiz.quizName;
                    conn.SaveChanges();
                    return true;
                }
            }
        }
        //Function delete for quiz
        public bool Delete(int quizID)
        {
            using (QuizEntities conn = new QuizEntities())
            {
                var quiz = conn.Quizs.Find(quizID);

                if (quiz == null)
                    return false;
                else
                {
                    conn.Quizs.Remove(quiz);
                    conn.SaveChanges();
                    return true;
                }
            }
        } 

        public List<QuizModel> getQuiz(string searchText)
        {
            using (QuizEntities conn = new QuizEntities())
            {
                var quiz = new List<Quiz>();

                //function search quiz
                if (string.IsNullOrEmpty(searchText))
                    quiz = conn.Quizs.ToList();
                else
                    quiz = conn.Quizs
                        .Where(x => (x.quizName.StartsWith(searchText))).ToList();
                //end searcch quizs

             //   quiz = conn.Quizs.ToList();


                var quizs = quiz
                    .Select(x => new QuizModel()
                    {
                        quizID = x.quizID,
                        quizName = x.quizName,
                        QuestionCount = (from q in conn.Questions where q.quizID == x.quizID select q.quizID).Count(),
                        userID = x.userID
                    })
                    .ToList();

                return quizs;

            }
        }
        
        public int getquizId(string quizName)
        {
            using (QuizEntities conn = new QuizEntities())
            {
                var quizID = conn.Quizs.Where(x => x.quizName == quizName).FirstOrDefault().quizID;
                return quizID;
            }
        }
    }
}
