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
        public static string FormatPrice(decimal price){
            var culture = CultureInfo.GetCultureInfo("fr-FR");
            var formattedNumber = string.Format(culture, "{0:n}", price);
            return formattedNumber;
        }

        public static string getPreviousSession()
        {
            DateTime now = DateTime.Now;
            int resultMonth = 0;
            int resultYear = 0;
            if (now.Month == 1)
            {
                resultMonth = 12;
                resultYear = now.Year - 1;
            }
            else
            {
                resultMonth = now.Month - 1;
                resultYear = now.Year;
            }

            return resultMonth.ToString() + "-" + resultYear.ToString();

        }
        public static string headerText()
        {
            return "<!DOCTYPE html>\r\n<html lang=\"vi\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Hóa Đơn Tiền Trọ</title>\r\n    <style>\r\n        body {\r\n            font-family: Arial, sans-serif;\r\n            margin: 20px;\r\n            padding: 20px;\r\n            background-color: #f8f9fa;\r\n        }\r\n        .invoice-container {\r\n            max-width: 600px;\r\n            margin: auto;\r\n            background: #fff;\r\n            padding: 20px;\r\n            border-radius: 8px;\r\n            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);\r\n        }\r\n        .header {\r\n            text-align: center;\r\n            font-size: 20px;\r\n            font-weight: bold;\r\n            margin-bottom: 20px;\r\n        }\r\n        .info {\r\n            margin-bottom: 15px;\r\n        }\r\n        .info p {\r\n            margin: 5px 0;\r\n        }\r\n        .table {\r\n            width: 100%;\r\n            border-collapse: collapse;\r\n        }\r\n        .table th, .table td {\r\n            border: 1px solid #ddd;\r\n            padding: 8px;\r\n            text-align: left;\r\n        }\r\n        .table th {\r\n            background-color: #f2f2f2;\r\n        }\r\n        .total {\r\n            text-align: right;\r\n            font-size: 18px;\r\n            font-weight: bold;\r\n            margin-top: 20px;\r\n        }\r\n    </style>\r\n</head>";
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
