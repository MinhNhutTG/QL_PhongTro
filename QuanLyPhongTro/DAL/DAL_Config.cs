using QuanLyPhongTro.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongTro.BLL;

namespace QuanLyPhongTro.DAL
{
    internal class DAL_Config
    {
        DatabaseConnect db = new DatabaseConnect();
        public Config GetConfigBank() {
            Config cfBank = new Config();
            string sql = "select SoTaiKhoan , TenTaiKhoan,TenNganHang , TenNhaTro , EmailSystem , AppPassWord From Config";
            DataTable dt = db.Execute(sql);
            cfBank.SoTaiKhoan = dt.Rows[0][0].ToString();
            cfBank.TenTaiKhoan = dt.Rows[0][1].ToString().ToUpper();
            cfBank.TenNganHang = dt.Rows[0][2].ToString().ToUpper();
            cfBank.TenNhaTro = dt.Rows[0][3].ToString().ToUpper();
            cfBank.EmailSystem = dt.Rows[0][4].ToString();
            cfBank.AppPassword = dt.Rows[0][5].ToString();
            return cfBank ;  
        }

        public bool editInforBank(Config cf)
        {
            string sql = string.Format("Update Config set SoTaiKhoan = N'{0}' , TenTaiKhoan = N'{1}' , TenNganHang = N'{2}'", cf.SoTaiKhoan, cf.TenTaiKhoan, cf.TenNganHang);
            if (db.ExecuteNonQuery(sql) > 0) {
                return true;
            }
            return false;
        }
        public bool editInforEmail(Config cf)
        {
            string sql = string.Format("Update Config set EmailSystem = '{0}' , AppPassWord = '{1}'", cf.EmailSystem,cf.AppPassword);
            if (db.ExecuteNonQuery(sql) > 0)
            {
                return true;
            }
            return false;
        }
        
        public Account GetAccount()
        {
            string sql = "select * from TaiKhoan";
            Account acc = new Account();
            DataTable dt = db.Execute(sql);
            acc.UserName = dt.Rows[0][0].ToString();
            acc.Password = dt.Rows[0][1].ToString();
            acc.EmailUser = dt.Rows[0][2].ToString();
            return acc;
        }

        public bool editAccount(Account account)
        {
            string sql = string.Format("Update TaiKhoan set UserName = '{0}' , PassWord = '{1}' , EmailUser = '{2}'",account.UserName,account.Password,account.EmailUser);
            if (db.ExecuteNonQuery(sql) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
