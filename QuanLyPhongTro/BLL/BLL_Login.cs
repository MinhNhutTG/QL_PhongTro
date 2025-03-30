using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongTro.DAL;
using QuanLyPhongTro.GUI;
using QuanLyPhongTro.GUI.Custom;
namespace QuanLyPhongTro.BLL
{
    internal class BLL_Login
    {
        DAL_Login login  = new DAL_Login();
        public bool checkLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username) ) { 
                throw new BusinessException("UserName không được trống");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new BusinessException("PassWord không được trống");
            }
            return login.checkLogin(username, password);
        }
        public bool checkMailUser(string email)
        {
            return  login.CheckEmail(email);
        }
        public bool RePass(string code)
        {
           return login.rePass(code);
        }
        public bool LoginByCode(string code)
        {
            return login.LoginByCode(code);
        }
    }
}
