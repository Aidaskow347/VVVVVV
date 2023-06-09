﻿namespace VVVVVV
{
    partial class Form1
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
            System.Windows.Forms.Timer gameTimer;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.xLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.stageOutput = new System.Windows.Forms.Label();
            this.pageTracker = new System.Windows.Forms.Label();
            this.projectileTimer = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.startLabel = new System.Windows.Forms.Label();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.timerOutput = new System.Windows.Forms.Label();
            this.leaderBoardLabel = new System.Windows.Forms.Label();
            this.winLabel = new System.Windows.Forms.Label();
            this.continueButton = new System.Windows.Forms.Button();
            this.leaderBoardInfoLabel = new System.Windows.Forms.Label();
            this.tutorialLabel = new System.Windows.Forms.Label();
            gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            gameTimer.Interval = 10;
            // 
            // xLabel
            // 
            this.xLabel.BackColor = System.Drawing.Color.Transparent;
            this.xLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.xLabel.Location = new System.Drawing.Point(37, 19);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(100, 23);
            this.xLabel.TabIndex = 0;
            this.xLabel.Text = "0";
            this.xLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel.Visible = false;
            // 
            // yLabel
            // 
            this.yLabel.BackColor = System.Drawing.Color.Transparent;
            this.yLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.yLabel.Location = new System.Drawing.Point(37, 52);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(100, 20);
            this.yLabel.TabIndex = 1;
            this.yLabel.Text = "0";
            this.yLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.yLabel.Visible = false;
            // 
            // stageOutput
            // 
            this.stageOutput.BackColor = System.Drawing.Color.Transparent;
            this.stageOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stageOutput.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.stageOutput.Location = new System.Drawing.Point(37, 84);
            this.stageOutput.Name = "stageOutput";
            this.stageOutput.Size = new System.Drawing.Size(100, 23);
            this.stageOutput.TabIndex = 2;
            this.stageOutput.Text = "0";
            this.stageOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.stageOutput.Visible = false;
            // 
            // pageTracker
            // 
            this.pageTracker.BackColor = System.Drawing.Color.Transparent;
            this.pageTracker.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageTracker.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pageTracker.Location = new System.Drawing.Point(37, 117);
            this.pageTracker.Name = "pageTracker";
            this.pageTracker.Size = new System.Drawing.Size(100, 23);
            this.pageTracker.TabIndex = 3;
            this.pageTracker.Text = "0";
            this.pageTracker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pageTracker.Visible = false;
            // 
            // projectileTimer
            // 
            this.projectileTimer.Interval = 1000;
            this.projectileTimer.Tick += new System.EventHandler(this.projectileTimer_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(183, 170);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(168, 161);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(344, 170);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 161);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(508, 170);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(168, 161);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(672, 170);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(168, 161);
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(19, 170);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(168, 161);
            this.pictureBox5.TabIndex = 10;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox7.BackgroundImage")));
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox7.Location = new System.Drawing.Point(833, 170);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(168, 161);
            this.pictureBox7.TabIndex = 12;
            this.pictureBox7.TabStop = false;
            // 
            // startLabel
            // 
            this.startLabel.Font = new System.Drawing.Font("Yu Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.startLabel.Location = new System.Drawing.Point(19, 359);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(982, 38);
            this.startLabel.TabIndex = 13;
            this.startLabel.Text = "Press Space to Start, or K for Controls";
            this.startLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameInput
            // 
            this.nameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameInput.Location = new System.Drawing.Point(453, 450);
            this.nameInput.MaxLength = 3;
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(110, 62);
            this.nameInput.TabIndex = 14;
            this.nameInput.Text = "N/A";
            this.nameInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nameInput.Visible = false;
            // 
            // timerOutput
            // 
            this.timerOutput.BackColor = System.Drawing.Color.Transparent;
            this.timerOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerOutput.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.timerOutput.Location = new System.Drawing.Point(882, -1);
            this.timerOutput.Name = "timerOutput";
            this.timerOutput.Size = new System.Drawing.Size(135, 53);
            this.timerOutput.TabIndex = 15;
            this.timerOutput.Text = "0";
            this.timerOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.timerOutput.Visible = false;
            // 
            // leaderBoardLabel
            // 
            this.leaderBoardLabel.BackColor = System.Drawing.Color.Transparent;
            this.leaderBoardLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderBoardLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.leaderBoardLabel.Location = new System.Drawing.Point(-3, 14);
            this.leaderBoardLabel.Name = "leaderBoardLabel";
            this.leaderBoardLabel.Size = new System.Drawing.Size(1020, 498);
            this.leaderBoardLabel.TabIndex = 16;
            this.leaderBoardLabel.Text = "LeaderBoard";
            this.leaderBoardLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.leaderBoardLabel.Visible = false;
            // 
            // winLabel
            // 
            this.winLabel.BackColor = System.Drawing.Color.Transparent;
            this.winLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.winLabel.Location = new System.Drawing.Point(232, 383);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(554, 64);
            this.winLabel.TabIndex = 17;
            this.winLabel.Text = "Congrats! You Made it To The End! Enter Your Name and Continue";
            this.winLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.winLabel.Visible = false;
            // 
            // continueButton
            // 
            this.continueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.Location = new System.Drawing.Point(427, 518);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(159, 54);
            this.continueButton.TabIndex = 18;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Visible = false;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // leaderBoardInfoLabel
            // 
            this.leaderBoardInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.leaderBoardInfoLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderBoardInfoLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.leaderBoardInfoLabel.Location = new System.Drawing.Point(0, 531);
            this.leaderBoardInfoLabel.Name = "leaderBoardInfoLabel";
            this.leaderBoardInfoLabel.Size = new System.Drawing.Size(1017, 64);
            this.leaderBoardInfoLabel.TabIndex = 19;
            this.leaderBoardInfoLabel.Text = "Press Space to be sent to the Start Screen";
            this.leaderBoardInfoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.leaderBoardInfoLabel.Visible = false;
            // 
            // tutorialLabel
            // 
            this.tutorialLabel.BackColor = System.Drawing.Color.Transparent;
            this.tutorialLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tutorialLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.tutorialLabel.Location = new System.Drawing.Point(9, 42);
            this.tutorialLabel.Name = "tutorialLabel";
            this.tutorialLabel.Size = new System.Drawing.Size(453, 432);
            this.tutorialLabel.TabIndex = 20;
            this.tutorialLabel.Text = "Tutorial Level";
            this.tutorialLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tutorialLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1017, 641);
            this.Controls.Add(this.tutorialLabel);
            this.Controls.Add(this.leaderBoardInfoLabel);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.winLabel);
            this.Controls.Add(this.leaderBoardLabel);
            this.Controls.Add(this.timerOutput);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pageTracker);
            this.Controls.Add(this.stageOutput);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.xLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label stageOutput;
        private System.Windows.Forms.Label pageTracker;
        private System.Windows.Forms.Timer projectileTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.Label timerOutput;
        private System.Windows.Forms.Label leaderBoardLabel;
        private System.Windows.Forms.Label winLabel;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Label leaderBoardInfoLabel;
        private System.Windows.Forms.Label tutorialLabel;
    }
}

