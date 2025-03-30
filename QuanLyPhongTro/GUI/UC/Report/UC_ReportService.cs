using QuanLyPhongTro.GUI.UC.Report.Chart;
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
    public partial class UC_ReportService : UserControl
    {
        public UC_ReportService()
        {
            InitializeComponent();
            ShowChartTongDienNuocTieuThu();
            ShowChartTongDoanhThuDichVuMoiThang();
        }
        private void ShowChartTongDienNuocTieuThu()
        {
            ChartDoanhThu chart = new ChartDoanhThu("TongDienNuocTieuThu");
            PanelBg.Controls.Clear();
            PanelBg.Controls.Add(chart);
        }
        private void ShowChartTongDoanhThuDichVuMoiThang()
        {
            int year = DateTime.Now.Year;
            ChartDoanhThu chart = new ChartDoanhThu("TongDanhThuDichVuMoiThang", year);
            panelBG2.Controls.Clear();
            panelBG2.Controls.Add(chart);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
