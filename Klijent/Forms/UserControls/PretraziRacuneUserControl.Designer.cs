namespace Klijent.Forms.UserControls
{
    partial class PretraziRacuneUserControl
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTekst = new System.Windows.Forms.TextBox();
            this.btnDetalji = new System.Windows.Forms.Button();
            this.cmbRacunari = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(151)))), ((int)(((byte)(108)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(550, 209);
            this.dataGridView1.TabIndex = 23;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.btnReset.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(60)))), ((int)(((byte)(108)))));
            this.btnReset.Location = new System.Drawing.Point(589, 140);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 36);
            this.btnReset.TabIndex = 22;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.btnPretrazi.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPretrazi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(60)))), ((int)(((byte)(108)))));
            this.btnPretrazi.Location = new System.Drawing.Point(589, 85);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(120, 36);
            this.btnPretrazi.TabIndex = 21;
            this.btnPretrazi.Text = "Pretrazi";
            this.btnPretrazi.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 20;
            this.label1.Text = "Tekst:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTekst
            // 
            this.txtTekst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(232)))), ((int)(((byte)(172)))));
            this.txtTekst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(60)))), ((int)(((byte)(108)))));
            this.txtTekst.Location = new System.Drawing.Point(15, 45);
            this.txtTekst.Name = "txtTekst";
            this.txtTekst.Size = new System.Drawing.Size(262, 22);
            this.txtTekst.TabIndex = 19;
            // 
            // btnDetalji
            // 
            this.btnDetalji.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.btnDetalji.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalji.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(60)))), ((int)(((byte)(108)))));
            this.btnDetalji.Location = new System.Drawing.Point(589, 199);
            this.btnDetalji.Name = "btnDetalji";
            this.btnDetalji.Size = new System.Drawing.Size(120, 36);
            this.btnDetalji.TabIndex = 24;
            this.btnDetalji.Text = "Detalji";
            this.btnDetalji.UseVisualStyleBackColor = false;
            // 
            // cmbRacunari
            // 
            this.cmbRacunari.FormattingEnabled = true;
            this.cmbRacunari.Location = new System.Drawing.Point(296, 45);
            this.cmbRacunari.Name = "cmbRacunari";
            this.cmbRacunari.Size = new System.Drawing.Size(216, 24);
            this.cmbRacunari.TabIndex = 25;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(531, 45);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(209, 25);
            this.checkBox1.TabIndex = 26;
            this.checkBox1.Text = "Za trenutnog korisnika?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // PretraziRacuneUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(60)))), ((int)(((byte)(108)))));
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cmbRacunari);
            this.Controls.Add(this.btnDetalji);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnPretrazi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTekst);
            this.Name = "PretraziRacuneUserControl";
            this.Size = new System.Drawing.Size(1085, 503);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Button btnReset;
        public System.Windows.Forms.Button btnPretrazi;
        public System.Windows.Forms.TextBox txtTekst;
        public System.Windows.Forms.Button btnDetalji;
        public System.Windows.Forms.ComboBox cmbRacunari;
        public System.Windows.Forms.CheckBox checkBox1;
    }
}
