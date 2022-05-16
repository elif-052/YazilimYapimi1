using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yazilim_Yapimi_Proje
{
    public partial class sinavsec : Form
    {
        KullaniciData aktifKullanici = null;
        public sinavsec(KullaniciData aktifKullanici)
        {
            InitializeComponent();
            this.aktifKullanici = aktifKullanici;
            MessageBox.Show("Giriş Yapabn: " + this.aktifKullanici.adi);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sinav ac = new sinav(aktifKullanici);
            ac.Show();
           
        }
    }
}
