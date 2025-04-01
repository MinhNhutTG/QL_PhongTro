using QuanLyPhongTro.GUI.Notify;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.Handle
{
    internal class Handles
    {
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
<<<<<<< HEAD


=======
    
      
>>>>>>> 6c54cd9786a78dcf1a8312d4adc94c76ff3296c8
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
