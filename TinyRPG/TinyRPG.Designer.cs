namespace TinyRPG
{
    partial class TinyRPG
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHitPoints = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblExperience = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboWeapons = new System.Windows.Forms.ComboBox();
            this.cboPotions = new System.Windows.Forms.ComboBox();
            this.btnUseWeapon = new System.Windows.Forms.Button();
            this.btnUsePotion = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.rtbLocation = new System.Windows.Forms.RichTextBox();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.dgvQuests = new System.Windows.Forms.DataGridView();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblInventory = new System.Windows.Forms.Label();
            this.lblMovement = new System.Windows.Forms.Label();
            this.lblStats = new System.Windows.Forms.Label();
            this.btnViewInventory = new System.Windows.Forms.Button();
            this.btnViewQuests = new System.Windows.Forms.Button();
            this.lblQuests = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).BeginInit();
            this.pnlStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hit Points:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gold:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 63);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Experience:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Level:";
            // 
            // lblHitPoints
            // 
            this.lblHitPoints.AutoSize = true;
            this.lblHitPoints.Location = new System.Drawing.Point(94, 8);
            this.lblHitPoints.Name = "lblHitPoints";
            this.lblHitPoints.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblHitPoints.Size = new System.Drawing.Size(0, 17);
            this.lblHitPoints.TabIndex = 4;
            this.lblHitPoints.Click += new System.EventHandler(this.lblHitPoints_Click);
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(94, 34);
            this.lblGold.Name = "lblGold";
            this.lblGold.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblGold.Size = new System.Drawing.Size(0, 17);
            this.lblGold.TabIndex = 5;
            this.lblGold.Click += new System.EventHandler(this.lblGold_Click);
            // 
            // lblExperience
            // 
            this.lblExperience.AutoSize = true;
            this.lblExperience.Location = new System.Drawing.Point(94, 62);
            this.lblExperience.Name = "lblExperience";
            this.lblExperience.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblExperience.Size = new System.Drawing.Size(0, 17);
            this.lblExperience.TabIndex = 6;
            this.lblExperience.Click += new System.EventHandler(this.lblExperience_Click);
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(94, 88);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblLevel.Size = new System.Drawing.Size(0, 17);
            this.lblLevel.TabIndex = 7;
            this.lblLevel.Click += new System.EventHandler(this.lblLevel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(623, 412);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Select Action";
            // 
            // cboWeapons
            // 
            this.cboWeapons.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWeapons.FormattingEnabled = true;
            this.cboWeapons.Location = new System.Drawing.Point(488, 453);
            this.cboWeapons.Name = "cboWeapons";
            this.cboWeapons.Size = new System.Drawing.Size(121, 25);
            this.cboWeapons.TabIndex = 9;
            // 
            // cboPotions
            // 
            this.cboPotions.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPotions.FormattingEnabled = true;
            this.cboPotions.Location = new System.Drawing.Point(488, 485);
            this.cboPotions.Name = "cboPotions";
            this.cboPotions.Size = new System.Drawing.Size(121, 25);
            this.cboPotions.TabIndex = 10;
            // 
            // btnUseWeapon
            // 
            this.btnUseWeapon.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUseWeapon.Location = new System.Drawing.Point(626, 453);
            this.btnUseWeapon.Name = "btnUseWeapon";
            this.btnUseWeapon.Size = new System.Drawing.Size(75, 23);
            this.btnUseWeapon.TabIndex = 11;
            this.btnUseWeapon.Text = "Use";
            this.btnUseWeapon.UseVisualStyleBackColor = true;
            this.btnUseWeapon.Click += new System.EventHandler(this.btnUseWeapon_Click);
            // 
            // btnUsePotion
            // 
            this.btnUsePotion.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsePotion.Location = new System.Drawing.Point(626, 487);
            this.btnUsePotion.Name = "btnUsePotion";
            this.btnUsePotion.Size = new System.Drawing.Size(75, 23);
            this.btnUsePotion.TabIndex = 12;
            this.btnUsePotion.Text = "Use";
            this.btnUsePotion.UseVisualStyleBackColor = true;
            this.btnUsePotion.Click += new System.EventHandler(this.btnUsePotion_Click);
            // 
            // btnForward
            // 
            this.btnForward.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnForward.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 16F);
            this.btnForward.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnForward.Location = new System.Drawing.Point(516, 245);
            this.btnForward.Name = "btnForward";
            this.btnForward.Padding = new System.Windows.Forms.Padding(3, 0, 0, 5);
            this.btnForward.Size = new System.Drawing.Size(46, 46);
            this.btnForward.TabIndex = 13;
            this.btnForward.Text = "▲";
            this.btnForward.UseVisualStyleBackColor = false;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRight.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 16F);
            this.btnRight.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnRight.Location = new System.Drawing.Point(566, 295);
            this.btnRight.Name = "btnRight";
            this.btnRight.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnRight.Size = new System.Drawing.Size(46, 46);
            this.btnRight.TabIndex = 14;
            this.btnRight.Text = "▶";
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBack.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 16F);
            this.btnBack.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnBack.Location = new System.Drawing.Point(516, 347);
            this.btnBack.Name = "btnBack";
            this.btnBack.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.btnBack.Size = new System.Drawing.Size(46, 46);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "▼";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLeft.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 16F);
            this.btnLeft.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnLeft.Location = new System.Drawing.Point(467, 295);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btnLeft.Size = new System.Drawing.Size(46, 46);
            this.btnLeft.TabIndex = 16;
            this.btnLeft.Text = "◀";
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // rtbLocation
            // 
            this.rtbLocation.Font = new System.Drawing.Font("Berlin Sans FB", 9F);
            this.rtbLocation.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rtbLocation.Location = new System.Drawing.Point(17, 26);
            this.rtbLocation.Name = "rtbLocation";
            this.rtbLocation.ReadOnly = true;
            this.rtbLocation.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbLocation.Size = new System.Drawing.Size(321, 84);
            this.rtbLocation.TabIndex = 17;
            this.rtbLocation.Text = "";
            // 
            // rtbMessages
            // 
            this.rtbMessages.Font = new System.Drawing.Font("Berlin Sans FB", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMessages.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rtbMessages.Location = new System.Drawing.Point(17, 121);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.ReadOnly = true;
            this.rtbMessages.Size = new System.Drawing.Size(321, 234);
            this.rtbMessages.TabIndex = 18;
            this.rtbMessages.Text = "";
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AllowUserToResizeColumns = false;
            this.dgvInventory.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvInventory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventory.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInventory.Enabled = false;
            this.dgvInventory.Location = new System.Drawing.Point(17, 393);
            this.dgvInventory.MultiSelect = false;
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersWidth = 51;
            this.dgvInventory.RowTemplate.Height = 24;
            this.dgvInventory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvInventory.Size = new System.Drawing.Size(312, 155);
            this.dgvInventory.TabIndex = 19;
            this.dgvInventory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventory_CellContentClick);
            // 
            // dgvQuests
            // 
            this.dgvQuests.AllowUserToAddRows = false;
            this.dgvQuests.AllowUserToDeleteRows = false;
            this.dgvQuests.AllowUserToResizeRows = false;
            this.dgvQuests.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvQuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvQuests.Enabled = false;
            this.dgvQuests.Location = new System.Drawing.Point(17, 393);
            this.dgvQuests.MultiSelect = false;
            this.dgvQuests.Name = "dgvQuests";
            this.dgvQuests.ReadOnly = true;
            this.dgvQuests.RowHeadersWidth = 51;
            this.dgvQuests.RowTemplate.Height = 24;
            this.dgvQuests.RowTemplate.ReadOnly = true;
            this.dgvQuests.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvQuests.Size = new System.Drawing.Size(312, 155);
            this.dgvQuests.TabIndex = 20;
            // 
            // pnlStats
            // 
            this.pnlStats.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlStats.Controls.Add(this.lblLevel);
            this.pnlStats.Controls.Add(this.lblExperience);
            this.pnlStats.Controls.Add(this.lblGold);
            this.pnlStats.Controls.Add(this.lblHitPoints);
            this.pnlStats.Controls.Add(this.label4);
            this.pnlStats.Controls.Add(this.label3);
            this.pnlStats.Controls.Add(this.label2);
            this.pnlStats.Controls.Add(this.label1);
            this.pnlStats.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlStats.Location = new System.Drawing.Point(445, 59);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(196, 115);
            this.pnlStats.TabIndex = 21;
            // 
            // lblInventory
            // 
            this.lblInventory.AutoSize = true;
            this.lblInventory.BackColor = System.Drawing.Color.Transparent;
            this.lblInventory.Font = new System.Drawing.Font("Berlin Sans FB", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInventory.Location = new System.Drawing.Point(122, 358);
            this.lblInventory.Name = "lblInventory";
            this.lblInventory.Size = new System.Drawing.Size(104, 26);
            this.lblInventory.TabIndex = 22;
            this.lblInventory.Text = "Inventory";
            this.lblInventory.Click += new System.EventHandler(this.lblInventory_Click);
            // 
            // lblMovement
            // 
            this.lblMovement.AutoSize = true;
            this.lblMovement.BackColor = System.Drawing.Color.Transparent;
            this.lblMovement.Font = new System.Drawing.Font("Berlin Sans FB", 14F);
            this.lblMovement.ForeColor = System.Drawing.Color.White;
            this.lblMovement.Location = new System.Drawing.Point(474, 200);
            this.lblMovement.Name = "lblMovement";
            this.lblMovement.Size = new System.Drawing.Size(121, 26);
            this.lblMovement.TabIndex = 24;
            this.lblMovement.Text = "Movement";
            this.lblMovement.Click += new System.EventHandler(this.lblMovement_Click);
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.BackColor = System.Drawing.Color.Transparent;
            this.lblStats.Font = new System.Drawing.Font("Berlin Sans FB", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStats.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblStats.Location = new System.Drawing.Point(519, 26);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(59, 26);
            this.lblStats.TabIndex = 25;
            this.lblStats.Text = "Stats";
            // 
            // btnViewInventory
            // 
            this.btnViewInventory.Location = new System.Drawing.Point(344, 447);
            this.btnViewInventory.Name = "btnViewInventory";
            this.btnViewInventory.Size = new System.Drawing.Size(121, 31);
            this.btnViewInventory.TabIndex = 26;
            this.btnViewInventory.Text = "View Inventory";
            this.btnViewInventory.UseVisualStyleBackColor = true;
            this.btnViewInventory.Click += new System.EventHandler(this.btnViewInventory_Click);
            // 
            // btnViewQuests
            // 
            this.btnViewQuests.Location = new System.Drawing.Point(344, 484);
            this.btnViewQuests.Name = "btnViewQuests";
            this.btnViewQuests.Size = new System.Drawing.Size(121, 31);
            this.btnViewQuests.TabIndex = 27;
            this.btnViewQuests.Text = "View Quests";
            this.btnViewQuests.UseVisualStyleBackColor = true;
            this.btnViewQuests.Click += new System.EventHandler(this.btnViewQuests_Click);
            // 
            // lblQuests
            // 
            this.lblQuests.BackColor = System.Drawing.Color.Transparent;
            this.lblQuests.Font = new System.Drawing.Font("Berlin Sans FB", 13.8F);
            this.lblQuests.ForeColor = System.Drawing.Color.White;
            this.lblQuests.Location = new System.Drawing.Point(104, 358);
            this.lblQuests.Name = "lblQuests";
            this.lblQuests.Size = new System.Drawing.Size(142, 26);
            this.lblQuests.TabIndex = 23;
            this.lblQuests.Text = "Quests";
            this.lblQuests.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblQuests.Click += new System.EventHandler(this.lblQuests_Click);
            // 
            // TinyRPG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::TinyRPG.Properties.Resources.istockphoto_457551271_612x612;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(722, 563);
            this.Controls.Add(this.btnViewQuests);
            this.Controls.Add(this.btnViewInventory);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.lblMovement);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.rtbMessages);
            this.Controls.Add(this.rtbLocation);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnUsePotion);
            this.Controls.Add(this.btnUseWeapon);
            this.Controls.Add(this.cboPotions);
            this.Controls.Add(this.cboWeapons);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblInventory);
            this.Controls.Add(this.lblQuests);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.dgvQuests);
            this.DoubleBuffered = true;
            this.Name = "TinyRPG";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tiny RPG";
            this.Load += new System.EventHandler(this.TinyRPG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).EndInit();
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHitPoints;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboWeapons;
        private System.Windows.Forms.ComboBox cboPotions;
        private System.Windows.Forms.Button btnUseWeapon;
        private System.Windows.Forms.Button btnUsePotion;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.RichTextBox rtbLocation;
        private System.Windows.Forms.RichTextBox rtbMessages;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.DataGridView dgvQuests;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblInventory;
        private System.Windows.Forms.Label lblMovement;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Button btnViewInventory;
        private System.Windows.Forms.Button btnViewQuests;
        private System.Windows.Forms.Label lblQuests;
    }
}

