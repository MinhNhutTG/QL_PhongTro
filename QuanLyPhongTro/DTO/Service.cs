using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.DTO
{
    internal class Service
    {
        private string tenDichVu;
        private decimal giaDichVu;
        public Service() { }
        public string TenDichVu { get { return tenDichVu; } set { tenDichVu = value; } }    
        public decimal GiaDichVu { get {return giaDichVu; } set { giaDichVu = value; } }
    }
}
