namespace Klijent.Forms
{
    partial class LoginForm
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
            this.btnKreiraj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnKreiraj
            // 
            this.btnKreiraj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.btnKreiraj.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnKreiraj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(60)))), ((int)(((byte)(108)))));
            this.btnKreiraj.Location = new System.Drawing.Point(159, 147);
            this.btnKreiraj.Name = "btnKreiraj";
            this.btnKreiraj.Size = new System.Drawing.Size(120, 36);
            this.btnKreiraj.TabIndex = 5;
            this.btnKreiraj.Text = "Prijavi se";
            this.btnKreiraj.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(232)))), ((int)(((byte)(172)))));
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(60)))), ((int)(((byte)(108)))));
            this.txtEmail.Location = new System.Drawing.Point(17, 41);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(265, 22);
            this.txtEmail.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.label2.Location = new System.Drawing.Point(14, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Sifra:";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(232)))), ((int)(((byte)(172)))));
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(60)))), ((int)(((byte)(108)))));
            this.txtPassword.Location = new System.Drawing.Point(17, 106);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(265, 22);
            this.txtPassword.TabIndex = 6;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(60)))), ((int)(((byte)(108)))));
            this.ClientSize = new System.Drawing.Size(294, 202);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnKreiraj);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmail);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnKreiraj;
        public System.Windows.Forms.TextBox txtEmail;
        public System.Windows.Forms.TextBox txtPassword;
    }
}