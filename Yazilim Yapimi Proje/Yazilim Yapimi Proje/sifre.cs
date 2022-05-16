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
    public partial class sifre : Form
    {
        public sifre()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            anafrm ac = new anafrm();
            ac.Show();
            this.Hide();
            ac.Dispose();
        }
    }
}
