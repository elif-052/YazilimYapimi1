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
    
    public partial class sinav : Form
    {

      

        KullaniciData aktifKullanici = null;
        List<SoruData> sorulacakSorular;
        int sorulmusSoruAdet = 0;
        int sorulacakSoruAdet = 10;

        SoruData sorulanSoru = null;
        string secilenCevapText = "";
        public sinav(KullaniciData aktifKullanici)
        {
            InitializeComponent();
            this.aktifKullanici = aktifKullanici;
            sorulacakSorular = DataBaseController.GetSorular(this.aktifKullanici.ogrenciData.id);
          
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Bitir")
                this.Close();

            if (!timer1.Enabled)
                timer1.Enabled = true;

            if (sorulmusSoruAdet == sorulacakSoruAdet)
                button1.Text = "Bitir";
            else
                button1.Text = "Sonraki Soru";

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

           

            if (sorulanSoru != null)
                DataBaseController.CozulmusSoruEkle(sorulanSoru.id, aktifKullanici.ogrenciData.id, SoruBilindiMi());

            if (sorulmusSoruAdet <= sorulacakSoruAdet)
                SoruYaz(sorulacakSorular[(new Random()).Next(0, sorulacakSorular.Count)]);
            sorulmusSoruAdet++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.Hour.ToString();
            label4.Text = DateTime.Now.Minute.ToString();

            if(comboBox2.Text== label4.Text)
            {
                timer1.Enabled = false;
                MessageBox.Show("Süreniz Bitmiştir");             
            }
        }

        private void sinav_Load(object sender, EventArgs e)
        {
            SoruYaz(sorulacakSorular[0]);
        }

        public void SoruYaz(SoruData soru)
        {
            sorulanSoru = soru;
            richTextBox1.Text = soru.sorutext;

            radioButton1.Text = soru.cevaps[0];
            radioButton2.Text = soru.cevaps[1];
            radioButton3.Text = soru.cevaps[2];
            radioButton4.Text = soru.cevaps[3];

            pictureBox1.ImageLocation = soru.resim;
        }

        private  bool SoruBilindiMi()
        {
            return secilenCevapText == sorulanSoru.dogru;
        }

        private void CevapChecked(object sender, EventArgs e)
        {
            RadioButton rd = sender as RadioButton;
            secilenCevapText = rd.Text;
        }
    }
    
}
