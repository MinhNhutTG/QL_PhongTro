using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.DTO
{
    internal class DetailContract
    {
        private string idHopDong;
        private int maKhach;
        private string vaiTro;
        public string IDHopDong {
            get { return idHopDong; }
            set { idHopDong = value; }
        }
        public int MaKhach
        {
            get { return maKhach; }
            set { maKhach = value; }
        }
        public string VaiTro
        {
            get { return vaiTro; }
            set { vaiTro = value; }
        }

    }
}
