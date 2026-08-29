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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {



            Personel form2gecic = new Personel();
            form2gecic.Show();
        }

        private void btntakib_Click(object sender, EventArgs e)
        {
            Randevu form3gecic = new Randevu();
            form3gecic.Show();
        }

        private void btnfiyat_Click(object sender, EventArgs e)
        {
            Form4 form4gecic = new Form4();
            form4gecic.Show();
        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            Form5 form5gecic = new Form5();
            form5gecic.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
