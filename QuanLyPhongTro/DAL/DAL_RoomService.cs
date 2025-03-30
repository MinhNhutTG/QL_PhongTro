using QuanLyPhongTro.DTO;
using QuanLyPhongTro.GUI.Notify;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro.DAL
{
    internal class DAL_RoomService
    {

        DatabaseConnect db = new DatabaseConnect();
        public bool AddHisSV(RoomService hs)
        {
            string sql = string.Format("INSERT INTO DichVuPhong " +
                "VALUES ({0},'{1}', '{2}', '{3}', {4}, {5}, {6}, {7},{8},{9}, '{10}' , {11} ,N'{12}')", hs.ID, hs.MaHopDong,hs.SoPhong, hs.Ki, hs.SoDienCu, hs.SoDienMoi, hs.SoNuocCu, hs.SoNuocMoi, hs.GiaDien, hs.GiaNuoc, hs.NgayTao,hs.TienMang,hs.TrangThai);
            if (db.ExecuteNonQuery(sql) > 0)
            {
                return true;
            }
            return false;
        }
      
        public bool RemoveHisSV(int id)
        {
            string sql = string.Format("DELETE HoaDon WHERE  HoaDon.IDDichVu = {0} \r\nDELETE DichVuPhong WHERE DichVuPhong.ID = {0}\r\n ", id);
            if (db.ExecuteNonQuery(sql) > 0)
            {
                return true;
            }
            return false;
        }

        public bool Update(RoomService hs)
        {

            string sql = string.Format(" UPDATE DichVuPhong " +
                "SET SoPhong  = '{0}',  Ki = '{1}', SoDienCu = {2}, SoDienMoi = {3}, SoNuocCu = {4}, SoNuocMoi = {5}, GiaDien  = {6}, GiaNuoc   = {7}, NgayTao = '{8}', TienMang= {9} , TrangThai = N'{10}' " +
                "WHERE ID = {11};", hs.SoPhong, hs.Ki, hs.SoDienCu, hs.SoDienMoi, hs.SoNuocCu, hs.SoNuocMoi, hs.GiaDien, hs.GiaNuoc, hs.NgayTao,hs.TienMang,hs.TrangThai, hs.ID);
            if (db.ExecuteNonQuery(sql) > 0)
            {
                return true;
            }
            return false;
        }
       
        public RoomService getHistoryServiceByID(int id)
        {
            string sql = string.Format("select * from DichVuPhong where DichVuPhong.ID = {0}", id);
            DataTable dt = db.Execute(sql);
            RoomService service = new RoomService();
           
            foreach (DataRow dr in dt.Rows)
            {
                service.ID = Convert.ToInt32(dr["ID"]);
                service.MaHopDong = dr["MaHopDong"].ToString();
                service.SoPhong = dr["SoPhong"].ToString();
                service.Ki = dr["Ki"].ToString();
                service.SoDienCu = Convert.ToInt32(dr["SoDienCu"]);
                service.SoDienMoi = Convert.ToInt32(dr["SoDienMoi"]);
                service.SoNuocCu = Convert.ToInt32(dr["SoNuocCu"]);
                service.SoNuocMoi = Convert.ToInt32(dr["SoNuocMoi"]);
                service.GiaDien = Convert.ToDecimal(dr["GiaDien"]);
                service.GiaNuoc = Convert.ToDecimal(dr["GiaNuoc"]);
                service.NgayTao = Convert.ToDateTime(dr["NgayTao"]);
                service.TienMang = Convert.ToDecimal(dr["TienMang"]);
                service.TrangThai = dr["TrangThai"].ToString();

            }
           
            return service;
        }
        public List<RoomService> GetListHistoryService()
        {
            string sql = "select * from DichVuPhong  ORDER BY KI DESC  ";
            DataTable dt = db.Execute(sql);
            return ChangeDataTableToList(dt);

        }
        public List<RoomService> GetListHistoryServiceByID(int id)
        {
            string sql = string.Format("select * from DichVuPhong where SoPhong = {0} ORDER BY KI DESC", id);
            DataTable dt = db.Execute(sql);
            return ChangeDataTableToList(dt);

        }
        public List<int> getValueOldService(string idRoom)
        {
            string sql = string.Format("SELECT TOP 1 * FROM DichVuPhong WHERE SoPhong = {0} ORDER BY NGAYTAO DESC;", idRoom);
            DataTable dt = db.Execute(sql);
            List<int> List = new List<int>();
            foreach (DataRow dr in dt.Rows)
            {

                int value = Convert.ToInt32(dr["SoDienMoi"]);

                List.Add(value);
                int value2 = Convert.ToInt32(dr["SoNuocMoi"]);
                List.Add(value2);
            }
            return List;
        }
        public bool ExistID(int id)
        {
            string sql = string.Format("select * from DichVuPhong where ID= {0}", id);
            DataTable dt = db.Execute(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }


        ///// ////// Sort 
        ///
        public List<RoomService> SortKI_DESC()
        {
            string sql = "SELECT * FROM DichVuPhong\r\nORDER BY DichVuPhong.Ki DESC;";
            DataTable dt = db.Execute(sql);
            List<RoomService> list = new List<RoomService>();
            return ChangeDataTableToList(dt);
        }
        public List<RoomService> SortKI_ASC()
        {
            string sql = "SELECT * FROM DichVuPhong\r\nORDER BY DichVuPhong.Ki ASC;";
            DataTable dt = db.Execute(sql);
            return ChangeDataTableToList(dt);
        }

        public List<RoomService> HistoryServicesByIDRoom(string IDroom)
        {
            string sql = string.Format("select * from DichVuPhong where SoPhong = '{0}' ORDER BY KI DESC", IDroom);
            DataTable dt = db.Execute(sql);
            return ChangeDataTableToList(dt);
        }
        public List<RoomService> ChangeDataTableToList(DataTable dt)
        {
            List<RoomService> list = new List<RoomService>();
            foreach (DataRow dr in dt.Rows)
            {
                RoomService service = new RoomService();
                service.ID = Convert.ToInt32(dr["ID"]);
                service.MaHopDong = dr["MaHopDong"].ToString();
                service.SoPhong = dr["SoPhong"].ToString();
                service.Ki = dr["Ki"].ToString();
                service.SoDienCu = Convert.ToInt32(dr["SoDienCu"]);
                service.SoDienMoi = Convert.ToInt32(dr["SoDienMoi"]);
                service.SoNuocCu = Convert.ToInt32(dr["SoNuocCu"]);
                service.SoNuocMoi = Convert.ToInt32(dr["SoNuocMoi"]);
                service.GiaDien = Convert.ToDecimal(dr["GiaDien"]);
                service.GiaNuoc = Convert.ToDecimal(dr["GiaNuoc"]);
                service.NgayTao = Convert.ToDateTime(dr["NgayTao"]);
                service.TienMang = Convert.ToDecimal(dr["TienMang"]);
                service.TrangThai = dr["TrangThai"].ToString();
                list.Add(service);
            }
            return list;
        }
       
        public List<RoomService> GetPendingServiceHistory() {
            string sql = "select * from DichVuPhong where DichVuPhong.TrangThai = N'Chờ Lập Hóa Đơn' ";
            DataTable dt = db.Execute(sql);
            List<RoomService> list = new List<RoomService>();
            return ChangeDataTableToList(dt);
        }
        public bool UpdateStatus(string status, string idLS)
        {
            string sql = string.Format("Update DichVuPhong SET DichVuPhong.TrangThai = N'{0}' where DichVuPhong.ID = '{1}'", status,idLS);
            DataTable dt = db.Execute(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public List<RoomService> FillHistoryByStatus(string status)
        {
            string sql = string.Format("select * from DichVuPhong where DichVuPhong.TrangThai = N'{0}'", status);
            DataTable dt = db.Execute(sql);
            return ChangeDataTableToList(dt);
        }
    }
}
