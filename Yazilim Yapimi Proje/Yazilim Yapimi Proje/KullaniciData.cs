using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazilim_Yapimi_Proje
{
    public class KullaniciData
    {

        public int id;
        public string adi;
        public string soyadi;
        public string kulAdi;
        public string parola;
        public string mail;
        public AdminData adminData = new AdminData(null);
        public SorumluData sorumluData = new SorumluData(null);
        public OgrenciData ogrenciData = new OgrenciData(null);

        public KullaniciData(int id, string adi, string soyadi, string kulAdi, string parola, string mail)
        {
            this.id = id;
            this.adi = adi;
            this.soyadi = soyadi;
            this.kulAdi = kulAdi;
            this.parola = parola;
            this.mail = mail;

        }

        public KullaniciData(DataRow dw)
        {
            
            this.id = Int32.Parse(dw["KullaniciID"].ToString());
            this.kulAdi = dw["KullaniciAdi"].ToString();
            this.adi = dw["Ad"].ToString();
            this.soyadi = dw["SoyAd"].ToString();
            this.parola = dw["Sifre"].ToString();
            this.mail = dw["Mail"].ToString();

            if (dw["AdminID"] != null && dw["AdminID"].ToString() != "")
                this.adminData.id = Int32.Parse(dw["AdminID"].ToString());
            if (dw["SorumluID"] != null && dw["SorumluID"].ToString() != "")
                this.sorumluData.id = Int32.Parse(dw["SorumluID"].ToString());
            if (dw["OgrenciID"] != null && dw["OgrenciID"].ToString() != "")
                this.ogrenciData.id = Int32.Parse(dw["OgrenciID"].ToString());


        }

        public bool IsAdmin()
        {
            if (this.adminData.id == null)
                return false;
            return true;
        }

        public bool IsSorumlu()
        {
            if (this.sorumluData.id == null)
                return false;
            return true;
        }
        public bool IsOgrenci()
        {
            if (this.ogrenciData.id == null)
                return false;
            return true;
        }
    }
}
