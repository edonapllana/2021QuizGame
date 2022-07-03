using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuizClassLibrary;

namespace Design_Dashboard_Modern
{
    public partial class testprov2 : Form
    {
        public string user { get; set; }
        int score = 0, count, totalTime, questionID = 0, nextQuestionID = 0;
        string correctAnswer = "";
        public testprov2(string u)
        {
            user = u;
            InitializeComponent();
     
        }

        
        
 
        //private int quizID;

        private void fillQuestions()
        {
            var question = new QuestionModel();

            var pytja = question.getQuestionsByID(questionID);

            if (pytja.Count() == 0)
            {
                var finished = new QuizFinished(user);
                finished.score = score;
                finished.Show();
                this.Hide();


            }
                

            int i = 0;
            foreach (var item in pytja)
            {
                if (i == 0)
                {
                    nextQuestionID = item.questionID;
                    txtQuestion.Text = item.questCont;

                    var options = new OptionsModel();

                    int j = 1;
                    foreach (var itemOption in options.getOptions(questionID))
                    {
                        if (j == 1)
                        {
                            BtnA.Text = itemOption.optionContent;
                            if(itemOption.isCorrect)
                                correctAnswer = itemOption.optionContent;
                        }
                        else if (j == 2)
                        {
                            BtnB.Text = itemOption.optionContent;
                            if (itemOption.isCorrect)
                                correctAnswer = itemOption.optionContent;
                        }
                        else if (j == 3)
                        {
                            BtnC.Text = itemOption.optionContent;
                            if (itemOption.isCorrect)
                                correctAnswer = itemOption.optionContent;
                        }
                        else if (j == 4)
                        {
                            BtnD.Text = itemOption.optionContent;
                            if (itemOption.isCorrect)
                                correctAnswer = itemOption.optionContent;
                        }
                        j++;
                    }
                    
                    return;
                }
            }
        }
   
        private void testprov2_Load_1(object sender, EventArgs e)
        {
            fillQuestions();
        }

        private void BtnA_Click(object sender, EventArgs e)
        {
            if (correctAnswer == BtnA.Text)
                score += 10;
            questionID = nextQuestionID;
            fillQuestions();
        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            if (correctAnswer == BtnC.Text)
                score += 10;
            questionID = nextQuestionID;
            fillQuestions();
        }

        private void BtnB_Click(object sender, EventArgs e)
        {
            if (correctAnswer == BtnB.Text)
                score += 10;
            questionID = nextQuestionID;
            fillQuestions();
        }

        private void BtnD_Click(object sender, EventArgs e)
        {
            if (correctAnswer == BtnD.Text)
                score += 10;
            questionID = nextQuestionID;
            fillQuestions();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Dashboard(user).Show();
        }


       
    }
}
