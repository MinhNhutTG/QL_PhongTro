using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongTro.DTO;
using QuanLyPhongTro.DAL;
using System.Data;
using QuanLyPhongTro.GUI.Custom;
using QuanLyPhongTro.GUI.Notify;
using System.Drawing;

namespace QuanLyPhongTro.BLL
{
    internal class BLL_Bill
    {
        DAL_RoomService dalhistoryService = new DAL_RoomService();
        DAL_Bill dalbill = new DAL_Bill();
        public List<Bill> getListBill()
        {
            return dalbill.GetListBill();
        }
        public bool ExistBill(string id)
        {
            return dalbill.ExistBill(id);
        }
        public bool AddBill(Bill bill)
        {
            if (string.IsNullOrEmpty(bill.IdHoaDon))
            {
                throw new BusinessException("Mã hóa đơn không được để trống");
            }
            if (bill.IdDichVu == 0)
            {
                bill.IdDichVu = null;
            }
            if (string.IsNullOrEmpty(bill.SoPhong))
            {
                throw new BusinessException("Số phòng không được để trống");
            }
            if (string.IsNullOrEmpty(bill.TongTien.ToString()))
            {
                throw new BusinessException("Tổng tiền không được để trống");
            }
          
            if (string.IsNullOrEmpty(bill.TrangThai))
            {
                throw new BusinessException("Trạng thái hóa đơn không được để trống");
            }
            return dalbill.AddBill(bill);
        }
        public bool DeleteBill(string id) {
            Bill bill =  dalbill.FindBillByID(id);
            if (bill.TrangThai == "Chưa Thanh Toán")
            {
                dalhistoryService.UpdateStatus("Chờ Lập Hóa Đơn", bill.IdDichVu.ToString());
            }
            return dalbill.DeleteBill(id);
        }
        public Bill FindBillByID(string id)
        {
            return dalbill.FindBillByID(id);
        }
        public bool UpdateBill(Bill b)
        {
            if (string.IsNullOrEmpty(b.IdHoaDon))
            {
                throw new BusinessException("Mã hóa đơn không được để trống");
            }
            if (string.IsNullOrEmpty(b.SoPhong))
            {
                throw new BusinessException("Số phòng không được để trống");
            }
            if (string.IsNullOrEmpty(b.TongTien.ToString()))
            {
                throw new BusinessException("Tổng tiền không được để trống");
            }
            if (b.NgayLapHoaDon == null)
            {
                throw new BusinessException("Ngày lập hóa đơn không được để trống");
            }
            if (string.IsNullOrEmpty(b.TrangThai))
            {
                throw new BusinessException("Trạng thái hóa đơn không được để trống");
            }
            return dalbill.UpdateBill(b);
        }
        public List<Bill> FillBillByDate(DateTime dt) {
            return dalbill.FillBillByDate(dt);
        }
        public List<Bill> FillBillPaid(string status)
        {
            return dalbill.FillBillPaid(status);
        }
        public List<Bill> FillBillByKey(string key)
        {
            return dalbill.FillBillByKey(key);
        }
    }
}
