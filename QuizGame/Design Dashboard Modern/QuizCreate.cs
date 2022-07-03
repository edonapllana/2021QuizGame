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
    public partial class QuizCreate : Form
    {
        public int userID { get; set; }
        public QuizCreate(int u)
        {
            userID = u;
            InitializeComponent();
        }

        int quizID = 0, questionID = 0, optionID = 0, option2ID = 0, option3ID = 0, option4ID = 0;
        private string searchText;



        private void fillComboBoxQuiz(string searchText = null)
        {
            var quiz = new QuizModel();

            if (quizCb.Items.Count > 0)
                quizCb.Items.Clear();
            foreach (var item in quiz.getQuiz(searchText))
            {
                quizCb.Items.Add(item.quizName);
                
            }
        }

        private void QuizCreate_Load(object sender, EventArgs e)
        {
          
            fillComboBoxQuiz();
            fillGridQuizList();
            
        }

        private string CheckFields() 
        {
            if (quizCb.SelectedItem == null)
                return "Chose the quiz first!";
            if (string.IsNullOrEmpty(questionCont.Text))
                return "Write a question!";

            using (QuizEntities conn = new QuizEntities())
            {
                var question = conn.Questions.Where(x => x.questCont == questionCont.Text).FirstOrDefault();

                if (question != null)
                    return "This question exist! Try another.";
            }

            if (string.IsNullOrEmpty(qOne.Text) || string.IsNullOrEmpty(qTwo.Text) ||
                string.IsNullOrEmpty(qThree.Text) || string.IsNullOrEmpty(qFour.Text))
                return "Fill the opsions!";

            if (qOneR.Checked == false && qTwoR.Checked == false &&
                qThreeR.Checked == false && qFourR.Checked == false)
                return "One of the options should be true!";

            return string.Empty;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var msg = CheckFields();
            
            if(!string.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg);
                return;
            }
            var quiz = new QuizModel();
            string quizName = quizCb.SelectedItem.ToString();

            int quizID = quiz.getquizId(quizName);

            var question = new QuestionModel();
            question.questCont = questionCont.Text;
            question.quizID = quizID;
            question.userID = userID;
            question.points = 10;
            var questionID = question.Create(question);

            var optionOne = new OptionsModel();
            optionOne.optionContent = qOne.Text;
            optionOne.isCorrect = (qOneR.Checked) ? true : false;
            optionOne.questionID = questionID;
            optionOne.Create(optionOne);

            var optionTwo = new OptionsModel();
            optionTwo.optionContent = qTwo.Text;
            optionTwo.isCorrect = (qTwoR.Checked) ? true : false;
            optionTwo.questionID = questionID;
            optionTwo.Create(optionTwo);

            var optionThree = new OptionsModel();
            optionThree.optionContent = qThree.Text;
            optionThree.isCorrect = (qThreeR.Checked) ? true : false;
            optionThree.questionID = questionID;
            optionThree.Create(optionThree);

            var optionFour = new OptionsModel();
            optionFour.optionContent = qFour.Text;
            optionFour.isCorrect = (qFourR.Checked) ? true : false;
            optionFour.questionID = questionID;
            optionFour.Create(optionFour);

            MessageBox.Show("Successful!");
          
        }

        private void CreateQuiz_Click(object sender, EventArgs e)
        {
            var quiz = new QuizModel();
            quiz.quizName = QuizNametxt.Text;
            quiz.userID = userID;
               
            //qitu ke aj funskioni qe e krijon e ki harru jasht
          
            string msg = quiz.CheckFileds(quiz);

            if (string.IsNullOrEmpty(msg))
            {
                var created = quiz.Create(quiz);  
               
                if (created==false)
                {
                    MessageBox.Show(msg);
                    //LS.SetPage(0);
                    ClearFields();
                    MessageBox.Show("Successfuly!");
                }
                else
                    fillComboBoxQuiz();
   
            }
            else
            {
                MessageBox.Show(msg);
                
            }
        

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fillGridQuizList(string searchText = null)
        {
            var quiz = new QuizModel();
            QuizList.DataSource = quiz.getQuiz(searchText);
        }

        private void QuizList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            UpdateMode();
        }

        private void UpdateMode()
        {
            if (QuizList.Focused)
            {
                if (QuizList.RowCount > 0)
                {
                    CreateQuiz.Enabled = false;
                    btnDelete.Enabled = true;

                    quizID = int.Parse(QuizList["QuizID", QuizList.CurrentRow.Index].Value.ToString());
                    QuizNametxt.Text = QuizList["QuizName", QuizList.CurrentRow.Index].Value.ToString();


                    fillGridQuestionList(quizID);
                }
            }
        }

        private void fillGridQuestionList(int quizID)
        {
            var question = new QuestionModel();
            QuestionList.DataSource = question.getQuestion(quizID);
        }

        private void QuestionList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            UpdateModeQuestion();
        }
        private void UpdateModeQuestion()
        {
            if (QuestionList.Focused)
            {
                if (QuestionList.RowCount > 0)
                {
                    CreateQuiz.Enabled = false;
                    btnDelete.Enabled = true;


                    questionID = int.Parse(QuestionList["QuestionID", QuestionList.CurrentRow.Index].Value.ToString());
                    questionCont.Text = QuestionList["questCont", QuestionList.CurrentRow.Index].Value.ToString();

                    fillGridOptionsList(questionID);

                    using (QuizEntities conn = new QuizEntities())
                    {
                        var opsionet = conn.Options.Where(x => x.questionID == questionID).ToList();

                        int i = 1;
                        foreach (var item in opsionet)
                        {
                            if (i == 1)
                            {
                                optionID = item.optionID;
                                qOne.Text = item.optionContent;
                                qOneR.Checked = (item.isCorrect) ? true : false;
                            }
                            if (i == 2)
                            {
                                option2ID = item.optionID;
                                qTwo.Text = item.optionContent;
                                qTwoR.Checked = (item.isCorrect) ? true : false;
                            }
                            if (i == 3)
                            {
                                option3ID = item.optionID;
                                qThree.Text = item.optionContent;
                                qThreeR.Checked = (item.isCorrect) ? true : false;
                            }
                            if (i == 4)
                            {
                                option4ID = item.optionID;
                                qFour.Text = item.optionContent;
                                qFourR.Checked = (item.isCorrect) ? true : false;
                            }
                            i++;
                        }
                    }

                }
            }
        }

        private void fillGridOptionsList(int questionID)
        {
            var options = new OptionsModel();
            OptionList.DataSource = options.getOptions(questionID);
        }


        private void ClearFields()
        {
            quizID = 0;
            questionID = 0;
            optionID = 0;
            option2ID = 0;
            option3ID = 0;
            option4ID = 0;
            QuizNametxt.Text = "";
            quizCb.Text = "";
            questionCont.Text = "";
            qOne.Text = "";
            qTwo.Text= "";
            qThree.Text = "";
            qFour.Text = "";
            qOneR.Text = "";
            qTwoR.Text = "";
            qThreeR.Text = "";
            qFourR.Text = "";


            CreateQuiz.Enabled =true;
            btnDelete.Enabled = false;
            fillGridQuizList();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var quiz = new QuizModel();
            string msg = quiz.CheckFileds(quiz);

             if(string.IsNullOrEmpty(msg))
                 {
                      bool result = quiz.Update(quiz);

                 if (result)
                 {
                     MessageBox.Show("Updated");
                     ClearFields();
                    // fillGridQuizList();
                    
                 }
                 else 
                     MessageBox.Show("Error while update");
                  }
                 else
                     MessageBox.Show(msg);
        }
        
        
         private void btnDelete_Click(object sender, EventArgs e)
         {

             if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
             {
                 var question = new QuestionModel();

                 foreach (var item in question.getQuestion(quizID))
                 {
                     var option = new OptionsModel();

                     foreach (var itemOption in option.getOptions(item.questionID))
                     {
                         option.Delete(itemOption.optionID);
                     }

                     question.Delete(item.questionID);
                 }
                 var quizs = new QuizModel();

                 bool result = quizs.Delete(quizID);

                 if (result)
                 {
                     MessageBox.Show("Deleted");
                     ClearFields();
                     fillGridQuizList();
                   
                 }
                 else
                     MessageBox.Show("Error");
             }
         }

         private void btnRefresh_Click(object sender, EventArgs e)
         {
             ClearFields();
         }

         private void qOneR_CheckedChanged(object sender, EventArgs e)
         {

         }

         private void UpdateQuiz_Click(object sender, EventArgs e)
         {
             if (quizID == 0)
                 MessageBox.Show("Choose the Quiz!");
             else
             {
                 var quizModel = new QuizModel();
                 quizModel.quizID = quizID;
                 quizModel.quizName = QuizNametxt.Text;
                 quizModel.Update(quizModel);
                 fillGridQuizList();
                 MessageBox.Show("Successful!");
                 ClearFields();
             }
         }

         private void DeleteQuiz_Click(object sender, EventArgs e)
         {
             if (quizID == 0)
                 MessageBox.Show("Choose the Quiz!");
             else
             {
                 var quizModel = new QuizModel();
                 quizModel.Delete(quizID);
                 fillGridQuizList();
                 MessageBox.Show("Successful delete quiz!");
                 ClearFields();
             }
         }

         private void DeleteQuestion_Click(object sender, EventArgs e)
         {
             if (questionID == 0)
                 MessageBox.Show("Choose on the Question!");
             else
             {
                 // mas pari dut mja fshi opsionet pytjes tani pytjen
                 var options = new OptionsModel();
                 foreach (var item in options.getOptions(questionID))
                 {
                     options.Delete(item.optionID);
                 }

                 var question = new QuestionModel();
                 question.Delete(questionID);
                 ClearFields();
                 MessageBox.Show("Successful deleted question!");
                 ClearFields();
             }
         }


        //update for question - >
         private void UpdateQuestion_Click(object sender, EventArgs e)
         {
           
             if(questionID ==  0)
                 MessageBox.Show("Choose the question!");
             
             else
             {
                 var questionModel = new QuestionModel();
                 questionModel.questionID = questionID;
                 questionModel.questCont = questionCont.Text;
                 questionModel.Update(questionModel);
                 
               
                 var optionModel = new OptionsModel();
                 optionModel.optionID = optionID;
                 optionModel.optionContent = qOne.Text;
                 optionModel.isCorrect = (qOneR.Checked) ? true : false;
                 optionModel.Update(optionModel);

                 var optionModel2 = new OptionsModel();
                 optionModel2.optionID = option2ID;
                 optionModel2.optionContent = qTwo.Text;
                 optionModel2.isCorrect = (qTwoR.Checked) ? true : false;
                 optionModel2.Update(optionModel2);

                 var optionModel3 = new OptionsModel();
                 optionModel3.optionID = option3ID;
                 optionModel3.optionContent = qThree.Text;
                 optionModel3.isCorrect = (qThreeR.Checked) ? true : false;
                 optionModel3.Update(optionModel3);

                 var optionModel4 = new OptionsModel();
                 optionModel4.optionID = option4ID;
                 optionModel4.optionContent = qFour.Text;
                 optionModel4.isCorrect = (qFourR.Checked) ? true : false;
                 optionModel4.Update(optionModel4);


                 fillGridQuizList();
                 fillGridOptionsList(questionID); 
             
                 MessageBox.Show("Successful!");
                 ClearFields();
             }
            

         }

         private void txtSearch_TextChanged(object sender, EventArgs e)
         {
             fillGridQuizList(txtSearch.Text);

         }

      
       

        

    }
}
