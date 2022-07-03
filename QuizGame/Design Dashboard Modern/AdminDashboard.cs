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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            
            InitializeComponent();
        }
        int quizID = 0, userID = 0;
      //  int quizID = new QuizModel();
        private void UpdateMode()
        {
            if (fillGrid_dashboard.Focused)
            {
                if (fillGrid_dashboard.RowCount > 0)
                {


                    quizID = int.Parse(fillGrid_dashboard["QuizID", fillGrid_dashboard.CurrentRow.Index].Value.ToString());
                    //QuizNametxt.Text = QuizList["QuizName", QuizList.CurrentRow.Index].Value.ToString();


                    fillGridQuizList();
                }
            }
        }

        private void fillGridQuizList(string searchText = null)
        {
            fillGrid_dashboard.AutoGenerateColumns = false;
            
            var quiz = new QuizModel();
            fillGrid_dashboard.DataSource = quiz.getQuiz(searchText);
        }

        private void fillGrid_dashboard_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            UpdateMode();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            fillGridQuizList();
            fillGridUserList();
        }



        /// <summary>
        /// Function for User model
        /// </summary>

        //Me kontrollu perseri
        private void UpdateModeUser(int userID)
        {
            if (fillGridUserDash.Focused)
            {
                if (fillGridUserDash.RowCount > 0)
                {


                  userID = int.Parse(fillGridUserDash["UserID", fillGridUserDash.CurrentRow.Index].Value.ToString());
                    // = QuizList["QuizName", QuizList.CurrentRow.Index].Value.ToString();
                    fillGridUserList();
                }
            }
        }

        private void fillGridUserList(string searchText = null)
        {
           


                fillGridUserDash.AutoGenerateColumns = false;
                var user = new UserModel();
                fillGridUserDash.DataSource = user.GetUser(searchText);
           


        }

        private void fillGridUserDash_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            UpdateModeUser(userID);
        }

        private void txtSearchAdmin_TextChange(object sender, EventArgs e)
        {
          
            fillGridUserList(txtSearchAdmin.Text);
            fillGridQuizList(txtSearchAdmin.Text);
        }

       
       
        //private void fillGridUserDash_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    fillGridUserList();
        //}

       


    }
}
