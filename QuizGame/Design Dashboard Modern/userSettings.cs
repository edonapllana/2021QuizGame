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
    public partial class userSettings : Form
    {
        public userSettings()
        {
            InitializeComponent();
            
        }
        int userID =0;
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            
            
             if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
             {
                         
             if(userID==0)
                
                 MessageBox.Show("TEST");
    
             else
             {
                 var user = new UserModel();
                 user.Delete(userID);
                 MessageBox.Show("Successful delete user!");
                

                 //Funksion qe del nga forma pasi te fshihet useri'
                 LoginForm me = new LoginForm();
                 me.Close();
             }
                
             }
         }
   }

        
   
}
