using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Currency : BaseEntity
    {
        public string DovizKodu { get; set; }
        public string DovizCinsi { get; set; }
        public string DovizAdi { get; set; }
        public string Birim { get; set; }
        public string DovizAlis { get; set; }
        public string DovizSatis { get; set; }
        public string EfektifAlis { get; set; }
        public string EfektifSatis { get; set; }
    }
}
