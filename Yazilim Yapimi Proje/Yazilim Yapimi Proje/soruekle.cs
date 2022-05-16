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
    public partial class soruekle : Form
    {
        KullaniciData aktifKullanici = null;
        public soruekle(KullaniciData aktifKullanici)
        {
            InitializeComponent();
            this.aktifKullanici = aktifKullanici;
            MessageBox.Show("Giriş yapan:" + this.aktifKullanici.adi);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sorumlu ac = new sorumlu();
            ac.Show();
            this.Dispose();
        }
    }
}
