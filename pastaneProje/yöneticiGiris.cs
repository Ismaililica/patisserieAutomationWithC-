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
    public partial class yöneticiGiris : Form
    {
        public yöneticiGiris()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=dbProjePastane; user Id=postgres; password=159753");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("SELECT * FROM pastane WHERE yonetici_ad=@p1 AND yonetici_sifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.Parameters.AddWithValue("@p2", textBox3.Text);
            NpgsqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                yöneticiPaneli fr = new yöneticiPaneli();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Böyle bir yönetici bulunamadı tekrar deneyiniz");
            }
            baglanti.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
