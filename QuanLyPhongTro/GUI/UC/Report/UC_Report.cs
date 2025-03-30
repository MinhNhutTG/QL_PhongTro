using QuanLyPhongTro.GUI.UC.Report.Chart;
using QuanLyPhongTro.GUI.UC.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro.GUI.UC.Report
{
    public partial class UC_Report : UserControl
    {
        public UC_Report()
        {
            InitializeComponent();
            UC_TongQuan uc = new UC_TongQuan();
            panelMain.Controls.Add(uc);
        }

      

       
       
        private void btnHopDong_Click(object sender, EventArgs e)
        {
            UC_ReportContract uc = new UC_ReportContract();
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uc);
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            UC_ReportService uc = new UC_ReportService();
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uc);
        }

        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            UC_TongQuan uc = new UC_TongQuan();
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uc);
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            UC_Revenue uc = new UC_Revenue();
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uc);
        }
    }
}
