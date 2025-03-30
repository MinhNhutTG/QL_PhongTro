using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyPhongTro.DAL
{
    internal class DAL_Login
    {
        DatabaseConnect db = new DatabaseConnect();

        public bool checkLogin(string username, string password)
        {
            string sql =  string.Format("Select * from TaiKhoan where UserName = '{0}' and PassWord = {1} ",username , password);
            DataTable dt = db.Execute(sql);
            if (dt != null && dt.Rows.Count > 0) { 
                return true;
            }
            return false;
        }
        public bool CheckEmail(string email)
        {
            string sql = string.Format("select * from TaiKhoan where TaiKhoan.EmailUser = '{0}'", email);
            DataTable dt = db.Execute(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool rePass(string code)
        {
            string sql = string.Format("Update TaiKhoan Set PassWord = '{0}'", code);
            if (db.ExecuteNonQuery(sql) > 0)
            {
                return true;
            }
            return false;
        }
        public bool LoginByCode(string code) {

            string sql = string.Format("Select * from TaiKhoan where  PassWord = {0} ",code);
            DataTable dt = db.Execute(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
