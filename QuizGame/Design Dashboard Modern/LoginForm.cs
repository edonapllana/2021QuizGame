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
using Design_Dashboard_Modern;

namespace Design_Dashboard_Modern
{
    public partial class LoginForm : Form
    {
        int userID;

        //function 
        private UserModel GetNewUser()
        {
            var users = new UserModel()
            {
                
                firstName = txtFirstName.Text,
                lastName = txtLastName.Text,
                email = txtEmailSingUp.Text,
                gender = (rbGenderM.Checked ? "M" : "F"),
                birthday = txtdateBirthday.Value.Date,
                password = txtPassword_S.Text,
                isAdmin = false
            };

            return users;
        }

        //end function
        public LoginForm()
        {
            InitializeComponent();

            //login form;
            bunifuFormDock1.SubscribeControlToDragEvents(panelLogo);
            bunifuFormDock1.SubscribeControlToDragEvents(TabPage1);
            bunifuFormDock1.SubscribeControlToDragEvents(TabPage2);
        }


        //Funksioni qe pastron fushat pasi te plotesohen.
        private void ClearFields()
        {
            userID = 0;
            txtFirstName.Text = txtLastName.Text = txtEmailSingUp.Text = txtPassword.Text = rbGenderM.Text = rbGenderF.Text = txtdateBirthday.Text = "";
            rbGenderM.Checked = true;
            btnSignUp.Enabled = true;
          //  tsbUpdate.Enabled = tsbDelete.Enabled = false;
          //  FillGrid();
        }
        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                var userat = new UserModel();
              
                var useri = userat.Login(email, password);

                if (useri == null)
                    MessageBox.Show("Email or password are wrong!");
                else
                {
                    //kur nuk esht admin kalon te forma GamePlay
                    if (useri.isAdmin == false)
                    {
                        this.Hide();
                        new testprov2(useri.firstName + " " + useri.lastName).Show();
                       // new Dashboard(useri.firstName +""+useri.lastName).Show();
                    }
                    else
                    {
                        //Kalon te forma userAdminit;
                        this.Hide();
                        new Form1(useri.userID).Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("You can't leave the datas empty!");
            }
        }


        //Regjistrimi i userit
        private void btnSignUp_Click(object sender, EventArgs e)
        {

            var users = GetNewUser();
            string msg = users.CheckFileds(users);

            if (string.IsNullOrEmpty(msg))
            {
                bool result = users.Create(users);

                if (result)
                {
                    MessageBox.Show("Registered.");
                    LS.SetPage(0);
                    ClearFields();
                }
                else
                    MessageBox.Show("Mistake while registring!");
            }
            else
            {
                MessageBox.Show(msg);
            }
            // kta mir e paskse
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            LS.SetPage(0);
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            LS.SetPage(1);
        }

        private void login_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFormDock1_FormDragging(object sender, Bunifu.UI.WinForms.BunifuFormDock.FormDraggingEventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void TabPage2_Click(object sender, EventArgs e)
        {

        }

       

        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Minimized;
        }

        private void GenderF_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbGenderF_CheckedChanged(object sender, EventArgs e)
        {

        }

       
    }
}
