using QuanLyPhongTro.GUI.UC.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongTro.BLL;
using QuanLyPhongTro.GUI.Notify;
using QuanLyPhongTro.GUI.Custom;
using System.Net.Mail;
using System.Net;

namespace QuanLyPhongTro.GUI.UC
{
    public partial class UC_Login : UserControl
    {
        BLL.BLL_Login bllLogin = new BLL_Login();
        public UC_Login()
        {
            InitializeComponent();
        }

       
        private void btnRepass_Click(object sender, EventArgs e)
        {
            UserControl uc = new RePass();
            this.Controls.Clear();
            this.Dock = DockStyle.Fill;
            this.Controls.Add(uc);

           

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Notify.Message.Show("Bạn có muốn đóng ứng dụng?");
            Application.Exit();
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            } 
        }

        private void UC_Login_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                txtUserName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPass.Text)) { 
                txtPass.Focus();
                return;
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                txtPass.Focus();
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter)){
                if (!string.IsNullOrWhiteSpace(txtPass.Text))
                {
                    txtPass.Focus();
                }
              
                btnLogin.PerformClick();
               
            }
        }
        private void resetTextBoxs()
        {
            txtUserName.Clear();
            txtPass.Clear();
            txtUserName.Focus();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Form parentForm = this.FindForm();
                if (bllLogin.checkLogin(txtUserName.Text, txtPass.Text))
                {
                    Notifi.Show("Đăng nhập thành công", Notifi.typeNotify.success);
                    parentForm.Hide();
                    Forms.Main frm = new Forms.Main();
                    frm.ShowDialog();

                }
                else
                {
                    resetTextBoxs();
                    Notifi.Show("Đăng nhập thất bại", Notifi.typeNotify.warning);
                }

            }
            catch (BusinessException ex)
            {
                Notifi.Show("Lỗi nghiệp vụ: "+ex.Message, Notifi.typeNotify.warning);
            }
            catch (Exception ex) {
                Notifi.Show("Lỗi hệ thống: " + ex.Message, Notifi.typeNotify.warning);
            }
        }
    }
}
