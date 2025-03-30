using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.DTO
{
    internal class Config
    {
        private string tenNhaTro;
        private string soTaiKhoan;
        private string tenTaiKhoan;
        private string tenNganHang;
        private string emailSystem;
        private string appPassword;

        public string TenNhaTro
        {
            get { return tenNhaTro; }
            set { tenNhaTro = value; }
        }

        // Getter và Setter cho soTaiKhoan
        public string SoTaiKhoan
        {
            get { return soTaiKhoan; }
            set { soTaiKhoan = value; }
        }

        // Getter và Setter cho tenTaiKhoan
        public string TenTaiKhoan
        {
            get { return tenTaiKhoan; }
            set { tenTaiKhoan = value; }
        }

        // Getter và Setter cho tenNganHang
        public string TenNganHang
        {
            get { return tenNganHang; }
            set { tenNganHang = value; }
        }

        // Getter và Setter cho emailSystem
        public string EmailSystem
        {
            get { return emailSystem; }
            set { emailSystem = value; }
        }

        // Getter và Setter cho appPassword
        public string AppPassword
        {
            get { return appPassword; }
            set { appPassword = value; }
        }
        public Config() { }

    }
}
