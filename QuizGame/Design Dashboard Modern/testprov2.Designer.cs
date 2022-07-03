namespace Design_Dashboard_Modern
{
    partial class testprov2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.BtnD = new System.Windows.Forms.Button();
            this.BtnC = new System.Windows.Forms.Button();
            this.BtnB = new System.Windows.Forms.Button();
            this.BtnA = new System.Windows.Forms.Button();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblTimer.ForeColor = System.Drawing.Color.White;
            this.lblTimer.Location = new System.Drawing.Point(547, 115);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(117, 37);
            this.lblTimer.TabIndex = 33;
            this.lblTimer.Text = "Timer: 0";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(547, 61);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(114, 37);
            this.lblScore.TabIndex = 32;
            this.lblScore.Text = "Score: 0";
            // 
            // BtnD
            // 
            this.BtnD.BackColor = System.Drawing.Color.White;
            this.BtnD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnD.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.BtnD.ForeColor = System.Drawing.Color.Purple;
            this.BtnD.Location = new System.Drawing.Point(469, 414);
            this.BtnD.Name = "BtnD";
            this.BtnD.Size = new System.Drawing.Size(200, 70);
            this.BtnD.TabIndex = 29;
            this.BtnD.Text = "D";
            this.BtnD.UseVisualStyleBackColor = false;
            this.BtnD.Click += new System.EventHandler(this.BtnD_Click);
            // 
            // BtnC
            // 
            this.BtnC.BackColor = System.Drawing.Color.White;
            this.BtnC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnC.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.BtnC.ForeColor = System.Drawing.Color.Purple;
            this.BtnC.Location = new System.Drawing.Point(469, 320);
            this.BtnC.Name = "BtnC";
            this.BtnC.Size = new System.Drawing.Size(200, 70);
            this.BtnC.TabIndex = 28;
            this.BtnC.Text = "C";
            this.BtnC.UseVisualStyleBackColor = false;
            this.BtnC.Click += new System.EventHandler(this.BtnC_Click);
            // 
            // BtnB
            // 
            this.BtnB.BackColor = System.Drawing.Color.White;
            this.BtnB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnB.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.BtnB.ForeColor = System.Drawing.Color.Purple;
            this.BtnB.Location = new System.Drawing.Point(109, 414);
            this.BtnB.Name = "BtnB";
            this.BtnB.Size = new System.Drawing.Size(200, 70);
            this.BtnB.TabIndex = 27;
            this.BtnB.Text = "B";
            this.BtnB.UseVisualStyleBackColor = false;
            this.BtnB.Click += new System.EventHandler(this.BtnB_Click);
            // 
            // BtnA
            // 
            this.BtnA.BackColor = System.Drawing.Color.White;
            this.BtnA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnA.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.BtnA.ForeColor = System.Drawing.Color.Purple;
            this.BtnA.Location = new System.Drawing.Point(110, 320);
            this.BtnA.Name = "BtnA";
            this.BtnA.Size = new System.Drawing.Size(200, 70);
            this.BtnA.TabIndex = 26;
            this.BtnA.Text = "A";
            this.BtnA.UseVisualStyleBackColor = false;
            this.BtnA.Click += new System.EventHandler(this.BtnA_Click);
            // 
            // txtQuestion
            // 
            this.txtQuestion.BackColor = System.Drawing.Color.White;
            this.txtQuestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuestion.Font = new System.Drawing.Font("Segoe UI Semibold", 0.15F, System.Drawing.FontStyle.Bold);
            this.txtQuestion.ForeColor = System.Drawing.Color.Purple;
            this.txtQuestion.Location = new System.Drawing.Point(110, 242);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.ReadOnly = true;
            this.txtQuestion.Size = new System.Drawing.Size(560, 60);
            this.txtQuestion.TabIndex = 21;
            this.txtQuestion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(818, 27);
            this.menuStrip1.TabIndex = 34;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainMenuToolStripMenuItem
            // 
            this.mainMenuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mainMenuToolStripMenuItem.Name = "mainMenuToolStripMenuItem";
            this.mainMenuToolStripMenuItem.Size = new System.Drawing.Size(92, 23);
            this.mainMenuToolStripMenuItem.Text = "Main Menu";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(342, 516);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 42);
            this.button1.TabIndex = 35;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // testprov2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(818, 614);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.BtnD);
            this.Controls.Add(this.BtnC);
            this.Controls.Add(this.BtnB);
            this.Controls.Add(this.BtnA);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.menuStrip1);
            this.Name = "testprov2";
            this.Text = "testprov2";
            this.Load += new System.EventHandler(this.testprov2_Load_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button BtnD;
        private System.Windows.Forms.Button BtnC;
        private System.Windows.Forms.Button BtnB;
        private System.Windows.Forms.Button BtnA;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainMenuToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button button1;
    }
}