using QuanLyPhongTro.GUI.Notify;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using QuanLyPhongTro.BLL;
using System.Net.Http;

namespace QuanLyPhongTro.Handle
{
    internal class Handles
    {
        string numberRandom = String.Empty;
        static BLL_Login  login = new BLL_Login();
        public static string randomCode()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 9999).ToString();

        }
        public static void SendCode(string mailTo)
        {
            string code = randomCode();

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
        public static void SendEmail(string htmlContent , string mailto)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("vietnamboardinghouse@gmail.com", "ziau vrck nvyt viem"),
                EnableSsl = true
            };


            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("vietnamboardinghouse@gmail.com"),
                Subject = "Hóa Đơn Boarding House]",
                Body = htmlContent,
                IsBodyHtml = true
            };
            mailMessage.To.Add(mailto);
            client.Send(mailMessage);
        }
        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }


        public static void ExportTxt(string content)
        {
            try
            {
               
                string basepath = AppDomain.CurrentDomain.BaseDirectory + @"FILE BAO CAO";
                string path = Path.Combine(basepath, "BaoCaoDoanhThu.txt");
                if (File.Exists(path))
                {
                   
                    File.AppendAllText(path, "\n \n \n" + content);
                }
                else
                {
                    
                    File.WriteAllText(path, content);
                }
                Notifi.Show("Xuất file thành công", Notifi.typeNotify.success);
            }
            catch (Exception ex)
            {
                Notifi.Show(ex.Message, Notifi.typeNotify.warning);

            }


        }

    }
}
