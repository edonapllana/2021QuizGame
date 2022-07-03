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
    public partial class userDetails : Form
    {
        public userDetails()
        {
            InitializeComponent();
        }
        int quizID;
        private void UpdateModeQuiz()
        {
            if(gridQuizList.Focused)
            {
                if(gridQuizList.RowCount > 0)
                {
                    quizID = int.Parse(gridQuizList["UserID", gridQuizList.CurrentRow.Index].Value.ToString());
                    fillGridListQuiz();
                }
            }
        }
        private void fillGridListQuiz(string searchText = null)
        {

            gridQuizList.AutoGenerateColumns = false;
            var quiz = new QuizModel();
            gridQuizList.DataSource = quiz.getQuiz(searchText);
        }

        private void userDetails_Load(object sender, EventArgs e)
        {
            fillGridListQuiz();

        }

        private void gridQuizList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            UpdateModeQuiz();
        }

        private void playButonUser_Click(object sender, EventArgs e)
        {
          //  Dashboard frm = new Dashboard("");
            
           
        }
    }
}
