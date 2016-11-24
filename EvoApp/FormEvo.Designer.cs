namespace EvoApp
{
    partial class FormEvo
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
            this.lblGenLabel = new System.Windows.Forms.Label();
            this.lblGen = new System.Windows.Forms.Label();
            this.lblIterLabel = new System.Windows.Forms.Label();
            this.lblIter = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.selDelay = new System.Windows.Forms.ComboBox();
            this.lblDelayLabel = new System.Windows.Forms.Label();
            this.cbIterEnabled = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbGrid = new System.Windows.Forms.PictureBox();
            this.txtIter = new System.Windows.Forms.TextBox();
            this.statusStatistics = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGenLabel
            // 
            this.lblGenLabel.AutoSize = true;
            this.lblGenLabel.Location = new System.Drawing.Point(1160, 7);
            this.lblGenLabel.Name = "lblGenLabel";
            this.lblGenLabel.Size = new System.Drawing.Size(33, 13);
            this.lblGenLabel.TabIndex = 0;
            this.lblGenLabel.Text = "GEN:";
            // 
            // lblGen
            // 
            this.lblGen.AutoSize = true;
            this.lblGen.Location = new System.Drawing.Point(1219, 9);
            this.lblGen.Name = "lblGen";
            this.lblGen.Size = new System.Drawing.Size(10, 13);
            this.lblGen.TabIndex = 1;
            this.lblGen.Text = "-";
            // 
            // lblIterLabel
            // 
            this.lblIterLabel.AutoSize = true;
            this.lblIterLabel.Location = new System.Drawing.Point(1158, 30);
            this.lblIterLabel.Name = "lblIterLabel";
            this.lblIterLabel.Size = new System.Drawing.Size(35, 13);
            this.lblIterLabel.TabIndex = 2;
            this.lblIterLabel.Text = "ITER:";
            // 
            // lblIter
            // 
            this.lblIter.AutoSize = true;
            this.lblIter.Location = new System.Drawing.Point(1219, 30);
            this.lblIter.Name = "lblIter";
            this.lblIter.Size = new System.Drawing.Size(10, 13);
            this.lblIter.TabIndex = 3;
            this.lblIter.Text = "-";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(939, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(1020, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // selDelay
            // 
            this.selDelay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selDelay.FormattingEnabled = true;
            this.selDelay.Location = new System.Drawing.Point(177, 3);
            this.selDelay.Name = "selDelay";
            this.selDelay.Size = new System.Drawing.Size(121, 21);
            this.selDelay.TabIndex = 7;
            this.selDelay.SelectedIndexChanged += new System.EventHandler(this.selDelay_SelectedIndexChanged);
            // 
            // lblDelayLabel
            // 
            this.lblDelayLabel.AutoSize = true;
            this.lblDelayLabel.Location = new System.Drawing.Point(136, 8);
            this.lblDelayLabel.Name = "lblDelayLabel";
            this.lblDelayLabel.Size = new System.Drawing.Size(35, 13);
            this.lblDelayLabel.TabIndex = 8;
            this.lblDelayLabel.Text = "delay:";
            // 
            // cbIterEnabled
            // 
            this.cbIterEnabled.AutoSize = true;
            this.cbIterEnabled.Location = new System.Drawing.Point(13, 7);
            this.cbIterEnabled.Name = "cbIterEnabled";
            this.cbIterEnabled.Size = new System.Drawing.Size(104, 17);
            this.cbIterEnabled.TabIndex = 10;
            this.cbIterEnabled.Text = "iteration enabled";
            this.cbIterEnabled.UseVisualStyleBackColor = true;
            this.cbIterEnabled.CheckedChanged += new System.EventHandler(this.cbIterEnabled_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.statusStatistics});
            this.statusStrip1.Location = new System.Drawing.Point(0, 691);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1309, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(12, 17);
            this.statusLabel.Text = "-";
            // 
            // pbGrid
            // 
            this.pbGrid.Location = new System.Drawing.Point(13, 30);
            this.pbGrid.Name = "pbGrid";
            this.pbGrid.Size = new System.Drawing.Size(1082, 578);
            this.pbGrid.TabIndex = 12;
            this.pbGrid.TabStop = false;
            // 
            // txtIter
            // 
            this.txtIter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIter.Location = new System.Drawing.Point(1161, 47);
            this.txtIter.Multiline = true;
            this.txtIter.Name = "txtIter";
            this.txtIter.ReadOnly = true;
            this.txtIter.Size = new System.Drawing.Size(100, 561);
            this.txtIter.TabIndex = 13;
            // 
            // statusStatistics
            // 
            this.statusStatistics.Name = "statusStatistics";
            this.statusStatistics.Size = new System.Drawing.Size(12, 17);
            this.statusStatistics.Text = "-";
            // 
            // FormEvo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 713);
            this.Controls.Add(this.txtIter);
            this.Controls.Add(this.pbGrid);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cbIterEnabled);
            this.Controls.Add(this.lblDelayLabel);
            this.Controls.Add(this.selDelay);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblIter);
            this.Controls.Add(this.lblIterLabel);
            this.Controls.Add(this.lblGen);
            this.Controls.Add(this.lblGenLabel);
            this.Name = "FormEvo";
            this.Text = "Evolution v1.1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormEvo_FormClosed);
            this.Load += new System.EventHandler(this.FormEvo_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormEvo_Paint);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGenLabel;
        private System.Windows.Forms.Label lblGen;
        private System.Windows.Forms.Label lblIterLabel;
        private System.Windows.Forms.Label lblIter;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ComboBox selDelay;
        private System.Windows.Forms.Label lblDelayLabel;
        private System.Windows.Forms.CheckBox cbIterEnabled;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.PictureBox pbGrid;
        private System.Windows.Forms.TextBox txtIter;
        private System.Windows.Forms.ToolStripStatusLabel statusStatistics;
    }
}