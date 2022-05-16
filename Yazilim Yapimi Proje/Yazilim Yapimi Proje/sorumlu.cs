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
    public partial class sorumlu : Form
    {
     

        public sorumlu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            anafrm ac = new anafrm();
            ac.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sifre ac = new sifre();
            ac.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                var kullanici = DataBaseController.GetKullanici(textBox1.Text, textBox2.Text);
                if (kullanici.IsSorumlu())
                {
                    soruekle sc = new soruekle(kullanici);
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
    }
}
