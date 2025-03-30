using QuanLyPhongTro.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro.DAL
{
    internal class DAL_Service
    {
        DatabaseConnect db = new DatabaseConnect();
        public Service getServiceByName(string name)
        {
            string sql = string.Format("select * from DichVu WHERE DichVu.TenDichVu = N'{0}'", name);
            DataTable dt = db.Execute(sql);
            Service service = new Service();
            if (dt != null)
            {
                service.TenDichVu = dt.Rows[0][0].ToString();
                service.GiaDichVu = Convert.ToDecimal(dt.Rows[0][1]);
            }
            return service;
        }
        public List<Service> getlistService()
        {
            List<Service> list = new List<Service>();
            
            string sql = "SELECT * FROM DichVu";
            DataTable dt = db.Execute(sql);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Service service = new Service();
                   
                    service.TenDichVu = dt.Rows[i][0].ToString();
                    service.GiaDichVu = Convert.ToDecimal(dt.Rows[i][1]);
                    list.Add(service);
                }
                
            }
         
            return list;
        }

        public bool Delete(string nameService)
        {
            string sql = string.Format("DELETE DichVu WHERE TenDichVu = N'{0}'",nameService);
            if (db.ExecuteNonQuery(sql) > 0)
            {
                return true;
            }
            return false;
        }
        public bool Add(Service service)
        {
            string sql = string.Format("INSERT INTO DichVu VALUES (N'{0}',{1});", service.TenDichVu, service.GiaDichVu);
            if (db.ExecuteNonQuery(sql) > 0)
            {
                return true;
            }
            return false;
        }
        public bool Update(Service service) {
            string sql = string.Format("UPDATE DichVu  SET Gia = {0} WHERE TenDichVu = N'{1}'", service.GiaDichVu, service.TenDichVu);
            if (db.ExecuteNonQuery(sql) > 0)
            {
                return true;
            }
            return false;
        }

        public bool Exist(string nameService)
        {
            string sql = string.Format("SELECT * FROM DichVu WHERE DichVu.TenDichVu = N'{0}';", nameService);
            DataTable dt = db.Execute(sql);
            if (dt.Rows.Count > 0) { return true; }
            return false;
        }
    }
}
