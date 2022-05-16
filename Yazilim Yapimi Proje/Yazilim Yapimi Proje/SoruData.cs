using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazilim_Yapimi_Proje
{
    public class SoruData
    {
        public int id;
        public int dersID;
        public string sorutext;
        public string dogru;
        public string yanlis;
        public string resim;
        public List<string> cevaps = new List<string>();
        public DateTime cozulmeTarihi;
        public SoruData(DataRow dw)
        {
            this.id = Int32.Parse(dw["SoruID"].ToString());
            this.dersID = Int32.Parse(dw["DersID"].ToString());
            this.sorutext = dw["SoruText"].ToString();
            this.dogru = dw["DogruCevap"].ToString();
            this.yanlis = dw["YanlisCevaplar"].ToString();
            this.resim = dw["ResimYolu"].ToString();
            //this.cozulmeTarihi = DateTime.Parse(dw["CozulmeTarihi"].ToString());

            cevaps.Add(dogru);
            cevaps.AddRange(yanlis.Replace("//", "~").Split('~'));

            cevaps.Shuffle();
            
        }

       
    }
}
