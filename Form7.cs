using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KUAFÖR_RANDEVU_SİSTEMİ
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        int secili;
        int deneme = 2;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            secili = listBox1.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtsifre.Text))
            {
                MessageBox.Show("Lütfen şifreyi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dogruSifre = GetDogruSifre(secili);

            if (dogruSifre == null)
            {
                MessageBox.Show("Geçersiz kullanıcı seçimi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtsifre.Text == dogruSifre)
            {
                deneme = 2; // Deneme hakkını sıfırla
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else
            {
                deneme--;
                if (deneme >= 0)
                {
                    MessageBox.Show($"Kalan şifre deneme hakkı: {deneme + 1}", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Hatalı şifre girişi!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtsifre.Clear();
                }

                if (deneme < 0)
                {
                    MessageBox.Show("Deneme hakkınız kalmadı. Uygulama kapanıyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }

        private string GetDogruSifre(int seciliIndex)
        {
            switch (seciliIndex)
            {
                case 0: return "Said123";
                case 1: return "Yasin123";
                case 2: return "Müdür123";
                default: return null;
            }
        }

        // Şifre kutusunda boşluk ve Ctrl tuşlarını engelle
        private void txtsifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' || Control.ModifierKeys == Keys.Control)
            {
                MessageBox.Show("Bu tuş kullanılamaz!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        // Buton2'nin üstüne mouse gelince şifreyi göster
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            txtsifre.PasswordChar = '\0';
        }

        // Mouse çıkınca tekrar gizle
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            txtsifre.PasswordChar = '*';
        }
    }
}

