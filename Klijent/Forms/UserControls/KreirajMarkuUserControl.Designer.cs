namespace Klijent.Forms.UserControls
{
    partial class KreirajMarkuUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKreiraj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(232)))), ((int)(((byte)(172)))));
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(60)))), ((int)(((byte)(108)))));
            this.txtName.Location = new System.Drawing.Point(14, 41);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(262, 22);
            this.txtName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Naziv:";
            // 
            // btnKreiraj
            // 
            this.btnKreiraj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.btnKreiraj.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnKreiraj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(60)))), ((int)(((byte)(108)))));
            this.btnKreiraj.Location = new System.Drawing.Point(156, 78);
            this.btnKreiraj.Name = "btnKreiraj";
            this.btnKreiraj.Size = new System.Drawing.Size(120, 36);
            this.btnKreiraj.TabIndex = 2;
            this.btnKreiraj.Text = "Kreiraj";
            this.btnKreiraj.UseVisualStyleBackColor = false;
            // 
            // KreirajMarkuUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(60)))), ((int)(((byte)(108)))));
            this.Controls.Add(this.btnKreiraj);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Name = "KreirajMarkuUserControl";
            this.Size = new System.Drawing.Size(291, 139);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.Button btnKreiraj;
    }
}
