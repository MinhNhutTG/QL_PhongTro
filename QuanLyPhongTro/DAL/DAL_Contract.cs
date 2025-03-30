using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongTro.DTO;


namespace QuanLyPhongTro.DAL
{
    internal class DAL_Contract
    {
        DatabaseConnect db = new DatabaseConnect();
        DAL_Rooms bllroom = new DAL_Rooms();

        // << GET >>
        public List<DTO.Contract> getListContract()
        {
            string sql = "SELECT * from HopDongThue ORDER BY NgayTaoHopDong DESC;";
            DataTable dt = db.Execute(sql);
            List<DTO.Contract> listcontract = new List<DTO.Contract>();
        
            foreach (DataRow row in dt.Rows)
            {
                DTO.Contract contract = new DTO.Contract()
                {
                    Id = row["ID"].ToString(),
                    NgayThue = Convert.ToDateTime(row["NgayThue"]),
                    HanThue = Convert.ToDateTime(row["HanThue"]),
                    SoPhong = Convert.ToInt32(row["SoPhong"]),
                    GiaPhong = Convert.ToDecimal(row["GiaPhong"]),
                    TrangThai = row["TrangThai"].ToString(),
                    NgayTaoHopDong = Convert.ToDateTime(row["NgayTaoHopDong"]) 
                };
                listcontract.Add(contract);
            }
             return listcontract;
        }
        public string getIdContractByIDGuest(int idGuest)
        {
            string sql = string.Format("select ID from HopDongThue where HopDongThue.ID IN (Select ChiTietHopDong.IDHopDong from ChiTietHopDong where ChiTietHopDong.MaKhach = '{0}')", idGuest);   
            DataTable dt = db.Execute(sql);
            if(dt.Rows.Count > 0)
            {
                return dt.Rows[0]["ID"].ToString();
            }
            return null;
        }

        public string getIDContractByIDRoom(string idRoom)
        {
            string sql = string.Format("select HopDongThue.ID from HopDongThue where HopDongThue.SoPhong In (select Phong.SoPhong from Phong where Phong.SoPhong = {0} ) and HopDongThue.TrangThai = N'Đang Hiệu Lực'",idRoom);
            DataTable dt = db.Execute(sql);
            return dt.Rows[0]["ID"].ToString();
        }

        // << CRUD >>
        public bool AddContract(DTO.Contract contract)
        {
            string sql = string.Format("INSERT INTO HopDongThue  VALUES('{0}','{1}','{2}','{3}',{4},N'{5}','{6}');  " +
                " update Phong set TrangThai = N'Đang Thuê' where Phong.SoPhong = '{3}'"
                , contract.Id, contract.NgayThue , contract.HanThue,contract.SoPhong,contract.GiaPhong,contract.TrangThai, contract.NgayTaoHopDong);
            if (db.ExecuteNonQuery(sql) > 0)
            {
                return true;
            }
            return false;
        }
        public bool CancelContract(string id)
        {
           
            string sql = string.Format("UPDATE HopDongThue SET TrangThai = N'Đã Hủy' WHERE ID = '{0}' " +
                " UPDATE Phong SET TrangThai = N'Trống' WHERE Phong.SoPhong IN (SELECT HopDongThue.SoPhong FROM HopDongThue WHERE HopDongThue.ID = '{0}')" +
                "  UPDATE KhachThue SET TrangThai = N'Đã Kết Thúc Hợp Đồng' WHERE KhachThue.MaKhach IN (SELECT ChiTietHopDong.MaKhach FROM ChiTietHopDong WHERE ChiTietHopDong.IDHopDong = '{0}')", id);
            
            
           
            if (db.ExecuteNonQuery(sql) > 0)
            {
                UpdateStatusListGuest(id);
                return true;
            }
            return false;
        }
        private void UpdateStatusListGuest(string id)
        {

            List<int> listidGuest = getlistIdGuestByIDContract(id);
            foreach (int idGuest in listidGuest)
            {
                string sqlUpdateStatusWhenUseContracts = string.Format("UPDATE KhachThue SET TrangThai = N'Đang Thuê' WHERE KhachThue.MaKhach IN (SELECT ChiTietHopDong.MaKhach FROM ChiTietHopDong WHERE ChiTietHopDong.IDHopDong IN ( " +
                    "SELECT HopDongThue.ID FROM HopDongThue WHERE HopDongThue.TrangThai != N'Đã Hủy') and ChiTietHopDong.MaKhach = {0} )", idGuest);
                db.ExecuteNonQuery(sqlUpdateStatusWhenUseContracts);
            }
        }
        private void UpdateStatusListGuest(List<int> listidGuest)
        {

          
            foreach (int idGuest in listidGuest)
            {
                string sqlUpdateStatusWhenUseContracts = string.Format("UPDATE KhachThue SET TrangThai = N'Đang Thuê' WHERE KhachThue.MaKhach IN (SELECT ChiTietHopDong.MaKhach FROM ChiTietHopDong WHERE ChiTietHopDong.IDHopDong IN ( " +
                    "SELECT HopDongThue.ID FROM HopDongThue WHERE HopDongThue.TrangThai != N'Đã Hủy') and ChiTietHopDong.MaKhach = {0} )", idGuest);
                db.ExecuteNonQuery(sqlUpdateStatusWhenUseContracts);
            }
        }
        public bool RemoveContract(string idcontract) 
        {
            string sql = string.Format("UPDATE KhachThue " +
                " SET KhachThue.TrangThai = N'Đã Kết Thúc Hợp Đồng'" +
                " WHERE KhachThue.MaKhach IN ( SELECT DISTINCT MaKhach FROM ChiTietHopDong WHERE IDHopDong = '{0}');" +
                " UPDATE Phong SET TrangThai = N'Trống' WHERE Phong.SoPhong IN (SELECT DISTINCT HopDongThue.SoPhong FROM HopDongThue where HopDongThue.ID = '{0}')" +
                " DELETE ChiTietHopDong where IDHopDong = '{0}'" +
                " DELETE HopDongThue where ID = '{0}'", idcontract);
            string sqlDeleteRoomServices = string.Format("DELETE DichVuPhong WHERE DichVuPhong.MaHopDong = '{0}'",idcontract);
            List<int> listIDGuest = getlistIdGuestByIDContract(idcontract);
            if (db.ExecuteNonQuery(sql) > 0 && db.ExecuteNonQuery(sqlDeleteRoomServices) >= 0)
            {
                UpdateStatusListGuest(listIDGuest);
                return true;
            }
            return false;
        } // khach thue da huy hop dong
        public bool AddDetailContract(DTO.DetailContract dtc)
        {
            string sql = string.Format("Insert into ChiTietHopDong values ('{0}',{1},N'{2}') " 
                 + " update KhachThue set TrangThai = 'Đang Thuê' where KhachThue.MaKhach = '{1}'"
                , dtc.IDHopDong,dtc.MaKhach,dtc.VaiTro);
            if (db.ExecuteNonQuery(sql) > 0)
            {
                return true;
            }
            return false;
        }

        // CHECK -- 
        public bool ExistContract(string id)
        {
            string sql = string.Format("select * from HopDongThue where HopDongThue.ID = '{0}'", id);
            DataTable dt = db.Execute(sql);
            if (dt.Rows.Count > 0) { return true; }
            return false;
        }
        public bool CheckCancelContract(string mahd)
        {
            string sql = string.Format("select * from HopDongThue where HopDongThue.TrangThai = N'Đã Hủy' and HopDongThue.ID = '{0}'", mahd);
             DataTable dt = db.Execute(sql);
            if (dt.Rows.Count > 0) { return true; }
            return false;
        }

        // FILL AND FIND
        public List<DTO.Contract> FillContractStatus(string status)
        {
            string sql = string.Format("Select * from HopDongThue where HopDongThue.TrangThai = N'{0}'",status);
            DataTable dt = db.Execute(sql);
            List<DTO.Contract> listcontract = new List<DTO.Contract>();

            foreach (DataRow row in dt.Rows)
            {
                DTO.Contract contract = new DTO.Contract()
                {
                    Id = row["ID"].ToString(),
                    NgayThue = Convert.ToDateTime(row["NgayThue"]),
                    HanThue = Convert.ToDateTime(row["HanThue"]),
                    SoPhong = Convert.ToInt32(row["SoPhong"]),
                    GiaPhong = Convert.ToDecimal(row["GiaPhong"]),
                    TrangThai = row["TrangThai"].ToString(),
                    NgayTaoHopDong = Convert.ToDateTime(row["NgayTaoHopDong"])
                };
                listcontract.Add(contract);
            }
            return listcontract;
        }
        public decimal FindContractByIDRoom(string idRoom)
        {
            string sql = string.Format("SELECT HopDongThue.GiaPhong FROM HopDongThue WHERE HopDongThue.SoPhong = '{0}' AND HopDongThue.TrangThai = N'Còn hạn'", idRoom);
            DataTable dt = db.Execute(sql);
            decimal price = 0;
            if (dt.Rows.Count > 0)
            {
                price = Convert.ToDecimal(dt.Rows[0][0].ToString());
            }
            else
            {
                Room r = bllroom.FindRoomByID(Convert.ToInt32(idRoom));
                price = r.Gia;
            }
            return price;
        }
        public DTO.Contract FindContractByIDContract(string idhd)
        {
            string sql = string.Format("select * from HopDongThue where HopDongThue.ID = '{0}'", idhd);
            DataTable dt = db.Execute(sql);
            DTO.Contract contract = new DTO.Contract();

            foreach (DataRow row in dt.Rows)
            {
                contract.Id = row["ID"].ToString();
                contract.NgayThue = Convert.ToDateTime(row["NgayThue"]);
                contract.HanThue = Convert.ToDateTime(row["HanThue"]);
                contract.SoPhong = Convert.ToInt32(row["SoPhong"]);
                contract.GiaPhong = Convert.ToDecimal(row["GiaPhong"]);
                contract.TrangThai = row["TrangThai"].ToString();
                contract.NgayTaoHopDong = Convert.ToDateTime(row["NgayTaoHopDong"]);
            }
            return contract;

        }
        public List<DetailContract> FindDetailContractByIDContract(string idhd)
        {
            string sql = string.Format("select * from ChiTietHopDong where ChiTietHopDong.IDHopDong =  '{0}'", idhd);
            DataTable dt = db.Execute(sql);
            List<DetailContract> listDtContract = new List<DetailContract>();

            foreach (DataRow row in dt.Rows)
            {
                DetailContract dtcontract = new DetailContract();
                dtcontract.IDHopDong = row["IDHopDong"].ToString();
                dtcontract.MaKhach = Convert.ToInt32(row["MaKhach"]);
                dtcontract.VaiTro = row["VaiTro"].ToString();
                listDtContract.Add(dtcontract);
            }
            return listDtContract;
        }

        public List<int> getlistIdGuestByIDContract(string id) 
        {
            string sql = string.Format("select MaKhach from ChiTietHopDong where ChiTietHopDong.IDHopDong = '{0}'", id);
            DataTable dt = db.Execute(sql);
            List<int> listidGuest = new List<int>();

            foreach (DataRow row in dt.Rows)
            {
                listidGuest.Add(Convert.ToInt32(row["MaKhach"].ToString()));
                
            }
            return listidGuest;
        }
       
    }
}


