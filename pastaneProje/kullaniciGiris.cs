using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace pastaneProje
{
    public partial class kullaniciGiris : Form
    {
        public kullaniciGiris()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=dbProjePastane; user Id=postgres; password=159753");
        private int kullaniciId;
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("SELECT * FROM kullanicilar WHERE kullanici_Ad=@p1 AND sifre=@p2", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox2.Text);
                komut.Parameters.AddWithValue("@p2", textBox3.Text);

                NpgsqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    kullaniciPaneli fr = new kullaniciPaneli();
                    fr.Show();
                    fr.Text = dr["kullanici_ad"].ToString();
                    fr.KullaniciId = Convert.ToInt32(dr["kullanici_id"]);



                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Böyle kullanıcı bulunamadı");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void kullaniciGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
