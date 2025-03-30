using QuanLyPhongTro.BLL;
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
    public partial class UC_ReportContract : UserControl
    {
        BLL_Report bllreport = new BLL_Report();
        public UC_ReportContract()
        {
            InitializeComponent();
            loadData();
        }
        void loadData()
        {
            int numHopDong = bllreport.TKTongSoHopDong();
            int numHopDongConHan = bllreport.TKHopDongConHan();
            int numHopDongMoiTrongThang = bllreport.TKHopDongMoiTrongThang();
            lblSoLuongHopDong.Text = numHopDong.ToString();
            lblHopDongConHan.Text = numHopDongConHan.ToString();
            lblHopDongMoiTrongThang.Text = numHopDongMoiTrongThang.ToString();
        }
    }
}
