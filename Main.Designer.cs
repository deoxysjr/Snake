namespace Snake
{
    partial class Main
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
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.HighScore = new System.Windows.Forms.Label();
            this.highscorelabel = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGameOver = new System.Windows.Forms.Label();
            this.Startbutton = new System.Windows.Forms.Button();
            this.AddUser = new System.Windows.Forms.Button();
            this.SellectUser = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbCanvas
            // 
            this.pbCanvas.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pbCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCanvas.Location = new System.Drawing.Point(12, 39);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(500, 500);
            this.pbCanvas.TabIndex = 0;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.PbCanvas_Paint);
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 1000;
            this.GameTimer.Tick += new System.EventHandler(this.UpdateScreen);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.HighScore);
            this.panel1.Controls.Add(this.highscorelabel);
            this.panel1.Controls.Add(this.lblScore);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(518, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 500);
            this.panel1.TabIndex = 1;
            // 
            // HighScore
            // 
            this.HighScore.AutoSize = true;
            this.HighScore.Location = new System.Drawing.Point(13, 63);
            this.HighScore.Name = "HighScore";
            this.HighScore.Size = new System.Drawing.Size(0, 13);
            this.HighScore.TabIndex = 3;
            // 
            // highscorelabel
            // 
            this.highscorelabel.AutoSize = true;
            this.highscorelabel.Location = new System.Drawing.Point(13, 39);
            this.highscorelabel.Name = "highscorelabel";
            this.highscorelabel.Size = new System.Drawing.Size(55, 13);
            this.highscorelabel.TabIndex = 2;
            this.highscorelabel.Text = "Highscore";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(57, 13);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(16, 13);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = " 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Score: ";
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOver.Location = new System.Drawing.Point(30, 52);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(263, 39);
            this.lblGameOver.TabIndex = 2;
            this.lblGameOver.Text = "game over label";
            this.lblGameOver.Visible = false;
            // 
            // Startbutton
            // 
            this.Startbutton.Location = new System.Drawing.Point(12, 12);
            this.Startbutton.Name = "Startbutton";
            this.Startbutton.Size = new System.Drawing.Size(75, 21);
            this.Startbutton.TabIndex = 3;
            this.Startbutton.Text = "Start";
            this.Startbutton.UseVisualStyleBackColor = true;
            this.Startbutton.Click += new System.EventHandler(this.Startbutton_Click);
            // 
            // AddUser
            // 
            this.AddUser.Location = new System.Drawing.Point(93, 12);
            this.AddUser.Name = "AddUser";
            this.AddUser.Size = new System.Drawing.Size(75, 21);
            this.AddUser.TabIndex = 4;
            this.AddUser.Text = "Add User";
            this.AddUser.UseVisualStyleBackColor = true;
            this.AddUser.Click += new System.EventHandler(this.AddUser_Click);
            // 
            // SellectUser
            // 
            this.SellectUser.FormattingEnabled = true;
            this.SellectUser.Location = new System.Drawing.Point(174, 12);
            this.SellectUser.MaxDropDownItems = 20;
            this.SellectUser.Name = "SellectUser";
            this.SellectUser.Size = new System.Drawing.Size(180, 21);
            this.SellectUser.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(734, 551);
            this.Controls.Add(this.SellectUser);
            this.Controls.Add(this.AddUser);
            this.Controls.Add(this.Startbutton);
            this.Controls.Add(this.lblGameOver);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbCanvas);
            this.Name = "Main";
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.Label highscorelabel;
        private System.Windows.Forms.Label HighScore;
        private System.Windows.Forms.Button Startbutton;
        private System.Windows.Forms.Button AddUser;
        public System.Windows.Forms.ComboBox SellectUser;
        private System.Windows.Forms.Label label2;
    }
}

