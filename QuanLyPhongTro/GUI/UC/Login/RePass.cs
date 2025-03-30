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
       
        string numberRandom = String.Empty;
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

        public string randomCode()
        {
            Random rnd = new Random();
            return   rnd.Next(1000, 9999).ToString();
            
        }
        public void SendCode()
        {
            string code = randomCode();
            string mailTo = txtMail.Text;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("vietnamboardinghouse@gmail.com", "ziau vrck nvyt viem"),
                EnableSsl = true
            };


            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("vietnamboardinghouse@gmail.com"),
                Subject = "Mã xác thực của bạn - Boarding House]",
                Body = "Mã xác nhận của bạn là : " + code,
                IsBodyHtml = true
            };
            mailMessage.To.Add(mailTo);
            client.Send(mailMessage);
            login.RePass(code);
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
                    SendCode();
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
            Notifi.Show("Đăng nhập không thành công", Notifi.typeNotify.error);
        }
    }
}
