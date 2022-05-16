using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Yazilim_Yapimi_Proje
{
    public partial class kayit : Form
    {
        public kayit()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            anafrm ac = new anafrm();
            ac.Show();
            this.Dispose();
            
            
        }
        public static SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-G8KPTIR;Initial Catalog=Kullanicilar;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection();
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string kayit = "INSERT INTO Kullanici(KullaniciID,KullaniciAdi,Ad,Soyad,Mail,Sifre)values(@id,@kullaniciad,@ad,@soyad,@mail,@sifre)";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@ad", textBox1.Text);
                komut.Parameters.AddWithValue("@soyad", textBox2.Text);
                komut.Parameters.AddWithValue("@kullaniciad", textBox3.Text);
                komut.Parameters.AddWithValue("@sifre", textBox4.Text);
                komut.Parameters.AddWithValue("@mail", textBox5.Text);
                komut.Parameters.AddWithValue("@id", textBox7.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt İşlemi Gerçekleştirilmiştir");



            }
            catch(Exception hata)
            {
                MessageBox.Show("Kayıt Gerçekleştirilememiştir");
            }
        }

        private void kayit_Load(object sender, EventArgs e)
        {

        }
    }
}
