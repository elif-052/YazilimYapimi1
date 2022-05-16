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
    public partial class anafrm : Form
    {
        //SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-G8KPTIR;Initial Catalog;=Kullanicilar;Integrated Security=True");
        
        public anafrm() 
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            admin ac = new admin();
            ac.Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sorumlu ac = new sorumlu();
            ac.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ogrenci ac = new ogrenci();
            ac.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kayit ac = new kayit();
            ac.Show();
            this.Hide();
        }

        private void anafrm_Load(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }
    }
}
