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
    public partial class QuizFinished : Form
    {
        public string user { get; set; }
        public QuizFinished(string u)
        {
            user = u;
            InitializeComponent();
        }
        public int score = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            new testprov2(user).Show();
            this.Hide();
        }

        private void QuizFinished_Load(object sender, EventArgs e)
        {
            lblScore.Text = "Score: " + score;
        }

        private void lblScore_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Dashboard(user).Show();
        }
    }
}
