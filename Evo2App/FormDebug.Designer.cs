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
            this.lblGenLabel = new System.Windows.Forms.Label();
            this.lblGen = new System.Windows.Forms.Label();
            this.lblIterLabel = new System.Windows.Forms.Label();
            this.lblIter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGenLabel
            // 
            this.lblGenLabel.AutoSize = true;
            this.lblGenLabel.Location = new System.Drawing.Point(13, 13);
            this.lblGenLabel.Name = "lblGenLabel";
            this.lblGenLabel.Size = new System.Drawing.Size(33, 13);
            this.lblGenLabel.TabIndex = 0;
            this.lblGenLabel.Text = "GEN:";
            // 
            // lblGen
            // 
            this.lblGen.AutoSize = true;
            this.lblGen.Location = new System.Drawing.Point(53, 13);
            this.lblGen.Name = "lblGen";
            this.lblGen.Size = new System.Drawing.Size(10, 13);
            this.lblGen.TabIndex = 1;
            this.lblGen.Text = "-";
            // 
            // lblIterLabel
            // 
            this.lblIterLabel.AutoSize = true;
            this.lblIterLabel.Location = new System.Drawing.Point(83, 13);
            this.lblIterLabel.Name = "lblIterLabel";
            this.lblIterLabel.Size = new System.Drawing.Size(35, 13);
            this.lblIterLabel.TabIndex = 2;
            this.lblIterLabel.Text = "ITER:";
            // 
            // lblIter
            // 
            this.lblIter.AutoSize = true;
            this.lblIter.Location = new System.Drawing.Point(125, 13);
            this.lblIter.Name = "lblIter";
            this.lblIter.Size = new System.Drawing.Size(10, 13);
            this.lblIter.TabIndex = 3;
            this.lblIter.Text = "-";
            // 
            // FormDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 335);
            this.Controls.Add(this.lblIter);
            this.Controls.Add(this.lblIterLabel);
            this.Controls.Add(this.lblGen);
            this.Controls.Add(this.lblGenLabel);
            this.Name = "FormDebug";
            this.Text = "Evolution Debug Info";
            this.Load += new System.EventHandler(this.FormDebug_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGenLabel;
        private System.Windows.Forms.Label lblGen;
        private System.Windows.Forms.Label lblIterLabel;
        private System.Windows.Forms.Label lblIter;
    }
}