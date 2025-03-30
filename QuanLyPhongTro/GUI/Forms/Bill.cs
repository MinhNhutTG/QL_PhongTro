using QuanLyPhongTro.BLL;
using QuanLyPhongTro.DTO;
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
    public partial class Bill : Form
    {
        BLL_Bill bllbill = new BLL_Bill();
        BLL_Rooms bllroom = new BLL_Rooms();
        BLL_RoomService bllhistoryservice = new BLL_RoomService();
        BLL_Contract bllcontract = new BLL_Contract();
        public delegate void ReLoad();
        public event ReLoad ReloadEvent;
        public Bill()
        {
            InitializeComponent();
            setup();
        }
        public Bill(string mahd)
        {
            InitializeComponent();
            showBill(mahd);
            pictureBox1.Click -= pictureBox1_Click;
            pictureBox1.Click += pictureBox1_ClickNoneObject;
        }
        public void showBill(string mahd)
        {
            DTO.Bill bill = bllbill.FindBillByID(mahd);
            DTO.RoomService hs = bllhistoryservice.getHistoryServiceByID(bill.IdDichVu??0);
            txtMaHoaDon.Text = bill.IdHoaDon.ToString();
            txtmals.Text = bill.IdDichVu.ToString();
            cbbPhong.Text = bill.SoPhong.ToString();
            lblSoDien.Text = bill.SoDien.ToString();
            txtTienDien.Text =   string.Format("{0:n0}", bill.TienDien);
            lblSoNuoc.Text = bill.SoNuoc.ToString();
            txtTienNuoc.Text =  string.Format("{0:n0}", bill.TienNuoc); 
            txtTienKhac.Text =  string.Format("{0:n0}", bill.PhiKhac);;
            lblTongTien.Text = string.Format("{0:n0}", bill.TongTien);
            dtpNgayLap.Text = bill.NgayLapHoaDon.ToString();
            cbbTrangThai.Text = bill.TrangThai;
            rtbGhiChu.Text = bill.GhiChu;
            txtGiaPhong.Text = string.Format("{0:n0}", bill.GiaPhong);
            txtTienMang.Text =  string.Format("{0:n0}", hs.TienMang);

        }
        private void setup()
        {
            rdbType1.Checked = true;
            cbbTrangThai.SelectedIndex = 0;
            changeID();
            ShowComboBoxRoom();
            
        }
        private void ShowComboBoxRoom()
        {
            List<string > roomList  = bllroom.getListRoomID();
            foreach (string room in roomList) { 
                cbbPhong.Items.Add(room);
            }
            cbbPhong.SelectedIndex = -1;
        }
        
        private void changeID()
        {
            string id = "";
            int count = 0;
            do
            {
                DateTime dt = DateTime.Now;
                id = "HD";
                id += dt.Day.ToString() + dt.Month.ToString();
                id += cbbPhong.SelectedItem;
               
                if (count == 2)
                {
                    Random rnd = new Random();
                    id += rnd.Next(1, 100).ToString();
                }
               
                count++;

            }
            while (bllbill.ExistBill(id.ToString()));

            txtMaHoaDon.Text = id.ToString();
        }
      


        private void cbbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeID();
            ShowListView();
            showDetailRoom(cbbPhong.SelectedItem.ToString());
        }
        private void showDetailRoom(string id)
        {
            decimal price =bllcontract.FindContractByIDRoom(id);
            Room room = bllroom.FindRoomByID(Convert.ToInt32(id));
            lblLoaiPhong.Text = room.TenLoai.ToString();
            txtGiaPhong.Text = string.Format("{0:n0}", price);
        }
        private void btnChangeId_Click(object sender, EventArgs e)
        {
            changeID();
        }
        private void ShowListView()
        {
            lsvService.Items.Clear();
            List<DTO.RoomService> list = bllhistoryservice.GetListHistoryServiceByID(Convert.ToInt32(cbbPhong.SelectedItem.ToString()));
            foreach (DTO.RoomService hs in list)
            {
                ListViewItem item = new ListViewItem(hs.ID.ToString());
                item.SubItems.Add(hs.Ki);
                item.SubItems.Add(hs.NgayTao.ToShortDateString());
                lsvService.Items.Add(item);
            }
        }

        private void lsvService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvService.SelectedItems.Count > 0)
            {
                DTO.RoomService hs = bllhistoryservice.getHistoryServiceByID(Convert.ToInt32(lsvService.SelectedItems[0].Text));
                txtmals.Text = hs.ID.ToString();
                
                lblSoDien.Text = (hs.SoDienMoi - hs.SoDienCu).ToString();
                txtTienDien.Text = string.Format("{0:n0}", ((hs.SoDienMoi - hs.SoDienCu) * hs.GiaDien));

                lblSoNuoc.Text = (hs.SoNuocMoi - hs.SoNuocCu).ToString();
                txtTienNuoc.Text = string.Format("{0:n0}", ((hs.SoNuocMoi - hs.SoNuocCu) * hs.GiaNuoc));

                txtTienMang.Text = string.Format("{0:n0}",hs.TienMang);

                CaculatorResutl(hs);
            }
        }
        private void CaculatorResutl(RoomService hs)
        {       
                decimal tienphong = Convert.ToDecimal(txtGiaPhong.Text);
                decimal phikhac = Convert.ToDecimal(txtTienKhac.Text);
                decimal tongtien = ((hs.SoDienMoi - hs.SoDienCu) * hs.GiaDien) + ((hs.SoNuocMoi - hs.SoNuocCu) * hs.GiaNuoc) + hs.TienMang + tienphong + phikhac;
                lblTongTien.Text = string.Format("{0:n0}", tongtien);
        }
        private void CaculatorBillOther()
        {
            decimal phikhac = Convert.ToDecimal(txtTienKhac.Text);
            lblTongTien.Text = string.Format("{0:n0}",phikhac);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (rdbType1.Checked)
            {
                if (lsvService.SelectedItems.Count > 0)
                {
                    DTO.RoomService hs = bllhistoryservice.getHistoryServiceByID(Convert.ToInt32(lsvService.SelectedItems[0].Text));
                    CaculatorResutl(hs);
                }
            }
            else  if (rdbType2.Checked)
            {
                CaculatorBillOther();
            }
           
           
        }
        private void pictureBox1_ClickNoneObject(object sender, EventArgs e)
        {

            decimal tienPhong = Convert.ToDecimal(txtGiaPhong.Text);
            decimal phiKhac = Convert.ToDecimal(txtTienKhac.Text);
            decimal tienDien = Convert.ToDecimal(txtTienDien.Text);
            decimal tienNuoc = Convert.ToDecimal(txtTienNuoc.Text);
            decimal tienMang = Convert.ToDecimal(txtTienMang.Text);
            decimal tongTien = tienPhong + phiKhac + tienDien + tienNuoc + tienMang ;
            lblTongTien.Text = string.Format("{0:n0}", tongTien);
        }

        public DTO.Bill GetBillInput()
        {

            DTO.Bill bill = new DTO.Bill();
            bill.IdHoaDon = txtMaHoaDon.Text;
            bill.IdDichVu = Convert.ToInt32(txtmals.Text);
            bill.SoPhong = cbbPhong.Text;
            bill.SoDien = Convert.ToInt32(lblSoDien.Text);
          
            bill.TienDien = Convert.ToDecimal(txtTienDien.Text);
            bill.SoNuoc = Convert.ToInt32(lblSoNuoc.Text);
            bill.TienNuoc = Convert.ToDecimal(txtTienNuoc.Text);
            bill.PhiKhac = Convert.ToDecimal(txtTienKhac.Text);
            bill.TongTien = Convert.ToDecimal(lblTongTien.Text);
            bill.NgayLapHoaDon = Convert.ToDateTime(dtpNgayLap.Text);
            bill.TrangThai = cbbTrangThai.SelectedItem.ToString();
            bill.GhiChu = rtbGhiChu.Text;
            bill.GiaPhong = Convert.ToDecimal(txtGiaPhong.Text); 
            return bill;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bllbill.ExistBill(txtMaHoaDon.Text))
                {
                    DTO.Bill bill = GetBillInput();
                    if (bllbill.AddBill(bill))
                    {
                        bllhistoryservice.UpdateStatus("Đã Lập Hóa Đơn", bill.IdDichVu.ToString());
                        Notifi.Show("Tạo hóa đơn thành công", Notifi.typeNotify.success);
                        ReloadEvent?.Invoke();
                    }
                    else
                    {
                        Notifi.Show("Tạo hóa đơn không thành công", Notifi.typeNotify.error);
                    }
                }
                else
                {
                    if (bllbill.UpdateBill(GetBillInput()))
                    {
                        Notifi.Show("Cập nhật hóa đơn thành công", Notifi.typeNotify.success);
                        ReloadEvent?.Invoke();
                    }
                    else
                    {
                        Notifi.Show("Cập nhật hóa đơn không thành công", Notifi.typeNotify.error);
                    }
                }
                this.Close();
            }
            catch (BusinessException ex)
            {
                Notifi.Show("Lỗi nghiệp vụ: " + ex.Message, Notifi.typeNotify.warning);
            }
            catch (Exception ex)
            {
                Notifi.Show("Lỗi lỗi hệ thống: " + ex.Message, Notifi.typeNotify.warning);
            }
        }

        private void rdbType2_CheckedChanged(object sender, EventArgs e)
        {
            txtGiaPhong.Text = "0";
        }
    }
}
