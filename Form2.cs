using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KUAFÖR_RANDEVU_SİSTEMİ
{
    public partial class Randevu : Form
    {    
        MySqlConnection con = new MySqlConnection(
            "Server=localhost;Database=proje1;Uid=root;Pwd=!Mami10+!;"
        );

        private MySqlCommand cmd;
        private DataTable dt;
       
        private string selectedTc = "";
        private DateTime selectedTarih;

        public Randevu()
        {
            InitializeComponent();
            this.Load += Randevu_Load;    
        }

        private void Randevu_Load(object sender, EventArgs e)
        {
            Listele(); 
        }

        private void Listele()
        {
            try
            {
                dt = new DataTable();
                cmd = new MySqlCommand("SELECT tc_kimlik, ad, cep_telefon, soyad, randevu_tarihi, adres FROM randevu", con);
                var adapter = new MySqlDataAdapter(cmd);

                con.Open();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme Hatası: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            { 
                var row = dataGridView1.Rows[e.RowIndex];

                selectedTc = row.Cells["tc_kimlik"].Value.ToString();
                selectedTarih = Convert.ToDateTime(row.Cells["randevu_tarihi"].Value);

                txtboxtc.Text = selectedTc;
                txtboxad.Text = row.Cells["ad"].Value.ToString();
                txtboxtel.Text = row.Cells["cep_telefon"].Value.ToString();
                txtboxsoyad.Text = row.Cells["soyad"].Value.ToString();
                dateTimePicker1.Value = selectedTarih;
                txtboxadres.Text = row.Cells["adres"].Value.ToString();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtboxtc.Text) || string.IsNullOrWhiteSpace(txtboxad.Text))
            {
                MessageBox.Show("Lütfen TC ve Ad alanlarını doldurun.");
                return;
            }

            if (txtboxtc.Text.Length != 11 || !txtboxtc.Text.All(char.IsDigit))
            {
                MessageBox.Show("TC Kimlik numarası 11 haneli olmalı ve sadece rakamlardan oluşmalıdır.");
                return;
            }

            try
            {
                cmd = new MySqlCommand(
                    "SELECT COUNT(*) FROM randevu WHERE tc_kimlik = @tc", con);
                cmd.Parameters.AddWithValue("@tc", txtboxtc.Text);

                con.Open();
                int mevcutKayitSayisi = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

                if (mevcutKayitSayisi > 0)
                {
                    MessageBox.Show("Bu TC kimlik numarası ile zaten bir randevu alınmış.");
                    return;
                }

                cmd = new MySqlCommand(
                    "INSERT INTO randevu (tc_kimlik, ad, cep_telefon, soyad, randevu_tarihi, adres) " +
                    "VALUES (@tc, @ad, @tel, @soyad, @tarih, @adres)", con);

                cmd.Parameters.AddWithValue("@tc", txtboxtc.Text);
                cmd.Parameters.AddWithValue("@ad", txtboxad.Text);
                cmd.Parameters.AddWithValue("@tel", txtboxtel.Text);
                cmd.Parameters.AddWithValue("@soyad", txtboxsoyad.Text);
                cmd.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@adres", txtboxadres.Text);

                con.Open();
                cmd.ExecuteNonQuery();  
                MessageBox.Show("Randevu başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekleme Hatası: " + ex.Message);
            }
            finally
            {
                con.Close();
                Listele();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek randevuyu seçin!");
                return;
            }

            string silinecekTc = dataGridView1.SelectedRows[0].Cells["tc_kimlik"].Value.ToString();

            try
            {
                cmd = new MySqlCommand("DELETE FROM randevu WHERE tc_kimlik = @tc", con);
                cmd.Parameters.AddWithValue("@tc", silinecekTc);

                con.Open();
                int silinen = cmd.ExecuteNonQuery();

                if (silinen > 0)
                {
                    MessageBox.Show("Randevu başarıyla silindi.");
                }
                else
                {
                    MessageBox.Show("Silinecek randevu bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme Hatası: " + ex.Message);
            }
            finally
            {
                con.Close();
                Listele(); 
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz satırı seçin!");
                return;
            }

            string yeniAd = txtboxad.Text;
            string yeniSoyad = txtboxsoyad.Text;
            string yeniTelefon = txtboxtel.Text;
            DateTime yeniTarih = dateTimePicker1.Value;
            string yeniAdres = txtboxadres.Text;
            string yeniTcKimlik = txtboxtc.Text;

            if (string.IsNullOrWhiteSpace(yeniAd) || string.IsNullOrWhiteSpace(yeniSoyad) ||
                string.IsNullOrWhiteSpace(yeniTelefon) || string.IsNullOrWhiteSpace(yeniAdres) ||
                string.IsNullOrWhiteSpace(yeniTcKimlik))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];
            string selectedTc = selectedRow.Cells["tc_kimlik"].Value.ToString();
            DateTime selectedTarih = Convert.ToDateTime(selectedRow.Cells["randevu_tarihi"].Value);

            try
            {
                cmd = new MySqlCommand(
                    "UPDATE randevu SET tc_kimlik = @yeniTc, ad = @ad, cep_telefon = @tel, soyad = @soyad, " +
                    "randevu_tarihi = @tarih, adres = @adres " +
                    "WHERE tc_kimlik = @tc AND randevu_tarihi = @eski_tarih", con);

                cmd.Parameters.AddWithValue("@yeniTc", yeniTcKimlik);
                cmd.Parameters.AddWithValue("@ad", yeniAd);
                cmd.Parameters.AddWithValue("@tel", yeniTelefon);
                cmd.Parameters.AddWithValue("@soyad", yeniSoyad);
                cmd.Parameters.AddWithValue("@tarih", yeniTarih);
                cmd.Parameters.AddWithValue("@adres", yeniAdres);
                cmd.Parameters.AddWithValue("@tc", selectedTc);
                cmd.Parameters.AddWithValue("@eski_tarih", selectedTarih);

                con.Open();
                int güncellenen = cmd.ExecuteNonQuery();

                if (güncellenen > 0)
                {   
                    MessageBox.Show("Randevu başarıyla güncellendi.");
                    selectedRow.Cells["tc_kimlik"].Value = yeniTcKimlik;
                    selectedRow.Cells["ad"].Value = yeniAd;
                    selectedRow.Cells["soyad"].Value = yeniSoyad;
                    selectedRow.Cells["cep_telefon"].Value = yeniTelefon;
                    selectedRow.Cells["randevu_tarihi"].Value = yeniTarih;
                    selectedRow.Cells["adres"].Value = yeniAdres;
                }
                else
                {
                    MessageBox.Show("Güncellenen randevu bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme Hatası: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form6 form6gecici = new Form6();
            form6gecici.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG Files|*.jpg|PNG Files|*.png|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog.FileName;
                pictureBox1.Load();
            }
        }

      
    }
}
