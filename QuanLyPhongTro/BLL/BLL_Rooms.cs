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
using System.Windows.Forms;

namespace QuanLyPhongTro.BLL
{
    internal class BLL_Rooms
    {
        DAL_Rooms dalroom = new DAL_Rooms();
        public List<Room> getlistRoom()
        {
            return dalroom.getListRoom();
        }
        public List<string> getListRoomID()
        {
            return dalroom.getListRoomByID();
        }
        public List<string> getListRoomEmpty()
        {
            return dalroom.getListRoomEmpty();
        }
       
        public DataTable GetTypeRoom()
        {
            return dalroom.GetTypeRoom();
        }
       
        public string GetTypeRoomByID(string id)
        {
            return dalroom.GetTypeRoomByID(id);
        }

        public decimal GetPriceRoomByID(string maLoai)
        {
            return dalroom.GetPriceRoomByID(maLoai);
        }
        public List<string> ListRoomInContract()
        {
            return dalroom.ListRoomInContract();
        }

        public DataTable getDataTypeRoom()
        {
            return dalroom.getDataTypeRoom();
        }

        /////////////////////

        public List<Room> fillerTypeRoom(string maloai ) { 
            return dalroom.fillerTypeRoom(maloai);
        }
        public List<Room> fillerStatusRoom(string trangthai)
        {
            return dalroom.fillerStatusRoom(trangthai);
        }
        public List<Room> fillerStatusAndType(string maloai , string trangthai)
        {
            return dalroom.fillerStatusAndType(maloai,trangthai);
        }

        //////////////////
     
        public bool UpdateRoom(Room r)
        {
            if (string.IsNullOrEmpty(r.SoPhong)) { throw new BusinessException("Số phòng không được bỏ trống"); }
            if (string.IsNullOrEmpty(r.TrangThai)) { throw new BusinessException("Trạng thái phòng không được bỏ trống");  }
            if (r.MaLoai == "L") { throw new BusinessException("Cần lựa loại phòng phù hợp");}
            
            return dalroom.UpdateRoom(r);
        }
        public bool AddRoom(Room r)
        {
            if (dalroom.RoomExist(r.SoPhong) == true) { { throw new BusinessException("Phòng đã tồn tại"); } }
            if (string.IsNullOrEmpty(r.SoPhong)) { throw new BusinessException("Số phòng không được bỏ trống"); }
            if (string.IsNullOrEmpty(r.TrangThai)) { throw new BusinessException("Trạng thái phòng không được bỏ trống"); }
            if (r.MaLoai == "L") { throw new BusinessException("Cần lựa loại phòng phù hợp"); }
            return dalroom.AddRoom(r);
        }
        public bool removeRoom(string soPhong)
        {
            if (string.IsNullOrEmpty(soPhong.ToString()))
            {
                throw new BusinessException("Số không hợp lệ");
            }
           
            return dalroom.RemoveRoom(soPhong);
        }
        public bool roomExist(string id)
        {
            return dalroom.RoomExist(id);
        }
    
        /////////
        ///
       
        public bool UpdateTypeRoom(string maLoai, string tenMaLoai, string Gia)
        {
            if (string.IsNullOrEmpty(maLoai))
            {
                throw new  BusinessException("Mã loại không được bỏ trống");
            }
            else
            {
                if (dalroom.TypeRoomExist(maLoai) == true)
                {
                    if (dalroom.UpdateTypeRoom(maLoai, tenMaLoai, Gia) == true)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    if (dalroom.AddTypeRoom(maLoai, tenMaLoai, Gia) == true)
                    {
                        return true;
                    }
                    return false;
                }
                
            }
           
        }
        public bool RemoveTypeRoom(string maLoai)
        {
           return  dalroom.RemoveTypeRoom(maLoai);
        }
      
        public Room FindRoomByID(int id)
        {
            return dalroom.FindRoomByID(id);
        }
    }
}
