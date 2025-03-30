using QuanLyPhongTro.DAL;
using QuanLyPhongTro.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongTro.GUI.Custom;
using System.Drawing;

namespace QuanLyPhongTro.BLL
{
    internal class BLL_Config
    {
        DAL_Config config = new DAL_Config();
        public Config getconfig() { return config.GetConfigBank(); }
        public bool editInforBank(Config cf)
        {
            if (string.IsNullOrEmpty(cf.SoTaiKhoan) || cf.SoTaiKhoan.Length > 10)
            {
                throw new BusinessException("Số tài khoản không được để trống hoặc không quá 10 số");
            }
            if (string.IsNullOrEmpty(cf.TenTaiKhoan))
            {
                throw new BusinessException("Tên tài khoản không được bỏ trống");
            }
            if (string.IsNullOrEmpty(cf.TenNganHang))
            {
                throw new BusinessException("Tên ngân hàng không được bỏ trống");
            }
            return config.editInforBank(cf);
        }
        public bool editInforEmail(Config cf) { 
            if (string.IsNullOrEmpty(cf.EmailSystem))
            {
                throw new BusinessException("Email không được để trống");
            }
            if (string.IsNullOrEmpty(cf.AppPassword))
            {
                throw new BusinessException("App Password không được để trống");
            }
            return config.editInforEmail(cf);

        }

        public Account getAccount() { return config.GetAccount(); }
        public bool editAccount(Account acc)
        {
            if (string.IsNullOrEmpty(acc.UserName))
            {
                throw new BusinessException("UserName không được bỏ trống");
            }
            if (string.IsNullOrEmpty(acc.Password))
            {
                throw new BusinessException("Mật khẩu không được bỏ trống");
            }
            if (string.IsNullOrEmpty(acc.EmailUser))
            {
                throw new BusinessException("Emaill User không được bỏ trống");
            }
            return config.editAccount(acc);
        }
    }

}
