using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.DTO
{
    public class Bill
    {
        private string idHoaDon;
        private int? idDichVu;
        private string soPhong;
        private int soDien;
        private decimal tienDien;
        private int soNuoc;
        private decimal tienNuoc;
        private decimal phiKhac;
        private decimal tongTien;
        private DateTime ngayLapHoaDon;
        private string trangThai;
        private string ghiChu;
        private decimal giaPhong;

        public string IdHoaDon
        {
            get { return idHoaDon; }
            set { idHoaDon = value ?? throw new ArgumentNullException(nameof(IdHoaDon)); }
        }

        public int? IdDichVu
        {
            get { return idDichVu; }
            set { idDichVu = value ; }
        }

        public string SoPhong
        {
            get { return soPhong; }
            set { soPhong = !string.IsNullOrEmpty(value) ? value : throw new ArgumentException("Số phòng không được để trống"); }
        }

        public int SoDien
        {
            get { return soDien; }
            set { soDien = value >= 0 ? value : throw new ArgumentOutOfRangeException("Số điện không thể âm"); }
        }

        public decimal TienDien
        {
            get { return tienDien; }
            set { tienDien = value >= 0 ? value : throw new ArgumentOutOfRangeException("Tiền điện không thể âm"); }
        }

        public int SoNuoc
        {
            get { return soNuoc; }
            set { soNuoc = value >= 0 ? value : throw new ArgumentOutOfRangeException("Số nước không thể âm"); }
        }

        public decimal TienNuoc
        {
            get { return tienNuoc; }
            set { tienNuoc = value >= 0 ? value : throw new ArgumentOutOfRangeException("Tiền nước không thể âm"); }
        }

        public decimal PhiKhac
        {
            get { return phiKhac; }
            set { phiKhac = value >= 0 ? value : throw new ArgumentOutOfRangeException("Phí khác không thể âm"); }
        }

        public decimal TongTien
        {
            get { return tongTien; }
            set { tongTien = value >= 0 ? value : throw new ArgumentOutOfRangeException("Tổng tiền không thể âm"); }
        }

        public DateTime NgayLapHoaDon
        {
            get { return ngayLapHoaDon; }
            set { ngayLapHoaDon = value; }
        }

        public string TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        public decimal GiaPhong
        {
            get { return giaPhong; }
            set { giaPhong = value; }
        }

    }
}
