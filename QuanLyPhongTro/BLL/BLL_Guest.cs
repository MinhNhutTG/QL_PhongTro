using QuanLyPhongTro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongTro.DAL;
using QuanLyPhongTro.GUI.Custom;

namespace QuanLyPhongTro.BLL
{
    internal class BLL_Guest
    {
        DAL_Guest dal = new DAL_Guest();

        // << GET >> 
        public List<Guest> getListGuest()
        {
            return dal.getListGuest();
        }
        public string getEmail(int id)
        {
            return dal.getEmail(id);
        }
        public string getGuestName(int id) {
            return dal.getNameGuest(id);
        }
        public bool AddGuest(Guest g)
        {
            if (string.IsNullOrEmpty(g.MaKhach.ToString()))
            {
                throw new BusinessException("Mã khách không được để trống");
            }
            if (string.IsNullOrEmpty(g.HoTen))
            {
                throw new BusinessException("Họ tên khách không được để trống");
            }
            if (string.IsNullOrEmpty(g.NgaySinh.ToString()))
            {
                throw new BusinessException("Ngày sinh khách không được để trống");
            }
            if (g.NgaySinh >= DateTime.Now)
            {
                throw new BusinessException("Ngày sinh khách không hợp lệ");
            }
            if (g.CCCD.Length < 5 || g.CCCD.Length > 13)
            {
                throw new BusinessException("CCCD không hợp lệ");
            } 
            if (g.SoDienThoai.Length != 10)
            {
                throw new BusinessException("Số điện thoại không hợp lệ");
            }
            if (string.IsNullOrEmpty(g.TrangThai))
            {
                throw new BusinessException("Trạng thái khách không được để trống");
            }
           
            return dal.AddGuest(g);
        }

        public bool Update(Guest g)
        {
            if (string.IsNullOrEmpty(g.MaKhach.ToString()))
            {
                throw new BusinessException("Mã khách không được để trống");
            }
            if (string.IsNullOrEmpty(g.HoTen))
            {
                throw new BusinessException("Họ tên khách không được để trống");
            }
            if (string.IsNullOrEmpty(g.NgaySinh.ToString()))
            {
                throw new BusinessException("Ngày sinh khách không được để trống");
            }
            if (g.NgaySinh >= DateTime.Now)
            {
                throw new BusinessException("Ngày sinh khách không hợp lệ");
            }
            if (g.CCCD.Length < 5 || g.CCCD.Length > 13)
            {
                throw new BusinessException("CCCD không hợp lệ");
            }
            if (g.SoDienThoai.Length != 10)
            {
                throw new BusinessException("Số điện thoại không hợp lệ");
            }
            if (string.IsNullOrEmpty(g.TrangThai))
            {
                throw new BusinessException("Trạng thái khách không được để trống");
            }
            return dal.Update(g);
        }

        public bool ExistGuest(int id)
        {
         
            return dal.ExistGuest(id);
        }

        public bool RemoveGuest( int idGuest) { 
             return dal.RemoveGuest(idGuest);
        }

        public Guest FindGuestByID(int id)
        {
            return dal.FindGuestByID(id);
        }
       
        public  List<Guest> FillGuestStatus(string status)
        {
            return dal.FillGuestStatus(status);
        }
        public List<Guest> FillGuestKey(string key)
        {
            return dal.FillGuestKey(key);
        }
    }
}
