using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongTro.DTO;

namespace QuanLyPhongTro.DAL
{
    
    internal class DAL_Guest
    {
        DatabaseConnect db = new DatabaseConnect();
        DAL_Contract dalcontract = new DAL_Contract();
        

        // <<<< GET >>>
        public List<Guest> getListGuest()
        {
            string sql = "select * from KhachThue";
            DataTable dt = db.Execute(sql);
            List<Guest> list = new List<Guest>();
            foreach (DataRow r in dt.Rows)
            {
                Guest guest = new Guest();
                guest.MaKhach = Convert.ToInt32(r["MaKhach"]);
                guest.HoTen = r["HoTen"].ToString();
                guest.NgaySinh = Convert.ToDateTime(r["NgaySinh"]);
                guest.CCCD = r["CCCD"].ToString();
                guest.SoDienThoai = r["SoDienThoai"].ToString();
                guest.QueQuan = r["QueQuan"].ToString();
                guest.TrangThai = r["TrangThai"].ToString();
                guest.Email = r["Email"].ToString();
                list.Add(guest);
            }
            return list;
        }
        public string getEmail(int id)
        {
            string sql = string.Format("SELECT kt.Email FROM KhachThue kt WHERE kt.MaKhach IN " +
                "(SELECT CTHD.MaKhach FROM ChiTietHopDong CTHD WHERE CTHD.VaiTro = N'Khách Chính' AND CTHD.IDHopDong IN(SELECT HD.ID FROM HopDongThue HD WHERE HD.SoPhong = {0} AND TrangThai = N'Đang Hiệu Lực'))", id);
            DataTable dt = new DataTable();
            dt = db.Execute(sql);
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            return dt.Rows[0][0].ToString();
        }
        public string getNameGuest(int id)
        {
            string sql = string.Format("select KhachThue.HoTen from KhachThue where KhachThue.MaKhach = {0}", id);
            DataTable dt = new DataTable();
            dt = db.Execute(sql);
            return dt.Rows[0][0].ToString();
        }


        // <<<< CHECK >>>
        public bool ExistGuest(int id)
        {
            string sql = string.Format("select * from  KhachThue where KhachThue.MaKhach = {0} ", id);
            DataTable dt = db.Execute(sql);
            if (dt.Rows.Count > 0)
            {
                
                return true;

            }
            return false;
        }
        public bool ExistGuestInDetailContract( int idGuest)
        {
            
            string sql = string.Format("select * from ChiTietHopDong  where ChiTietHopDong.MaKhach = {0} ", idGuest);
            DataTable dt = db.Execute(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }


        // <<<<< CRUD >>>>> 
        public bool AddGuest(Guest g)
        {
            string sql = string.Format("INSERT INTO KhachThue VALUES ({0},N'{1}','{2}','{3}','{4}',N'{5}',N'{6}','{7}')"
                , g.MaKhach, g.HoTen, g.NgaySinh, g.CCCD, g.SoDienThoai, g.QueQuan, g.TrangThai, g.Email);
            if (db.ExecuteNonQuery(sql) > 0)
            {
                return true;
            }
            return false;
        }
        public bool Update(Guest g)
        {
            string sql = string.Format("UPDATE KhachThue " +
                "SET HoTen = N'{0}',    NgaySinh = '{1}',    CCCD = '{2}',   SoDienThoai = '{3}',   QueQuan = N'{4}' , TrangThai = N'{5}',Email = '{6}' WHERE MaKhach = {7} ;"
                ,g.HoTen , g.NgaySinh , g.CCCD , g.SoDienThoai , g.QueQuan ,g.TrangThai,g.Email, g.MaKhach);
            if (db.ExecuteNonQuery(sql) > 0)
            {
                return true;
            }
            return false;
        }
        public bool RemoveGuest(int idGuest)
        {
            string idContract = dalcontract.getIdContractByIDGuest(idGuest);
            string sqlRemoveInDetailContract = string.Format("DELETE FROM ChiTietHopDong WHERE IDHopDong = '{0}' AND MaKhach = {1};", idContract, idGuest);
            string sqlUpdateContractStatus = string.Format("UPDATE HopDongThue SET TrangThai = N'Đã Hủy' WHERE ID = '{0}' AND NOT EXISTS (SELECT 1 FROM ChiTietHopDong WHERE IDHopDong = '{0}');", idContract);
            string sqlRemoveGuest = string.Format("DELETE FROM KhachThue WHERE MaKhach = {0}", idGuest);
            string sqlUpdateStatusRoom = string.Format("UPDATE Phong SET TrangThai = N'Trống' WHERE Phong.SoPhong IN (SELECT HopDongThue.SoPhong From HopDongThue where TrangThai = N'Đã Hủy' AND ID = '{0}')", idContract);
            if (ExistGuestInDetailContract(idGuest) == true)
            {
                
                if (db.ExecuteNonQuery(sqlRemoveInDetailContract) > 0 && db.ExecuteNonQuery(sqlUpdateContractStatus) >= 0 && db.ExecuteNonQuery(sqlRemoveGuest) >= 0 && db.ExecuteNonQuery(sqlUpdateStatusRoom) >= 0)
                {
                    return true;
                }
            }
            else
            {
              
                if (db.ExecuteNonQuery(sqlRemoveGuest) > 0 )
                {
                    return true;
                }
            }
            return false;

        }
        ///


        // << FILL>>
        public Guest FindGuestByID(int id)
        {
            string sql = string.Format("select * from KhachThue where KhachThue.MaKhach = '{0}'", id);
            DataTable dt = db.Execute(sql);
            Guest guest = new Guest();
            foreach (DataRow r in dt.Rows)
            {

                guest.MaKhach = Convert.ToInt32(r["MaKhach"]);
                guest.HoTen = r["HoTen"].ToString();
                guest.NgaySinh = Convert.ToDateTime(r["NgaySinh"]);
                guest.CCCD = r["CCCD"].ToString();
                guest.SoDienThoai = r["SoDienThoai"].ToString();
                guest.QueQuan = r["QueQuan"].ToString();
                guest.TrangThai = r["TrangThai"].ToString();
                guest.Email = r["Email"].ToString();
            }
            return guest;
        }
        public List<Guest> FillGuestStatus(string status)
        {
            string sql = string.Format("SELECT * FROM KhachThue WHERE KhachThue.TrangThai = N'{0}'", status);
            DataTable dt = db.Execute(sql);
            List<Guest> list = new List<Guest>();
            foreach (DataRow r in dt.Rows)
            {
                Guest guest = new Guest();
                guest.MaKhach = Convert.ToInt32(r["MaKhach"]);
                guest.HoTen = r["HoTen"].ToString();
                guest.NgaySinh = Convert.ToDateTime(r["NgaySinh"]);
                guest.CCCD = r["CCCD"].ToString();
                guest.SoDienThoai = r["SoDienThoai"].ToString();
                guest.QueQuan = r["QueQuan"].ToString();
                guest.TrangThai = r["TrangThai"].ToString();
                guest.Email = r["Email"].ToString();
                list.Add(guest);
            }
            return list;
        }
        public List<Guest> FillGuestKey(string key)
        {
          
            string sql = string.Format("Select * from KhachThue where HoTen like N'%{0}%' or CCCD = '{0}'  or SoDienThoai = '{0}'", key);
            DataTable dt = db.Execute(sql);
            List<Guest> list = new List<Guest>();
            foreach (DataRow r in dt.Rows)
            {
                Guest guest = new Guest();
                guest.MaKhach = Convert.ToInt32(r["MaKhach"]);
                guest.HoTen = r["HoTen"].ToString();
                guest.NgaySinh = Convert.ToDateTime(r["NgaySinh"]);
                guest.CCCD = r["CCCD"].ToString();
                guest.SoDienThoai = r["SoDienThoai"].ToString();
                guest.QueQuan = r["QueQuan"].ToString();
                guest.TrangThai = r["TrangThai"].ToString();
                guest.Email = r["Email"].ToString();
                list.Add(guest);
            }
            return list;
        }
    
    }
}
