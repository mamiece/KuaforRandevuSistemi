namespace KUAFÖR_RANDEVU_SİSTEMİ
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnekle = new System.Windows.Forms.Button();
            this.btntakib = new System.Windows.Forms.Button();
            this.btnfiyat = new System.Windows.Forms.Button();
            this.btngiris = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnekle
            // 
            this.btnekle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnekle.Location = new System.Drawing.Point(12, 33);
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(186, 172);
            this.btnekle.TabIndex = 0;
            this.btnekle.Text = "PERSONEL TAKİBİ";
            this.btnekle.UseVisualStyleBackColor = false;
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // btntakib
            // 
            this.btntakib.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btntakib.Location = new System.Drawing.Point(219, 33);
            this.btntakib.Name = "btntakib";
            this.btntakib.Size = new System.Drawing.Size(186, 172);
            this.btntakib.TabIndex = 1;
            this.btntakib.Text = "RANDEVU TAKİBİ";
            this.btntakib.UseVisualStyleBackColor = false;
            this.btntakib.Click += new System.EventHandler(this.btntakib_Click);
            // 
            // btnfiyat
            // 
            this.btnfiyat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnfiyat.Location = new System.Drawing.Point(12, 218);
            this.btnfiyat.Name = "btnfiyat";
            this.btnfiyat.Size = new System.Drawing.Size(186, 167);
            this.btnfiyat.TabIndex = 2;
            this.btnfiyat.Text = "FİYAT LİSTESİ";
            this.btnfiyat.UseVisualStyleBackColor = false;
            this.btnfiyat.Click += new System.EventHandler(this.btnfiyat_Click);
            // 
            // btngiris
            // 
            this.btngiris.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btngiris.Location = new System.Drawing.Point(219, 218);
            this.btngiris.Name = "btngiris";
            this.btngiris.Size = new System.Drawing.Size(186, 167);
            this.btngiris.TabIndex = 3;
            this.btngiris.Text = "CİLT BAKIMI";
            this.btngiris.UseVisualStyleBackColor = false;
            this.btngiris.Click += new System.EventHandler(this.btngiris_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(444, 397);
            this.Controls.Add(this.btngiris);
            this.Controls.Add(this.btnfiyat);
            this.Controls.Add(this.btntakib);
            this.Controls.Add(this.btnekle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ANASAYFA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnekle;
        private System.Windows.Forms.Button btntakib;
        private System.Windows.Forms.Button btnfiyat;
        private System.Windows.Forms.Button btngiris;
    }
}

