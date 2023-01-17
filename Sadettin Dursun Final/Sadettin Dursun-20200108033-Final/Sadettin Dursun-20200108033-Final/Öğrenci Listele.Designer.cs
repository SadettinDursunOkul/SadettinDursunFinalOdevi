namespace Sadettin_Dursun_20200108033_Final
{
    partial class Öğrenci_Listele
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.cmbFiltre = new System.Windows.Forms.ComboBox();
            this.btnSırala = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSütun = new System.Windows.Forms.ComboBox();
            this.cmbÖlçü = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnYenile = new System.Windows.Forms.Button();
            this.dataGridViewOgr = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOgr)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewOgr, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 461);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtAra, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbFiltre, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnSırala, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.cmbSütun, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbÖlçü, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnYenile, 3, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(778, 224);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Arama Çubuğu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Arama Filtresi:";
            // 
            // txtAra
            // 
            this.txtAra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAra.Location = new System.Drawing.Point(158, 3);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(149, 32);
            this.txtAra.TabIndex = 3;
            this.txtAra.TextChanged += new System.EventHandler(this.txtAra_TextChanged);
            // 
            // cmbFiltre
            // 
            this.cmbFiltre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFiltre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltre.FormattingEnabled = true;
            this.cmbFiltre.Location = new System.Drawing.Point(158, 77);
            this.cmbFiltre.Name = "cmbFiltre";
            this.cmbFiltre.Size = new System.Drawing.Size(149, 32);
            this.cmbFiltre.TabIndex = 4;
            // 
            // btnSırala
            // 
            this.btnSırala.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSırala.Location = new System.Drawing.Point(623, 151);
            this.btnSırala.Name = "btnSırala";
            this.btnSırala.Size = new System.Drawing.Size(152, 70);
            this.btnSırala.TabIndex = 6;
            this.btnSırala.Text = "Sırala";
            this.btnSırala.UseVisualStyleBackColor = true;
            this.btnSırala.Click += new System.EventHandler(this.btnSırala_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(468, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 48);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sıralanacak Değer:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(468, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 48);
            this.label5.TabIndex = 8;
            this.label5.Text = "Neye Göre Sıralanacak:";
            // 
            // cmbSütun
            // 
            this.cmbSütun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSütun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSütun.FormattingEnabled = true;
            this.cmbSütun.Location = new System.Drawing.Point(623, 3);
            this.cmbSütun.Name = "cmbSütun";
            this.cmbSütun.Size = new System.Drawing.Size(152, 32);
            this.cmbSütun.TabIndex = 9;
            // 
            // cmbÖlçü
            // 
            this.cmbÖlçü.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbÖlçü.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbÖlçü.FormattingEnabled = true;
            this.cmbÖlçü.Location = new System.Drawing.Point(623, 77);
            this.cmbÖlçü.Name = "cmbÖlçü";
            this.cmbÖlçü.Size = new System.Drawing.Size(152, 32);
            this.cmbÖlçü.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(3, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "Öğrenciler";
            // 
            // btnYenile
            // 
            this.btnYenile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnYenile.Location = new System.Drawing.Point(468, 151);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(149, 70);
            this.btnYenile.TabIndex = 12;
            this.btnYenile.Text = "Sayfayı Yenile";
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // dataGridViewOgr
            // 
            this.dataGridViewOgr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOgr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOgr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOgr.Location = new System.Drawing.Point(3, 233);
            this.dataGridViewOgr.Name = "dataGridViewOgr";
            this.dataGridViewOgr.Size = new System.Drawing.Size(778, 225);
            this.dataGridViewOgr.TabIndex = 1;
            this.dataGridViewOgr.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOgr_CellDoubleClick);
            // 
            // Öğrenci_Listele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Öğrenci_Listele";
            this.Text = "Öğrenci Listele";
            this.Load += new System.EventHandler(this.Öğrenci_Listele_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOgr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewOgr;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.ComboBox cmbFiltre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSütun;
        private System.Windows.Forms.ComboBox cmbÖlçü;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSırala;
        private System.Windows.Forms.Button btnYenile;
    }
}