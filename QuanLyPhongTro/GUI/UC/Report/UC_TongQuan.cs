using QuanLyPhongTro.BLL;
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
    public partial class UC_TongQuan : UserControl
    {
        BLL_Report bllreport = new BLL_Report();
        public UC_TongQuan()
        {
            InitializeComponent();
            ShowStatusRoom();
            ShowStatusBill();
            ShowChart();
        }
        private void ShowStatusRoom()
        {
            List<int> list = bllreport.getNumberStatusRoom();
            lblSoLuongHopDong.Text = (list[0] + list[1] + list[2]).ToString();
            lblPhongThue.Text = list[0].ToString();
            lblPhongSua.Text = list[1].ToString();
            lblPhongTrong.Text = list[2].ToString();
        }
        private void ShowStatusBill()
        {
            List<int> list = bllreport.getNumberStatusBill();
            lblTotalBill.Text = (list[0] + list[1]).ToString();
            lblPaid.Text = list[0].ToString();
            lblUnPaid.Text = list[1].ToString();

        }
        private void ShowChart()
        {
            ChartDoanhThu chart = new ChartDoanhThu("doanhthutatcaphong");
            panelBG.Controls.Clear();
            panelBG.Controls.Add(chart);
        }
    }
}
