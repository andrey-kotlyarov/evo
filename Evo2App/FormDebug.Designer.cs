namespace Evo2App
{
    partial class FormDebug
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slblEvent = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbProgram = new System.Windows.Forms.PictureBox();
            this.slblGenIter = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgram)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slblEvent,
            this.slblGenIter});
            this.statusStrip1.Location = new System.Drawing.Point(0, 711);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1267, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slblEvent
            // 
            this.slblEvent.Margin = new System.Windows.Forms.Padding(8, 3, 8, 2);
            this.slblEvent.Name = "slblEvent";
            this.slblEvent.Size = new System.Drawing.Size(44, 17);
            this.slblEvent.Text = "[event]";
            // 
            // pbProgram
            // 
            this.pbProgram.Location = new System.Drawing.Point(12, 12);
            this.pbProgram.Name = "pbProgram";
            this.pbProgram.Size = new System.Drawing.Size(1242, 690);
            this.pbProgram.TabIndex = 5;
            this.pbProgram.TabStop = false;
            // 
            // slblGenIter
            // 
            this.slblGenIter.Margin = new System.Windows.Forms.Padding(8, 3, 8, 2);
            this.slblGenIter.Name = "slblGenIter";
            this.slblGenIter.Size = new System.Drawing.Size(55, 17);
            this.slblGenIter.Text = "[gen iter]";
            // 
            // FormDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 733);
            this.Controls.Add(this.pbProgram);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FormDebug";
            this.Text = "Evolution Debug Info";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDebug_FormClosed);
            this.Load += new System.EventHandler(this.FormDebug_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormDebug_Paint);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slblEvent;
        private System.Windows.Forms.PictureBox pbProgram;
        private System.Windows.Forms.ToolStripStatusLabel slblGenIter;
    }
}