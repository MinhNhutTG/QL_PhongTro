using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyPhongTro.DTO
{
    internal class Room
    {
        private string soPhong;
        private string trangThai;
        private string maLoai;
        private string ghiChu;
        private string tenLoai;
        private decimal gia;

        public string SoPhong
        {
            get { return soPhong; }
            set { soPhong = value; }
        }

        public string TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }

        public string MaLoai
        {
            get { return maLoai; }
            set { maLoai = value; }
        }

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
       
        public string TenLoai
        {
            get { return tenLoai; }
            set { tenLoai = value; }
        }
        public decimal Gia
        {
            get { return gia; }
            set { gia = value; }
        }

    }
}
