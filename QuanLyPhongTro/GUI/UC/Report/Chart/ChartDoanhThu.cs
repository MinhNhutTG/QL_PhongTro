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

namespace QuanLyPhongTro.GUI.UC.Report.Chart
{
    public partial class ChartDoanhThu : UserControl
    {
        BLL_Report bllreport = new BLL_Report();
        public ChartDoanhThu(string option, int year)
        {
            InitializeComponent();
            if (option == "thang")
            {
                LoadThang(year);
            }
            else if (option == "quy")
            {
                LoadQuy(year);
            }
            else if (option == "TongDanhThuDichVuMoiThang")
            {
                LoadDoanhThuDichVuMoiThang(year);
            }

        }
        public ChartDoanhThu(string option)
        {
            InitializeComponent();
            if (option == "doanhthutatcaphong")
            {
                LoadTKTatCaPhong();
            }
            else if (option == "TongDienNuocTieuThu")
            {
                LoadTongDienNuocTieuThu();
            }
           
           
           
        }
        public ChartDoanhThu(string option,string idRoom)
        {
            InitializeComponent();
            if (option == "doanhthuphong")
            {
                 LoadTKPhong(idRoom);
            }
        }
        void LoadDoanhThuDichVuMoiThang(int year)
        {
            DataTable dtDien = bllreport.TongTienDienMoiThang(year);
            DataTable dtNuoc = bllreport.TongTienNuocMoiThang(year);
            DataTable dtMang = bllreport.TongTienMangMoiThang(year);
            DataTable dtTongTien = bllreport.TongDoanhThuDichVuMoiThang(year);

            if (dtDien == null || dtDien.Rows.Count == 0 && dtNuoc == null || dtNuoc.Rows.Count == 0 && dtMang == null || dtMang.Rows.Count == 0 && dtTongTien.Rows.Count == 0 && dtTongTien == null)
            {
                Notify.Message.Show("Không có dữ liệu ");
                return;
            }

            chart1.Series.Clear();
            Series series = new Series("Doanh thu điện tiêu thụ mỗi tháng")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };
            Series series2 = new Series("Doanh thu nước tiêu thụ mỗi tháng ")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };
            Series series3 = new Series("Doanh thu mạng tiêu thụ mỗi tháng ")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };
            Series series4 = new Series("Doanh thu các dịch vụ tiêu thụ mỗi tháng ")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            foreach (DataRow row in dtDien.Rows)
            {
                string ki = row["Ki"].ToString();
                string tong = row["TongTienDien"].ToString();
                series.Points.AddXY(ki, tong);
            }
            foreach (DataRow row in dtNuoc.Rows)
            {
                string ki = row["Ki"].ToString();
                string tong = row["TongTienNuoc"].ToString();
                series2.Points.AddXY(ki, tong);
            }
            foreach (DataRow row in dtMang.Rows)
            {
                string ki = row["Ki"].ToString();
                string tong = row["TongTienMang"].ToString();
                series3.Points.AddXY(ki, tong);
            }
            foreach (DataRow row in dtTongTien.Rows)
            {
                string ki = row["Ki"].ToString();
                string tong = row["TongDoanhThu"].ToString();
                series4.Points.AddXY(ki, tong);
            }

            chart1.Series.Add(series);
            chart1.Series.Add(series2);
            chart1.Series.Add(series3);
            chart1.Series.Add(series4);

        }
        void LoadTongDienNuocTieuThu()
        {
            DataTable dtDien = bllreport.TKTongTienDienTieuThu();
            DataTable dtNuoc = bllreport.TKTongTienNuocTieuThu();

            if (dtDien == null || dtDien.Rows.Count == 0 && dtNuoc == null || dtNuoc.Rows.Count == 0)
            {

                Notify.Message.Show("Không có dữ liệu ");
                return;
            }

            chart1.Series.Clear();
            Series series = new Series("Tổng điện tiêu thụ " )
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };
            Series series2 = new Series("Tổng nước tiêu thụ ")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            foreach (DataRow row in dtDien.Rows)
            {
                string ki = row["Ki"].ToString();
                string tong = row["TongDienTieuThu"].ToString();
                series.Points.AddXY(ki, tong);
            }
            foreach (DataRow row in dtNuoc.Rows)
            {
                string ki = row["Ki"].ToString();
                string tong = row["TongDienTieuThu"].ToString();
                series2.Points.AddXY(ki, tong);
            }

            chart1.Series.Add(series);
            chart1.Series.Add(series2);

        }
        void LoadTKPhong(string idRoom)
        {
            DataTable dt = bllreport.TKDoanhThuPhong(idRoom);

            if (dt == null || dt.Rows.Count == 0)
            {

                Notify.Message.Show("Không có dữ liệu của phòng này ");
                return;
            }

            chart1.Series.Clear();
            Series series = new Series("Tổng doanh thu của phòng : "+ idRoom)
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            foreach (DataRow row in dt.Rows)
            {
                string soPhong = row["SoPhong"].ToString();
                string doanhThu = string.Format("{0:n0}", row["TongDoanhThu"]);
                series.Points.AddXY(soPhong, doanhThu);
            }

            chart1.Series.Add(series);
            chart1.Invalidate();
        }

        void LoadTKTatCaPhong()
        {
            DataTable dt = bllreport.TKDoanhThuCacPhong();

            if (dt == null || dt.Rows.Count == 0)
            {

                Notify.Message.Show("Không có dữ liệu của các phòng này " );
                return;
            }

            chart1.Series.Clear();
            Series series = new Series("Tổng doanh thu của mỗi phòng")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            foreach (DataRow row in dt.Rows)
            {
                string soPhong = row["SoPhong"].ToString();
                string doanhThu = string.Format("{0:n0}", row["TongDoanhThuTienPhong"]);
                series.Points.AddXY(soPhong, doanhThu);
            }

            chart1.Series.Add(series);
            chart1.Invalidate();
        }

        void LoadQuy(int year)
        {
            DataTable dt = bllreport.TKDoanhThuQuy(year);

            if (dt == null || dt.Rows.Count == 0)
            {
             
               
                return;
            }

            chart1.Series.Clear(); 
            Series series = new Series("Doanh Thu Quý")
            {
                ChartType = SeriesChartType.Column, 
                IsValueShownAsLabel = true 
            };

            foreach (DataRow row in dt.Rows)
            {
                string thang = row["Quy"].ToString();
                string doanhThu = string.Format("{0:n0}", row["TongDoanhThu"]);
                series.Points.AddXY(thang, doanhThu);
            }

            chart1.Series.Add(series);
            chart1.Invalidate();
        }
       
        private void LoadThang(int year)
        {
            DataTable dt = bllreport.TKDoanhThuThang(year); // Lấy dữ liệu từ database

            if (dt == null || dt.Rows.Count == 0)
            {
                return;
            }

            chart1.Series.Clear(); // Xóa Series cũ

            Series series = new Series("Doanh Thu Tháng")
            {
                ChartType = SeriesChartType.Column, // Biểu đồ cột
                IsValueShownAsLabel = true // Hiển thị giá trị trên cột
            };

            foreach (DataRow row in dt.Rows)
            {
                string thang = row["Thang"].ToString(); 
                string doanhThu = string.Format("{0:n0}",row["TongDoanhThu"]); 
                series.Points.AddXY(thang, doanhThu); 
            }

            chart1.Series.Add(series); 
           
        }

        private void ChartDoanhThu_Load(object sender, EventArgs e)
        {
           
        }
    }

    // Class chứa dữ liệu
    public class DataPoint
    {
        public string Label { get; set; }
        public string  Value { get; set; }

        public DataPoint(string label, string value)
        {
            Label = label;
            Value = value;
        }
    }
}

