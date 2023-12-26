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
    }
}
