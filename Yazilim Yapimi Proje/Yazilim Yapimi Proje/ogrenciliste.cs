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
    public partial class ogrenciliste : Form
    {
        KullaniciData aktifKullanici = null;
        public ogrenciliste(KullaniciData aktifKullanici)
        {
            InitializeComponent();
            this.aktifKullanici = aktifKullanici;
            MessageBox.Show("Giriş yapan:" + this.aktifKullanici.adi);
        }
    }
}
