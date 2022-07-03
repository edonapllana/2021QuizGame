using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design_Dashboard_Modern
{
    public partial class Form1 : Form
    {
       
        public int userID { get; set; }
      
        public Form1(int u)
        {
            //KONSTRUKTOR
            userID = u;
            InitializeComponent();
         
        }
       



        //Function for ShowMenu sidebar
        private void ShowMenu(object Menuform)
        {
            if (this.adminpanel.Controls.Count > 0)
                this.adminpanel.Controls.RemoveAt(0);

            AdminDashboard me = Menuform as AdminDashboard;
            me.TopLevel = false;
            me.Dock = DockStyle.Fill;
            this.adminpanel.Controls.Add(me);
            this.adminpanel.Tag = me;
            me.Show();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Maximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Maximizar.Visible = false;
            Restaurar.Visible = true;
        }

        private void Restaurar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Restaurar.Visible = false;
            Maximizar.Visible = true;
        }

        private void MenuSidebar_Click(object sender, EventArgs e)
        {
            if(Sidebar.Width == 270)
            {
              //  Sidebar.Visible = false;
                Sidebar.Width = 68;
                SidebarWrapper.Width = 90;
                LineaSidebar.Width = 52;
                //AnimacionSidebar.Show(Sidebar);
            }
            else
            {
               // Sidebar.Visible = false;
                Sidebar.Width = 270;
                SidebarWrapper.Width = 300;
                LineaSidebar.Width = 252;
               // AnimacionSidebarBack.Show(Sidebar);
            }
        }

      

        private void Sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LineaSidebar_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

            
        }

        private void MenuTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
           
            //ShowMenu(new AdminDashboard());
            ShowMenu(new AdminDashboard());
            //Form dashb = new userDetails();
            //this.Hide();
            //dashb.Show();
            //this.Close();
        }
     
        private void PanelChart_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
        
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {


            menuQuiz(new QuizCreate(userID));
        }

        //functioon for create quiz show menu sidebar
        private void menuQuiz(object Menuform)
        {
            if (this.adminpanel.Controls.Count > 0)
                this.adminpanel.Controls.RemoveAt(0);

            QuizCreate me = Menuform as QuizCreate;
            me.TopLevel = false;
            me.Dock = DockStyle.Fill;
            this.adminpanel.Controls.Add(me);
            this.adminpanel.Tag = me;
            me.Show();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Wrapper_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SidebarWrapper_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        

       
    }
}
