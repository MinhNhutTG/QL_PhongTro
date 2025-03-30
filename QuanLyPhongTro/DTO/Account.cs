using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.DTO
{
    internal class Account
    {
        private string userName;
        private string password;
        private string emailUser;
        public Account() { }

        public string UserName { get { return userName; } set { userName = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string EmailUser { get { return emailUser; } set { emailUser = value; } }
    }
}
