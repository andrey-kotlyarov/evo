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
            this.txtReport = new System.Windows.Forms.TextBox();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnDebug = new System.Windows.Forms.Button();
            this.lblEventVia = new System.Windows.Forms.Label();
            this.cbEventVia = new System.Windows.Forms.ComboBox();
            this.lblDelay = new System.Windows.Forms.Label();
            this.cbDelay = new System.Windows.Forms.ComboBox();
            this.cbOneEvent = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 103);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtReport
            // 
            this.txtReport.Location = new System.Drawing.Point(181, 12);
            this.txtReport.Multiline = true;
            this.txtReport.Name = "txtReport";
            this.txtReport.ReadOnly = true;
            this.txtReport.Size = new System.Drawing.Size(537, 346);
            this.txtReport.TabIndex = 1;
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(13, 133);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 2;
            this.btnPause.Text = "pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnDebug
            // 
            this.btnDebug.Location = new System.Drawing.Point(13, 287);
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
            this.lblEventVia.Location = new System.Drawing.Point(13, 12);
            this.lblEventVia.Name = "lblEventVia";
            this.lblEventVia.Size = new System.Drawing.Size(38, 13);
            this.lblEventVia.TabIndex = 4;
            this.lblEventVia.Text = "Event:";
            // 
            // cbEventVia
            // 
            this.cbEventVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEventVia.FormattingEnabled = true;
            this.cbEventVia.Location = new System.Drawing.Point(58, 13);
            this.cbEventVia.Name = "cbEventVia";
            this.cbEventVia.Size = new System.Drawing.Size(121, 21);
            this.cbEventVia.TabIndex = 5;
            this.cbEventVia.SelectedIndexChanged += new System.EventHandler(this.cbEventVia_SelectedIndexChanged);
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(14, 47);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(37, 13);
            this.lblDelay.TabIndex = 6;
            this.lblDelay.Text = "Delay:";
            // 
            // cbDelay
            // 
            this.cbDelay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDelay.FormattingEnabled = true;
            this.cbDelay.Location = new System.Drawing.Point(58, 47);
            this.cbDelay.Name = "cbDelay";
            this.cbDelay.Size = new System.Drawing.Size(121, 21);
            this.cbDelay.TabIndex = 7;
            this.cbDelay.SelectedIndexChanged += new System.EventHandler(this.cbDelay_SelectedIndexChanged);
            // 
            // cbOneEvent
            // 
            this.cbOneEvent.AutoSize = true;
            this.cbOneEvent.Location = new System.Drawing.Point(17, 80);
            this.cbOneEvent.Name = "cbOneEvent";
            this.cbOneEvent.Size = new System.Drawing.Size(74, 17);
            this.cbOneEvent.TabIndex = 8;
            this.cbOneEvent.Text = "one event";
            this.cbOneEvent.UseVisualStyleBackColor = true;
            // 
            // FormEvo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 370);
            this.Controls.Add(this.cbOneEvent);
            this.Controls.Add(this.cbDelay);
            this.Controls.Add(this.lblDelay);
            this.Controls.Add(this.cbEventVia);
            this.Controls.Add(this.lblEventVia);
            this.Controls.Add(this.btnDebug);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.txtReport);
            this.Controls.Add(this.btnStart);
            this.Name = "FormEvo";
            this.Text = "Evolution v2.0";
            this.Load += new System.EventHandler(this.FormEvo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtReport;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.Label lblEventVia;
        private System.Windows.Forms.ComboBox cbEventVia;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.ComboBox cbDelay;
        private System.Windows.Forms.CheckBox cbOneEvent;
    }
}

