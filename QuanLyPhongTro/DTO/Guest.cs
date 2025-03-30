using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.DTO
{
    internal class Guest
    {
        private int maKhach;
        private string hoTen;
        private DateTime ngaySinh;
        private string cccd;
        private string soDienThoai;
        private string queQuan;
        private string trangThai;
        private string email;

        public int MaKhach
        {
            get { return maKhach; }
            set { maKhach = value; }
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }

        public string CCCD
        {
            get { return cccd; }
            set { cccd = value; }
        }

        public string SoDienThoai
        {
            get { return soDienThoai; }
            set { soDienThoai = value; }
        }

        public string QueQuan
        {
            get { return queQuan; }
            set { queQuan = value; }
        }
        public string TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public Guest()
        {

        }
    }
}
