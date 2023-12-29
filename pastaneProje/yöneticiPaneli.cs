using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pastaneProje
{
    public partial class yöneticiPaneli : Form
    {
        public yöneticiPaneli()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=dbProjePastane; user Id=postgres; password=159753");

        int malzemeKontrol = 0;

        void MalzemeListe()
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("Select *From malzeme ", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            malzemeKontrol = 1;
        }

        void UrunListesi()
        {

            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter("SELECT *FROM urun", baglanti);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            malzemeKontrol = 0;
        }


        void KasaGoster()
        {

            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter("SELECT toplamgelir,toplamgider from pastane where yonetici_id=1", baglanti);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView3.DataSource = dt2;
        }
        private void yöneticiPaneli_Load(object sender, EventArgs e)
        {
            Urunler();
            Malzemeler();
            siparissler();

        }



        void siparissler()
        {
            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select *from siparisler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();
        }

        void Malzemeler()
        {
            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select *from malzeme", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox2.ValueMember = "malzeme_id";
            comboBox2.DisplayMember = "malzeme_ad";
            comboBox2.DataSource = dt;
            baglanti.Close();


        }
        void Urunler()
        {
            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select *from urun", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "urun_id";
            comboBox1.DisplayMember = "urun_ad";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            UrunListesi();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MalzemeListe();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            KasaGoster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into malzeme(malzeme_ad,malzeme_stok,malzeme_fiyat,notlar)values(@p1,@p2,@p3,@p4)", baglanti);

            komut.Parameters.AddWithValue("@p1", textBox2.Text);

            komut.Parameters.AddWithValue("@p2", int.Parse(textBox3.Text));

            komut.Parameters.AddWithValue("@p3", int.Parse(textBox4.Text));

            komut.Parameters.AddWithValue("@p4", textBox5.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Malzeme Eklendi!");
            MalzemeListe();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into urun (urun_ad,sfiyat,urunstok,mfiyat) values(@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", txturunad.Text);
            komut.Parameters.AddWithValue("@p2", int.Parse(txtsfiyat.Text));
            komut.Parameters.AddWithValue("@p3", int.Parse(txtstok.Text));
            komut.Parameters.AddWithValue("@p4", int.Parse(txtmfiyat.Text));

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün Eklendi");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into firin(urun_id,malzeme_id,miktar,maliyet) values (@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", comboBox1.SelectedValue);
            komut.Parameters.AddWithValue("@p2", comboBox2.SelectedValue);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtmiktar.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtmaliyet.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Malzeme Eklendi");
            listBox1.Items.Add(comboBox2.Text + "-" + txtmaliyet.Text);
        }

        private void txtmiktar_TextChanged(object sender, EventArgs e)
        {
            double maliyet;
            if (txtmiktar.Text == " ")
            {
                txtmiktar.Text = "0";
            }
            baglanti.Open();

            NpgsqlCommand komut = new NpgsqlCommand("Select *from malzeme where malzeme_id=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", comboBox2.SelectedValue);
            NpgsqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtmaliyet.Text = dr[3].ToString();
            }
            maliyet = Convert.ToDouble(txtmaliyet.Text) / 1000 * Convert.ToDouble(txtmiktar.Text);
            txtmaliyet.Text = maliyet.ToString();
            baglanti.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();

                NpgsqlCommand komut = new NpgsqlCommand("UPDATE urun SET urunstok=@p1, sfiyat=@p2, mfiyat=@p3 WHERE urun_id=@p4", baglanti);

                // Girişleri kontrol et ve parametre değerlerini atanırken uygun türde dönüşümleri yap
                if (int.TryParse(txtstok.Text, out int urunstok) &&
                    int.TryParse(txtsfiyat.Text, out int sfiyat) &&
                    int.TryParse(txtmfiyat.Text, out int mfiyat) &&
                    int.TryParse(txturunid.Text, out int urunId))
                {
                    komut.Parameters.AddWithValue("@p1", urunstok);
                    komut.Parameters.AddWithValue("@p2", sfiyat);
                    komut.Parameters.AddWithValue("@p3", mfiyat);
                    komut.Parameters.AddWithValue("@p4", urunId);

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Ürün Listesi Güncellendi");
                }
                else
                {
                    MessageBox.Show("Giriş değerlerinde hata var. Lütfen doğru formatta giriş yapın.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

            try
            {
                baglanti.Open();

                using (NpgsqlCommand komut = new NpgsqlCommand("urunsilme", baglanti))
                {
                    komut.CommandType = CommandType.StoredProcedure;

                    // Parametre ekleyin
                    komut.Parameters.AddWithValue("@urunIdParam", int.Parse(txturunid.Text));

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Ürün Silindi!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (malzemeKontrol == 0)
            {
                txturunid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txturunad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtstok.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtmfiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtsfiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            else
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void txtmaliyet_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
