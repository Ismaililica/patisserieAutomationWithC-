namespace pastaneProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            kullaniciKayit fr = new kullaniciKayit();
            fr.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kullaniciGiris fr = new kullaniciGiris();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yöneticiGiris fr = new yöneticiGiris();
            fr.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Blue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = DefaultBackColor;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Blue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = DefaultBackColor;
        }
    }
}