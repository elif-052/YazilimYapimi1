using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazilim_Yapimi_Proje
{
    class DataBaseController
    {
        
        private static SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-G8KPTIR;Initial Catalog=Kullanicilar;Integrated Security=True");
        public static KullaniciData GetKullanici(string kulAdi, string parola)
        {
            baglanti.Open();
            string sql = "SELECT k.*, o.OgrenciID, a.AdminID, s.SorumluID FROM [Kullanici] k LEFT JOIN [Admin] a ON a.KullaniciID = k.KullaniciID LEFT JOIN [Sorumlular] s ON s.KullaniciID = k.KullaniciID LEFT JOIN [Ogrenci] o ON o.KullaniciID = k.KullaniciID where k.KullaniciAdi = @kulad AND k.Sifre = @parola";
            SqlParameter prm1 = new SqlParameter("kulad", kulAdi.Trim());
            SqlParameter prm2 = new SqlParameter("parola", parola.Trim());
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.Add(prm1);
            komut.Parameters.Add(prm2);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            baglanti.Close();
            if (dt.Rows.Count > 0)
            {
                var fd = dt.Rows[0];
                KullaniciData kullanici = new KullaniciData(fd);
                return kullanici;

            }
          
            return null;
        }

        public static List<SoruData> GetSorular(int ?ogrenciID)
        {
            baglanti.Open();
            string sql = "SELECT * FROM SorulabilirSorular(@ogrenciID)";
            SqlParameter prm1 = new SqlParameter("ogrenciID", ogrenciID);
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.Add(prm1);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            baglanti.Close();

            List<SoruData> sorular = new List<SoruData>();
            for (int i = 0; i< dt.Rows.Count; i++)
            {
                sorular.Add(new SoruData(dt.Rows[i]));
            }

            return sorular;

        }

        public static void CozulmusSoruEkle(int soruID, int ?ogrenciID, bool bilindiMi)
        {
            baglanti.Open();
            string sql = "exec CozulmusSoruEkle @soruID = @sID, @OgrenciID = @oID, @BilindiMi = @bilindi";
            SqlParameter prm1 = new SqlParameter("sID", soruID);
            SqlParameter prm2 = new SqlParameter("oID", ogrenciID);
            SqlParameter prm3 = new SqlParameter("bilindi", bilindiMi);
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.Add(prm1);
            komut.Parameters.Add(prm2);
            komut.Parameters.Add(prm3);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
