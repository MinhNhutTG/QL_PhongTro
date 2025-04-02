using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using QuanLyPhongTro.BLL;
using QuanLyPhongTro.GUI.Notify;
using QuanLyPhongTro.Handle;

namespace QuanLyPhongTro.GUI.UC.Login
{
    public partial class RePass : UserControl
    {
        BLL_Login login = new BLL_Login();


        public RePass()
        {
            InitializeComponent();
           
        }
      
        private void btnBackLoginUC_Click(object sender, EventArgs e)
        {
            UserControl loginUC = new UC.UC_Login();
            this.Controls.Clear();
            this.Controls.Add(loginUC);
        }

       

        private void RePass_Load(object sender, EventArgs e)
        {
            lblNote.Text = "Vui lòng nhập địa chỉ email bạn đã dùng để đăng ký tài khoản." +
                "Chúng tôi sẽ gửi một mã xác thực đến email của bạn." +
                " Vui lòng kiểm tra hộp thư đến (hoặc mục spam nếu không thấy)" +
                " và nhập mã vào ô bên dưới để tiếp tục";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (Handles.IsValidEmail(txtMail.Text)){
                if (login.checkMailUser(txtMail.Text))
                {
                    Notifi.Show("Mã xác nhận đang được gửi", Notifi.typeNotify.success);
                    string mailTo = txtMail.Text;
                    Handles.SendCode(mailTo);
                 
                }
                else
                {
                    Notifi.Show("Email này không được đăng ký", Notifi.typeNotify.error);
                }

            }
            else
            {
                Notifi.Show("Email này không hợp lệ", Notifi.typeNotify.error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (login.LoginByCode(txtCodeRePass.Text))
            {
                Notifi.Show("Đăng nhập thành công", Notifi.typeNotify.success);
                parentForm.Hide();
                Forms.Main frm = new Forms.Main();
                frm.ShowDialog();
            }
            else
            {
                Notifi.Show("Đăng nhập không thành công", Notifi.typeNotify.error);
            }
           
        }
    }
}
