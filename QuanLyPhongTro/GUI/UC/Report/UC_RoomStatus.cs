using QuanLyPhongTro.BLL;
using QuanLyPhongTro.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyPhongTro.GUI.UC.Report
{
    public partial class UC_RoomStatus : UserControl
    {
        BLL_Report bllreport = new BLL_Report();
        public UC_RoomStatus()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            DataTable dt = bllreport.TKSoLuongTinhTrangPhong();

            if (dt == null || dt.Rows.Count == 0)
            {

                Notify.Message.Show("Không có dữ liệu của phòng này ");
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                string trangThai = row["TrangThai"].ToString();
                int soLuong = Convert.ToInt32(row["so_luong"]);

                if (trangThai == "Trống")
                    lblSoLuongPhongTrong.Text = soLuong.ToString();
                else if (trangThai == "Đang thuê")
                    lblSoLuongPhongThue.Text = soLuong.ToString();
                else if (trangThai == "Đang sửa chữa")
                    lblSoLuongPhongSua.Text = soLuong.ToString();
            }



        }
    }
}
