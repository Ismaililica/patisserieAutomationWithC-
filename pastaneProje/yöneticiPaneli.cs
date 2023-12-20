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

        void MalzemeListe()
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("Select *From malzeme ", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void UrunListesi()
        {

            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter("SELECT *FROM urun", baglanti);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
        }

        void KasaGoster()
        {
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter("SELECT *FROM kasa", baglanti);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
        }
        private void yöneticiPaneli_Load(object sender, EventArgs e)
        {
            MalzemeListe();
            Urunler();
            Malzemeler();
        }
        void Malzemeler()
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("Select *from malzeme", baglanti);
            NpgsqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[1]);
            }
            baglanti.Close();


        }
        void Urunler()
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("Select *from urun", baglanti);
            NpgsqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[1]);

            }
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
            NpgsqlCommand komut = new NpgsqlCommand("insert into urun (urun_ad) values(@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox9.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün Eklendi");
        }
    }
}
