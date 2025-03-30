using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongTro.GUI.Notify;
using QuanLyPhongTro.GUI.UC.Config;
using QuanLyPhongTro.GUI.UC.Guest;
using QuanLyPhongTro.GUI.UC.Room;
using QuanLyPhongTro.GUI.UC.Bill;
using QuanLyPhongTro.GUI.UC.Service;
using QuanLyPhongTro.GUI.UC.Report;
using QuanLyPhongTro.GUI.UC;


namespace QuanLyPhongTro.GUI.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            UC_Main uc = new UC_Main();
            PanelMain.Controls.Clear();
            PanelMain.Dock = uc.Dock;
            PanelMain.Controls.Add(uc);
            lblTextTab.Text = "Trang chủ";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult dg = Notify.Message.Show("Bạn có muốn đóng ứng dụng?");
            if (dg == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dg =  Notify.Message.Show("Bạn có muốn thoát ứng dụng?");
            if (dg == DialogResult.Yes) { 
                Application.Exit();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            UC_Config uc = new UC_Config();
            PanelMain.Controls.Clear();
            PanelMain.Dock = uc.Dock;
            PanelMain.Controls.Add(uc);
            lblTextTab.Text = "Cấu hình";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UC_Rooms uc = new UC_Rooms();  
            PanelMain.Controls.Clear();
            PanelMain.Dock = uc.Dock;
            PanelMain.Controls.Add(uc);
            lblTextTab.Text = "Quản lý phòng";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UC_Guest uc = new UC_Guest();
            PanelMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            PanelMain.Controls.Add(uc);
            lblTextTab.Text = "Quản lý khách thuê";
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            UC_Bill uc = new UC_Bill();
            PanelMain.Controls.Clear();
            PanelMain.Dock = uc.Dock;
            PanelMain.Controls.Add(uc);
            lblTextTab.Text = "Quản lý hóa đơn";
        }

        private void btnService_Click(object sender, EventArgs e)
        {
           UC_Service uc = new UC_Service();
            PanelMain.Controls.Clear();
            PanelMain.Dock = uc.Dock;
            PanelMain.Controls.Add(uc);
            lblTextTab.Text = "Quản lý dịch vụ";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UC_Report uc = new UC_Report();
            PanelMain.Controls.Clear();
            PanelMain.Dock = uc.Dock;
            PanelMain.Controls.Add(uc);
            lblTextTab.Text = "Quản lý báo cáo thống kê";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UC_Contract uc = new UC_Contract();
            PanelMain.Controls.Clear();
            PanelMain.Dock = uc.Dock;
            PanelMain.Controls.Add(uc);
            lblTextTab.Text = "Quản lý hợp đồng";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UC_Main uc = new UC_Main();
            PanelMain.Controls.Clear();
            PanelMain.Dock = uc.Dock;
            PanelMain.Controls.Add(uc);
            lblTextTab.Text = "Trang chủ";
        }
    }
}
