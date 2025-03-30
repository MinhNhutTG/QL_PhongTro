using QuanLyPhongTro.DAL;
using QuanLyPhongTro.DTO;
using QuanLyPhongTro.GUI.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro.BLL
{
    internal class BLL_RoomService
    {
        DAL_RoomService dal_HistoryService = new DAL_RoomService();
        DAL_Rooms dalroom = new DAL_Rooms();
        public RoomService getHistoryServiceByID(int id)
        {
            return dal_HistoryService.getHistoryServiceByID(id);
        }
        public List<RoomService> GetListHistoryServiceByID(int id)
        {
            return dal_HistoryService.GetListHistoryServiceByID(id);
        }
        public List<int> getValueOldService(string idRoom)
        {
            return dal_HistoryService.getValueOldService(idRoom);
        }
        public List<RoomService> GetListHistoryService() { 
            return dal_HistoryService.GetListHistoryService();
        }
        public bool ExistID(int id)
        {
            return dal_HistoryService.ExistID(id);
        }
        public bool AddHistoryService(RoomService hs)
        {
            if (string.IsNullOrEmpty(hs.ID.ToString()))
            {
                throw new BusinessException("ID không được để trống");
            }
            if (!dalroom.RoomExist(hs.SoPhong))
            {
                throw new BusinessException("Phòng không tồn tại");
            }
            if (string.IsNullOrEmpty(hs.Ki.ToString()))
            {
                throw new BusinessException("Kì không được bỏ trống");
            }
            if (string.IsNullOrEmpty(hs.SoDienCu.ToString()))
            {
                throw new BusinessException("Số điện cũ không được bỏ trống");
            }
            if (string.IsNullOrEmpty(hs.SoDienMoi.ToString()))
            {
                throw new BusinessException("Số điện mới không được bỏ trống");
            }
            if (string.IsNullOrEmpty(hs.SoNuocCu.ToString()))
            {
                throw new BusinessException("Số nước cũ không được bỏ trống");
            }
            if (string.IsNullOrEmpty(hs.SoNuocMoi.ToString()))
            {
                throw new BusinessException("Số nước mới không được bỏ trống");
            }
            if (string.IsNullOrEmpty(hs.GiaNuoc.ToString()))
            {
                throw new BusinessException("Giá nước không được bỏ trống");
            }
            if (string.IsNullOrEmpty(hs.GiaDien.ToString()))
            {
                throw new BusinessException("Giá điện không được bỏ trống");
            }
            if (string.IsNullOrEmpty(hs.NgayTao.ToString()))
            {
                throw new BusinessException("Ngày tạo không được bỏ trống");
            }
            return dal_HistoryService.AddHisSV(hs);
        }
        public bool RemoveHistoryService(int id)
        {
            return dal_HistoryService.RemoveHisSV(id);
        }

        public bool UpdateHistoryService(RoomService hs)
        {

            return dal_HistoryService.Update(hs);
        }
        public List<RoomService> SortKI_DESC()
        {
            return dal_HistoryService.SortKI_DESC();
        }
        public List<RoomService> SortKI_ASC()
        {
            return dal_HistoryService.SortKI_ASC();
        }
        public List<RoomService> HistoryServicesByIDRoom(string idRoom)
        {
            return dal_HistoryService.HistoryServicesByIDRoom(idRoom);
        }
     
     
        public List<RoomService> GetPendingServiceHistory()
        {
            return dal_HistoryService.GetPendingServiceHistory();
        }
        public bool UpdateStatus(string status , string idLS)
        {
            return dal_HistoryService.UpdateStatus(status, idLS);
        }
        public List<RoomService> FillHistoryByStatus(string status)
        {
            return dal_HistoryService.FillHistoryByStatus(status);
        }
    }
}
