using QuanLyPhongTro.BLL;
using QuanLyPhongTro.DTO;
using QuanLyPhongTro.GUI.Custom;
using QuanLyPhongTro.GUI.Notify;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro.GUI.UC.Config
{
    public partial class UC_Account : UserControl
    {
        BLL_Config bll = new BLL_Config();  
        public UC_Account()
        {
            InitializeComponent();
            LoadAccount();
        }

        private void btnLuuBanking_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.UserName = txtUserName.Text;
            account.Password = txtPassword.Text;
            account.EmailUser = txtEmail.Text;
            try
            {
                if (bll.editAccount(account))
                {
                    LoadAccount();
                    Notifi.Show("Cập nhật thông tin thành công", Notifi.typeNotify.success);
                }
                else
                {
                    Notifi.Show("Cập nhật thông tin không thành công", Notifi.typeNotify.error);
                }
            }
            catch (BusinessException ex)
            {
                Notifi.Show("Lỗi nghiệp vụ: " + ex.Message, Notifi.typeNotify.warning);
            }
            catch (Exception ex)
            {
                Notifi.Show("Lỗi hệ thống: " + ex.Message, Notifi.typeNotify.warning);
            }
        }
        public void LoadAccount()
        {
            Account acc = bll.getAccount();
            txtUserName.Text = acc.UserName;
            txtPassword.Text = acc.Password;
            txtEmail.Text = acc.EmailUser;

        }

        private void UC_Account_Load(object sender, EventArgs e)
        {

        }
    }
}
