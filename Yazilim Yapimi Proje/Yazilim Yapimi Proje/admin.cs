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
    public partial class admin : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-G8KPTIR;Initial Catalog=Kullanicilar;Integrated Security=True");
        public admin()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            anafrm ac = new anafrm();
            ac.Show();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sifre ac = new sifre();
            ac.Show();
            ac.Dispose();
            this.Hide();
            
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                var kullanici = DataBaseController.GetKullanici(textBox1.Text, textBox2.Text);
                if (kullanici.IsAdmin())
                {
                    ogrenciliste sc = new ogrenciliste(kullanici);
                    sc.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Böyle bir kullanıcı bulunamadı. Kullanıcı adın şifren doğru mu ? emnin misin?");
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı giriş yaptınız lütfen tekrar deneyiniz");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
