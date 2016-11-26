namespace Evo2App
{
    partial class FormEvo
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnDebug = new System.Windows.Forms.Button();
            this.lblEventVia = new System.Windows.Forms.Label();
            this.cbEventVia = new System.Windows.Forms.ComboBox();
            this.lblDelay = new System.Windows.Forms.Label();
            this.cbDelay = new System.Windows.Forms.ComboBox();
            this.cbOneEvent = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbGrid = new System.Windows.Forms.PictureBox();
            this.lblIter = new System.Windows.Forms.Label();
            this.lblIterLabel = new System.Windows.Forms.Label();
            this.lblGen = new System.Windows.Forms.Label();
            this.lblGenLabel = new System.Windows.Forms.Label();
            this.txtHistory = new System.Windows.Forms.TextBox();
            this.slblResultIteration = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblIterBest = new System.Windows.Forms.Label();
            this.lblIterBestLabel = new System.Windows.Forms.Label();
            this.lblGenBest = new System.Windows.Forms.Label();
            this.lblGenBestLabel = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblBest = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(939, 8);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(1020, 8);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 2;
            this.btnPause.Text = "pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnDebug
            // 
            this.btnDebug.Location = new System.Drawing.Point(1182, 655);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(75, 23);
            this.btnDebug.TabIndex = 3;
            this.btnDebug.Text = "debug";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // lblEventVia
            // 
            this.lblEventVia.AutoSize = true;
            this.lblEventVia.Location = new System.Drawing.Point(10, 13);
            this.lblEventVia.Name = "lblEventVia";
            this.lblEventVia.Size = new System.Drawing.Size(38, 13);
            this.lblEventVia.TabIndex = 4;
            this.lblEventVia.Text = "Event:";
            // 
            // cbEventVia
            // 
            this.cbEventVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEventVia.FormattingEnabled = true;
            this.cbEventVia.Location = new System.Drawing.Point(54, 10);
            this.cbEventVia.Name = "cbEventVia";
            this.cbEventVia.Size = new System.Drawing.Size(121, 21);
            this.cbEventVia.TabIndex = 5;
            this.cbEventVia.SelectedIndexChanged += new System.EventHandler(this.cbEventVia_SelectedIndexChanged);
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(735, 13);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(37, 13);
            this.lblDelay.TabIndex = 6;
            this.lblDelay.Text = "Delay:";
            // 
            // cbDelay
            // 
            this.cbDelay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDelay.FormattingEnabled = true;
            this.cbDelay.Location = new System.Drawing.Point(778, 10);
            this.cbDelay.Name = "cbDelay";
            this.cbDelay.Size = new System.Drawing.Size(60, 21);
            this.cbDelay.TabIndex = 7;
            this.cbDelay.SelectedIndexChanged += new System.EventHandler(this.cbDelay_SelectedIndexChanged);
            // 
            // cbOneEvent
            // 
            this.cbOneEvent.AutoSize = true;
            this.cbOneEvent.Location = new System.Drawing.Point(859, 12);
            this.cbOneEvent.Name = "cbOneEvent";
            this.cbOneEvent.Size = new System.Drawing.Size(74, 17);
            this.cbOneEvent.TabIndex = 8;
            this.cbOneEvent.Text = "one event";
            this.cbOneEvent.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slblStatus,
            this.slblResultIteration});
            this.statusStrip1.Location = new System.Drawing.Point(0, 714);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1281, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slblStatus
            // 
            this.slblStatus.Margin = new System.Windows.Forms.Padding(8, 3, 8, 2);
            this.slblStatus.Name = "slblStatus";
            this.slblStatus.Size = new System.Drawing.Size(46, 17);
            this.slblStatus.Text = "[status]";
            // 
            // pbGrid
            // 
            this.pbGrid.Location = new System.Drawing.Point(13, 37);
            this.pbGrid.Name = "pbGrid";
            this.pbGrid.Size = new System.Drawing.Size(1082, 578);
            this.pbGrid.TabIndex = 10;
            this.pbGrid.TabStop = false;
            // 
            // lblIter
            // 
            this.lblIter.AutoSize = true;
            this.lblIter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblIter.Location = new System.Drawing.Point(1222, 18);
            this.lblIter.Name = "lblIter";
            this.lblIter.Size = new System.Drawing.Size(12, 16);
            this.lblIter.TabIndex = 14;
            this.lblIter.Text = "-";
            // 
            // lblIterLabel
            // 
            this.lblIterLabel.AutoSize = true;
            this.lblIterLabel.Location = new System.Drawing.Point(1186, 20);
            this.lblIterLabel.Name = "lblIterLabel";
            this.lblIterLabel.Size = new System.Drawing.Size(35, 13);
            this.lblIterLabel.TabIndex = 13;
            this.lblIterLabel.Text = "ITER:";
            // 
            // lblGen
            // 
            this.lblGen.AutoSize = true;
            this.lblGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGen.Location = new System.Drawing.Point(1140, 18);
            this.lblGen.Name = "lblGen";
            this.lblGen.Size = new System.Drawing.Size(12, 16);
            this.lblGen.TabIndex = 12;
            this.lblGen.Text = "-";
            // 
            // lblGenLabel
            // 
            this.lblGenLabel.AutoSize = true;
            this.lblGenLabel.Location = new System.Drawing.Point(1105, 20);
            this.lblGenLabel.Name = "lblGenLabel";
            this.lblGenLabel.Size = new System.Drawing.Size(33, 13);
            this.lblGenLabel.TabIndex = 11;
            this.lblGenLabel.Text = "GEN:";
            // 
            // txtHistory
            // 
            this.txtHistory.BackColor = System.Drawing.SystemColors.Info;
            this.txtHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtHistory.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtHistory.Location = new System.Drawing.Point(1103, 74);
            this.txtHistory.Multiline = true;
            this.txtHistory.Name = "txtHistory";
            this.txtHistory.ReadOnly = true;
            this.txtHistory.Size = new System.Drawing.Size(168, 540);
            this.txtHistory.TabIndex = 15;
            // 
            // slblResultIteration
            // 
            this.slblResultIteration.Margin = new System.Windows.Forms.Padding(8, 3, 8, 2);
            this.slblResultIteration.Name = "slblResultIteration";
            this.slblResultIteration.Size = new System.Drawing.Size(91, 17);
            this.slblResultIteration.Text = "[result iteration]";
            // 
            // lblIterBest
            // 
            this.lblIterBest.AutoSize = true;
            this.lblIterBest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblIterBest.Location = new System.Drawing.Point(1222, 55);
            this.lblIterBest.Name = "lblIterBest";
            this.lblIterBest.Size = new System.Drawing.Size(11, 13);
            this.lblIterBest.TabIndex = 19;
            this.lblIterBest.Text = "-";
            // 
            // lblIterBestLabel
            // 
            this.lblIterBestLabel.AutoSize = true;
            this.lblIterBestLabel.Location = new System.Drawing.Point(1186, 55);
            this.lblIterBestLabel.Name = "lblIterBestLabel";
            this.lblIterBestLabel.Size = new System.Drawing.Size(35, 13);
            this.lblIterBestLabel.TabIndex = 18;
            this.lblIterBestLabel.Text = "ITER:";
            // 
            // lblGenBest
            // 
            this.lblGenBest.AutoSize = true;
            this.lblGenBest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGenBest.Location = new System.Drawing.Point(1140, 55);
            this.lblGenBest.Name = "lblGenBest";
            this.lblGenBest.Size = new System.Drawing.Size(11, 13);
            this.lblGenBest.TabIndex = 17;
            this.lblGenBest.Text = "-";
            // 
            // lblGenBestLabel
            // 
            this.lblGenBestLabel.AutoSize = true;
            this.lblGenBestLabel.Location = new System.Drawing.Point(1105, 55);
            this.lblGenBestLabel.Name = "lblGenBestLabel";
            this.lblGenBestLabel.Size = new System.Drawing.Size(33, 13);
            this.lblGenBestLabel.TabIndex = 16;
            this.lblGenBestLabel.Text = "GEN:";
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrent.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblCurrent.Location = new System.Drawing.Point(1105, 4);
            this.lblCurrent.Margin = new System.Windows.Forms.Padding(3);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(47, 13);
            this.lblCurrent.TabIndex = 20;
            this.lblCurrent.Text = "current";
            // 
            // lblBest
            // 
            this.lblBest.AutoSize = true;
            this.lblBest.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblBest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBest.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblBest.Location = new System.Drawing.Point(1106, 41);
            this.lblBest.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblBest.Name = "lblBest";
            this.lblBest.Size = new System.Drawing.Size(31, 13);
            this.lblBest.TabIndex = 21;
            this.lblBest.Text = "best";
            // 
            // FormEvo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 736);
            this.Controls.Add(this.lblBest);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.lblIterBest);
            this.Controls.Add(this.lblIterBestLabel);
            this.Controls.Add(this.lblGenBest);
            this.Controls.Add(this.lblGenBestLabel);
            this.Controls.Add(this.txtHistory);
            this.Controls.Add(this.lblIter);
            this.Controls.Add(this.lblIterLabel);
            this.Controls.Add(this.lblGen);
            this.Controls.Add(this.lblGenLabel);
            this.Controls.Add(this.pbGrid);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cbOneEvent);
            this.Controls.Add(this.cbDelay);
            this.Controls.Add(this.lblDelay);
            this.Controls.Add(this.cbEventVia);
            this.Controls.Add(this.lblEventVia);
            this.Controls.Add(this.btnDebug);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Name = "FormEvo";
            this.Text = "Evolution v2.0";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormEvo_FormClosed);
            this.Load += new System.EventHandler(this.FormEvo_Load);
            this.MouseEnter += new System.EventHandler(this.FormEvo_MouseEnter);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.Label lblEventVia;
        private System.Windows.Forms.ComboBox cbEventVia;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.ComboBox cbDelay;
        private System.Windows.Forms.CheckBox cbOneEvent;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slblStatus;
        private System.Windows.Forms.PictureBox pbGrid;
        private System.Windows.Forms.Label lblIter;
        private System.Windows.Forms.Label lblIterLabel;
        private System.Windows.Forms.Label lblGen;
        private System.Windows.Forms.Label lblGenLabel;
        private System.Windows.Forms.TextBox txtHistory;
        private System.Windows.Forms.ToolStripStatusLabel slblResultIteration;
        private System.Windows.Forms.Label lblIterBest;
        private System.Windows.Forms.Label lblIterBestLabel;
        private System.Windows.Forms.Label lblGenBest;
        private System.Windows.Forms.Label lblGenBestLabel;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label lblBest;
    }
}

