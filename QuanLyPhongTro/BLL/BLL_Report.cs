using QuanLyPhongTro.DAL;
using QuanLyPhongTro.GUI.Custom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.BLL
{
    internal class BLL_Report
    {
        DAL_Report dalreport = new DAL_Report();
        public DataTable TKDoanhThuThang(int year)
        {
            return dalreport.TKDoanhThuThang(year);
        }
        public DataTable TKDoanhThuQuy(int year)
        {
            return dalreport.TKDoanhThuQuy(year);
        }
        public DataTable TKDoanhThuCacPhong()
        {
            return dalreport.TKDoanhThuCacPhong();
        }
        public DataTable TKDoanhThuPhong(string idRoom)
        {
            return dalreport.TKDoanhThuPhong(idRoom);
        }
        public DataTable TKSoLuongTinhTrangPhong()
        {
            return dalreport.TKSoLuongTinhTrangPhong();
        }
        public int TKTongSoHopDong()
        {
            return dalreport.TKTongSoHopDong();
        }
        public int TKHopDongConHan()
        {
            return dalreport.TKHopDongConHan();
        }
        public int TKHopDongMoiTrongThang() {
            return dalreport.TKHopDongMoiTrongThang();
        }
       public DataTable TKTongTienDienTieuThu()
        {
            return dalreport.TKTongTienDienTieuThu();
        }
        public DataTable TKTongTienNuocTieuThu()
        {
            return dalreport.TKTongTienNuocTieuThu();
        }
        public DataTable TongTienDienMoiThang(int year)
        {
            return dalreport.TongTienDienMoiThang(year);
        }
        public DataTable TongTienNuocMoiThang(int year)
        {
            return dalreport.TongTienNuocMoiThang(year);
        }
        public DataTable TongTienMangMoiThang(int year)
        {
            return dalreport.TongTienMangMoiThang(year);
        }
        public DataTable TongDoanhThuDichVuMoiThang(int year)
        {
            return dalreport.TongDoanhThuDichVuMoiThang(year);
        }
        //// ROOM 
        ///
        public List<int> getNumberStatusRoom()
        {
            return dalreport.getNumberStatusRoom();
        }
        public List<int> getNumberStatusBill()
        {
            return dalreport.getNumberStatusBill();
        }

        public List<DTO.Bill> FillBillToDate(string Date1, string Date2)
        {
            if (Convert.ToDateTime(Date1) > Convert.ToDateTime(Date2))
            {
                throw new BusinessException("Ngày bắt đầu phải nhỏ hơn ngày kết thúc");
            }
            return dalreport.FillBillToDate(Date1,Date2);
        }

    }
}
