namespace TinyRPG
{
    partial class StartScreen
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
            this.lblStartScreenTitle = new System.Windows.Forms.Label();
            this.lblStartScreenClassInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartScreenStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStartScreenTitle
            // 
            this.lblStartScreenTitle.AutoSize = true;
            this.lblStartScreenTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblStartScreenTitle.Font = new System.Drawing.Font("Berlin Sans FB", 78F);
            this.lblStartScreenTitle.Location = new System.Drawing.Point(91, 43);
            this.lblStartScreenTitle.Name = "lblStartScreenTitle";
            this.lblStartScreenTitle.Size = new System.Drawing.Size(564, 143);
            this.lblStartScreenTitle.TabIndex = 0;
            this.lblStartScreenTitle.Text = "Tiny RPG";            
            // 
            // lblStartScreenClassInfo
            // 
            this.lblStartScreenClassInfo.AutoSize = true;
            this.lblStartScreenClassInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblStartScreenClassInfo.Font = new System.Drawing.Font("Berlin Sans FB", 14F);
            this.lblStartScreenClassInfo.Location = new System.Drawing.Point(460, 498);
            this.lblStartScreenClassInfo.Name = "lblStartScreenClassInfo";
            this.lblStartScreenClassInfo.Size = new System.Drawing.Size(238, 26);
            this.lblStartScreenClassInfo.TabIndex = 1;
            this.lblStartScreenClassInfo.Text = "CSC-260 - Spring 2022";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB", 14F);
            this.label1.Location = new System.Drawing.Point(498, 472);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Jon Kern-Anderson";
            // 
            // btnStartScreenStart
            // 
            this.btnStartScreenStart.Font = new System.Drawing.Font("Berlin Sans FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartScreenStart.Location = new System.Drawing.Point(254, 246);
            this.btnStartScreenStart.Name = "btnStartScreenStart";
            this.btnStartScreenStart.Size = new System.Drawing.Size(247, 71);
            this.btnStartScreenStart.TabIndex = 3;
            this.btnStartScreenStart.Text = "Start Game";
            this.btnStartScreenStart.UseVisualStyleBackColor = true;
            this.btnStartScreenStart.Click += new System.EventHandler(this.btnStartGame);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TinyRPG.Properties.Resources.StartScreenCropped;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(722, 563);
            this.Controls.Add(this.btnStartScreenStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStartScreenClassInfo);
            this.Controls.Add(this.lblStartScreenTitle);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StartScreen";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStartScreenTitle;
        private System.Windows.Forms.Label lblStartScreenClassInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartScreenStart;
    }
}