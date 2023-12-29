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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pastaneProje
{
    public partial class kullaniciPaneli : Form
    {
        public kullaniciPaneli()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=dbProjePastane; user Id=postgres; password=159753");
        void Urunler()
        {
            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT urun_id, urun_ad, sfiyat FROM urun", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            baglanti.Close();

            comboBox1.DisplayMember = "urun_ad";
            comboBox1.ValueMember = "urun_id";
            comboBox1.DataSource = dt;
        }
        private void kullaniciPaneli_Load(object sender, EventArgs e)
        {
            Urunler();



        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex != -1)
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("SELECT * FROM urun WHERE urun_id=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", comboBox1.SelectedValue);

                using (NpgsqlDataReader dr = komut.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        txtfiyat.Text = dr["sfiyat"].ToString();
                    }
                }

                baglanti.Close();
            }




        }




        private void txtfiyat_TextChanged(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public int KullaniciId { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            NpgsqlCommand komut = new NpgsqlCommand("insert into siparisler(urun_id,kullanici_id) values(@p1,@p2)", baglanti);
            komut.Parameters.AddWithValue("@p1", comboBox1.SelectedValue);
            komut.Parameters.AddWithValue("@p2", KullaniciId);
            komut.ExecuteNonQuery();
            MessageBox.Show("Sipariş Verildi");
            try
            {
                // PostgreSQL komutları ve bağlantıları burada
            }
            catch (Npgsql.PostgresException ex)
            {
                if (ex.SqlState == "P0001") // Özel bir hata durumunu kontrol et
                {
                    MessageBox.Show("Kullanıcı üçten fazla sipariş veremez.");
                }
                else
                {
                    // Diğer hata durumlarını işle
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }



            baglanti.Close();
        }
    }
}
