using QuanLyPhongTro.BLL;
using QuanLyPhongTro.GUI.Custom;
using QuanLyPhongTro.GUI.Notify;
using QuanLyPhongTro.Handle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro.GUI.Forms
{
    public partial class FormReport : Form
    {
        BLL_Report bllreport = new BLL_Report();    
        public FormReport()
        {
            InitializeComponent();
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            try
            {
                string date1 = dtpDateFrom.Value.ToShortDateString();
                string date2 = dtpDateTo.Value.ToShortDateString();
                decimal TongDoanhThu = 0;
                List<DTO.Bill> list = bllreport.FillBillToDate(date1, date2);

                string content = "Báo Cáo Doanh Thu \n";
                foreach (DTO.Bill b in list)
                {
                    content += string.Format("Mã hóa đơn : {0} | Mã dịch vụ : {1} | Số phòng: {2} | Ngày Lập Hóa Đơn: {3} | Tổng tiền : {4}", b.IdHoaDon, b.IdDichVu, b.SoPhong, b.NgayLapHoaDon, b.TongTien) + "\n";
                    TongDoanhThu += b.TongTien;
                }
                content += "Tổng Doanh Thu: " + TongDoanhThu;

                Handles.ExportTxt(content);
            }
            catch (BusinessException ex)
            {
                Notifi.Show(ex.Message , Notifi.typeNotify.warning);    
            }
        }
    }
}
