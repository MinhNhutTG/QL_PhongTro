using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongTro.BLL;
using QuanLyPhongTro.DTO;
using QuanLyPhongTro.GUI;
using QuanLyPhongTro.GUI.Forms;
using QuanLyPhongTro.GUI.Notify;
using QuanLyPhongTro.Handle;

namespace QuanLyPhongTro.GUI.UC.Bill
{
    public partial class UC_Bill : UserControl
    {
        BLL_Rooms bllroom = new BLL_Rooms();
        BLL_RoomService bllhistoryservice = new BLL_RoomService();
        BLL_Bill bllBill = new BLL_Bill();
        BLL_Contract bllcontract = new BLL_Contract();
        public UC_Bill()
        {
            InitializeComponent();
            Loadbills(bllBill.getListBill());
        }
        public void Loadbills(List<DTO.Bill> list)
        {

            lsvHoaDon.Items.Clear();
            foreach (DTO.Bill bill in list) { 
                ListViewItem lvi = new ListViewItem(bill.IdHoaDon);
      
                lvi.SubItems.Add(bill.IdDichVu.ToString());
                lvi.SubItems.Add(bill.SoPhong);
                lvi.SubItems.Add(string.Format("{0:n0}", bill.SoDien));
                lvi.SubItems.Add(string.Format("{0:n0}", bill.TienDien));
                lvi.SubItems.Add(string.Format("{0:n0}", bill.SoNuoc));
                lvi.SubItems.Add(string.Format("{0:n0}", bill.TienNuoc));
                lvi.SubItems.Add(string.Format("{0:n0}", bill.PhiKhac));
                lvi.SubItems.Add(string.Format("{0:n0}", bill.TongTien));
                lvi.SubItems.Add(bill.TrangThai);
                lvi.SubItems.Add(string.Format("{0:n0}", bill.GiaPhong));
                lvi.SubItems.Add(bill.NgayLapHoaDon.ToString());
                lvi.SubItems.Add(bill.GhiChu);
                if (bill.TrangThai == "Đã Thanh Toán")
                {
                    lvi.BackColor = ColorTranslator.FromHtml("#89AC46");
                    lvi.ForeColor = Color.White;
                }
                else if (bill.TrangThai == "Chưa Thanh Toán")
                {
                    lvi.BackColor = ColorTranslator.FromHtml("#E52020");
                    lvi.ForeColor = Color.White;
                }

                lsvHoaDon.Items.Add(lvi);
            }
        }
        private void Reload()
        {
            Loadbills(bllBill.getListBill());
        }
     

        private void btnAddBill_Click_1(object sender, EventArgs e)
        {
            Forms.Bill frm = new Forms.Bill();
            frm.ReloadEvent += Reload;
            frm.Show();
        }

        private void btnRemoveBill_Click(object sender, EventArgs e)
        {
            if (lsvHoaDon.SelectedItems.Count > 0) {
      
                if (bllBill.DeleteBill(lsvHoaDon.SelectedItems[0].Text))
                {
                    Notifi.Show("Xóa hóa đơn thành công", Notifi.typeNotify.success);
                    Reload();
                }
                else
                {
                    Notifi.Show("Xóa hóa đơn không thành công", Notifi.typeNotify.error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lsvHoaDon.SelectedItems.Count > 0)
            {
                Forms.Bill frm = new Forms.Bill(lsvHoaDon.SelectedItems[0].Text);
                frm.ReloadEvent += Reload;
                frm.Show();
            }
            else
            {
                Notifi.Show("Vui lòng chọn hóa đơn để chỉnh sửa",Notifi.typeNotify.error);
            }
           
        }
        private string changeID(string idroom)
        {
            string id = "";
            int count = 0;
            do
            {
                DateTime dt = DateTime.Now;
                id = "HD";
                id += dt.Day.ToString() + dt.Month.ToString();
                id += idroom;

                if (count == 2)
                {
                    Random rnd = new Random();
                    id += rnd.Next(1, 100).ToString();
                }

                count++;

            }
            while (bllBill.ExistBill(id.ToString()));

            return id;
        }

        private void btnAddBillAuto_Click(object sender, EventArgs e)
        {
            List<RoomService> lisths = bllhistoryservice.GetPendingServiceHistory();
            Thread thr = new Thread(() =>
            {
                foreach (RoomService hs  in lisths)
                {
              
                    DTO.Room r = bllroom.FindRoomByID(Convert.ToInt32(hs.SoPhong));
                    DTO.Bill bill = new DTO.Bill();
                   
                    decimal price = bllcontract.FindContractByIDRoom(hs.SoPhong);
                   
                    bill.IdHoaDon = changeID(hs.SoPhong);
                    bill.IdDichVu = hs.ID;
                    bill.SoPhong = hs.SoPhong;
                 
                    bill.SoDien = hs.SoDienMoi - hs.SoDienCu;
                    bill.TienDien = bill.SoDien * hs.GiaDien;
                    bill.SoNuoc = hs.SoNuocMoi - hs.SoNuocCu;
                    bill.TienNuoc = bill.SoNuoc * hs.GiaNuoc;
                    bill.PhiKhac = 0;
                    bill.GiaPhong = price;
                    bill.TongTien = price + bill.TienNuoc + bill.TienDien + hs.TienMang + bill.PhiKhac;
                    bill.NgayLapHoaDon = DateTime.Now;
                    bill.TrangThai = "Chưa Thanh Toán";
                    bill.GhiChu = "";
                    if (bllBill.AddBill(bill))
                    {
                        bllhistoryservice.UpdateStatus("Đã Lập Hóa Đơn", bill.IdDichVu.ToString());
                    }
                   
                 

                }

                this.Invoke(new Action(() =>
                {
                    Notifi.Show("Tạo hóa đơn thành công", Notifi.typeNotify.success);
                    Reload(); 
                }));

            });
            thr.Start();
            Reload();
        }

        private void UC_Bill_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(btnSearch.Text))
                {
                    List<DTO.Bill> listBill = bllBill.FillBillByKey(txtSearch.Text);
                    if (listBill.Count <=0 ) {
                        Notifi.Show("Kết quả tìm kiếm không có", Notifi.typeNotify.error);
                    }
                    else
                    {
                        Loadbills(listBill);
                    }
                   
                }
                else
                {
                    Reload();
                }
            }
            catch { 
                Notifi.Show("Kết quả tìm kiếm không có",Notifi.typeNotify.error);
            }
         

          
        }
       

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (lsvHoaDon.SelectedItems.Count > 0) {
                BillDetail frm = new BillDetail(lsvHoaDon.SelectedItems[0].Text);
                frm.Show();
            }
            else
            {
                Notifi.Show("Chọn hóa đơn để xem chi tiết",Notifi.typeNotify.error);
            }
            
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            List<DTO.Bill> list = bllBill.FillBillByDate(dtpDate.Value);
            Loadbills(list);
        }

        private void rdpUnpaid_Click(object sender, EventArgs e)
        {

            if (rdbPaid.Checked)
            {
                Loadbills(bllBill.FillBillPaid("Đã Thanh Toán"));
            }
            else if (rdbUnpaid.Checked) {
                Loadbills(bllBill.FillBillPaid("Chưa Thanh Toán"));
            }
        }

        private void btnChangeId_Click(object sender, EventArgs e)
        {
            Reload();
        }
    }
}
