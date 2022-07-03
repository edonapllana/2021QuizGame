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
    public partial class Dashboard : Form
    {
        private string a;
        public string emri { get; set; }

        public Dashboard(string a)
        {
            emri = a;
            InitializeComponent();
        }

    

        //Function 
        private void ShowMenu(object Menuform)
        {
            if (this.panelContent.Controls.Count > 0)
                this.panelContent.Controls.RemoveAt(0);

            userDetails me = Menuform as userDetails;
            me.TopLevel = false;
            me.Dock = DockStyle.Fill;
            this.panelContent.Controls.Add(me);
            this.panelContent.Tag = me;
            me.Show();

        }
        private void menuSettings(object Menuform)
        {
            if (this.panelContent.Controls.Count > 0)
                this.panelContent.Controls.RemoveAt(0);

            userSettings me = Menuform as userSettings;
            me.TopLevel = false;
            me.Dock = DockStyle.Fill;
            this.panelContent.Controls.Add(me);
            this.panelContent.Tag = me;
            me.Show();

        }
        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            ShowMenu(new userDetails());
        }
    
 
        private void PanelChart_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
           menuSettings(new userSettings());
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //lblProfile.Text = emri;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblProfile.Text = emri;
           
          //  lblProfile.Text = Font(12px);
          //  lblProfile.text = PaddingChanged();

        }


        
        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {

            new LoginForm().Show();
            this.Close();
        //    new LoginForm().Visible = true;
        //    Dashboard frm = new Dashboard(a);
        //    frm.Visible = false;
        ////    this.Hide(new Dashboard(a));
        //    frm.Exit();
    
        //   // this.Close();
           
            
           
        }
        private void Exit()
        {
            Dashboard frm = new Dashboard(a);

        }



       
    }
}
