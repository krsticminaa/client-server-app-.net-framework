namespace Klijent.Forms
{
    partial class DetaljiRacunForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblNacinPlacanja = new System.Windows.Forms.Label();
            this.lblDatumKreiranja = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDug = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(151)))), ((int)(((byte)(108)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 124);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(411, 182);
            this.dataGridView1.TabIndex = 56;
            // 
            // lblNacinPlacanja
            // 
            this.lblNacinPlacanja.AutoSize = true;
            this.lblNacinPlacanja.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblNacinPlacanja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.lblNacinPlacanja.Location = new System.Drawing.Point(182, 49);
            this.lblNacinPlacanja.Name = "lblNacinPlacanja";
            this.lblNacinPlacanja.Size = new System.Drawing.Size(55, 19);
            this.lblNacinPlacanja.TabIndex = 55;
            this.lblNacinPlacanja.Text = "label3";
            // 
            // lblDatumKreiranja
            // 
            this.lblDatumKreiranja.AutoSize = true;
            this.lblDatumKreiranja.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblDatumKreiranja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.lblDatumKreiranja.Location = new System.Drawing.Point(182, 14);
            this.lblDatumKreiranja.Name = "lblDatumKreiranja";
            this.lblDatumKreiranja.Size = new System.Drawing.Size(55, 19);
            this.lblDatumKreiranja.TabIndex = 54;
            this.lblDatumKreiranja.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.label3.Location = new System.Drawing.Point(18, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 19);
            this.label3.TabIndex = 53;
            this.label3.Text = "Nacin placanja:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.label4.Location = new System.Drawing.Point(18, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 19);
            this.label4.TabIndex = 52;
            this.label4.Text = "Datum kreiranja:";
            // 
            // lblDug
            // 
            this.lblDug.AutoSize = true;
            this.lblDug.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblDug.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.lblDug.Location = new System.Drawing.Point(182, 86);
            this.lblDug.Name = "lblDug";
            this.lblDug.Size = new System.Drawing.Size(55, 19);
            this.lblDug.TabIndex = 50;
            this.lblDug.Text = "label1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.label7.Location = new System.Drawing.Point(18, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 24);
            this.label7.TabIndex = 48;
            this.label7.Text = "Ukupan dug:";
            // 
            // DetaljiRacunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(60)))), ((int)(((byte)(108)))));
            this.ClientSize = new System.Drawing.Size(465, 325);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblNacinPlacanja);
            this.Controls.Add(this.lblDatumKreiranja);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDug);
            this.Controls.Add(this.label7);
            this.Name = "DetaljiRacunForm";
            this.Text = "DetaljiRacunForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Label lblNacinPlacanja;
        public System.Windows.Forms.Label lblDatumKreiranja;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblDug;
        private System.Windows.Forms.Label label7;
    }
}