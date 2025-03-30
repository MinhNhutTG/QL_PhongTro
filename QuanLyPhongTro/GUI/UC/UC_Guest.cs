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
using QuanLyPhongTro.DTO;
using QuanLyPhongTro.GUI.Notify;
using QuanLyPhongTro.GUI.Custom;

namespace QuanLyPhongTro.GUI.UC.Guest
{
    public partial class UC_Guest : UserControl
    {
        BLL_Guest bllGuest = new BLL_Guest();
        BLL_Contract bllContract = new BLL_Contract();

        public UC_Guest()
        {
            InitializeComponent();
            cbbStatus.SelectedIndex = 0;
            LoadGuests();
            cbbTrangThai.SelectedIndex = 0;
        }
        public void LoadGuests()
        {
            List<DTO.Guest> guests = bllGuest.getListGuest();    
            lsvGuest.Items.Clear();
            foreach(DTO.Guest g in guests)
            {
                ListViewItem lvi = new ListViewItem(g.MaKhach.ToString());
                lvi.SubItems.Add(g.HoTen);
                lvi.SubItems.Add(g.NgaySinh.ToShortDateString());
                lvi.SubItems.Add(g.CCCD);
                lvi.SubItems.Add(g.SoDienThoai);
                lvi.SubItems.Add(g.QueQuan);
                lvi.SubItems.Add(g.TrangThai);
                lvi.SubItems.Add(g.Email);
                if (g.TrangThai == "Chưa Thuê")
                {
                    lvi.BackColor = ColorTranslator.FromHtml("#EFEFEF");
                    lvi.ForeColor = Color.White;
                }
                else if (g.TrangThai == "Đang Thuê")
                {
                    lvi.BackColor = ColorTranslator.FromHtml("#89AC46");
                    lvi.ForeColor = Color.White;
                }
                else if (g.TrangThai == "Đã Kết Thúc Hợp Đồng")
                {
                    lvi.BackColor = ColorTranslator.FromHtml("#BF3131");
                    lvi.ForeColor = Color.White;
                }
                lsvGuest.Items.Add(lvi);
            }
        }
        private DTO.Guest getInfor()
        {
            DTO.Guest guest = new DTO.Guest();
            guest.MaKhach = Convert.ToInt32(txtMaKhach.Text);
            guest.HoTen = txtHoTen.Text;
            guest.NgaySinh = Convert.ToDateTime(dtpNgaySinh.Text);

            guest.CCCD = txtCCCD.Text;
            guest.SoDienThoai = txtSoDienThoai.Text;
            guest.QueQuan = txtQueQuan.Text;
            guest.TrangThai = cbbTrangThai.Text;
            guest.Email = txtEmail.Text;

            return guest;
        }




        private void lsvGuest_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lsvGuest.SelectedItems.Count > 0)
                {
                    txtMaKhach.Visible = true;
                    DTO.Guest g = bllGuest.FindGuestByID(Convert.ToInt32(lsvGuest.SelectedItems[0].Text));

                    DTO.Contract contract = bllContract.FindContractByIDContract(bllContract.getIDContractByIDGuest(g.MaKhach));
                    txtMaKhach.Text = g.MaKhach.ToString();
                    txtHoTen.Text = g.HoTen;
                    dtpNgaySinh.Text = g.NgaySinh.ToString();
                    txtCCCD.Text = g.CCCD.ToString();
                    txtSoDienThoai.Text = g.SoDienThoai.ToString();
                    txtQueQuan.Text = g.QueQuan.ToString();
                    cbbTrangThai.Text = g.TrangThai.ToString();
                    txtEmail.Text = g.Email.ToString();

                    if (!string.IsNullOrEmpty(contract.Id))
                    {
                        lblMaHopDong.Text = contract.Id.ToString();
                        lblSoPhong.Text = contract.SoPhong.ToString();
                        ShowDetailContract(contract.Id);
                    }
                    txtMaKhach.Enabled = false;


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
       

        // CRUD  - RESET FORM
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!bllGuest.ExistGuest(Convert.ToInt32(txtMaKhach.Text)))
                {
                   
                    if (bllGuest.AddGuest(getInfor()))
                    {
                        Notify.Notifi.Show("Thêm thành công", Notifi.typeNotify.success);
                        LoadGuests();
                    }
                    else
                    {
                        Notify.Notifi.Show("Thêm không thành công", Notifi.typeNotify.warning);
                    }
                }
                else
                {
                    Notify.Notifi.Show("Mã khách đã tồn tại", Notifi.typeNotify.warning);
                }
             
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {   
                if (lsvGuest.SelectedItems.Count > 0)
                {
                    int idGuest = Convert.ToInt32(lsvGuest.SelectedItems[0].Text);
                
                  
                  
                    if (bllGuest.RemoveGuest(idGuest))
                    {
                        Notify.Notifi.Show("Xóa thành công", Notifi.typeNotify.success);
                        LoadGuests();
                        Reload();
                        
                    }
                    else
                    {
                        Notify.Notifi.Show("Xóa không thành công", Notifi.typeNotify.warning);
                    }
                }
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

        private void ShowDetailContract(string idhd)
        {
            lsvDetailGuest.Items.Clear();
            List<DetailContract> detailContracts = bllContract.GetDetailContractList(idhd);
            foreach (DetailContract dtctr in detailContracts)
            {
                ListViewItem item = new ListViewItem(dtctr.MaKhach.ToString());
                string name = bllGuest.getGuestName(dtctr.MaKhach);
                item.SubItems.Add(name);
                item.SubItems.Add(dtctr.VaiTro);
                lsvDetailGuest.Items.Add(item);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllGuest.Update(getInfor()))
                {
                    Notify.Notifi.Show("Cập nhật thành công", Notifi.typeNotify.success);
                    LoadGuests();
                }
                else
                {
                    Notify.Notifi.Show("Cập nhật không thành công", Notifi.typeNotify.success);
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            Reload();
        }
        private void Reload()
        {
            txtMaKhach.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            txtCCCD.Clear();
            txtSoDienThoai.Clear();
            cbbTrangThai.SelectedIndex = 0;
            txtEmail.Clear();
            txtQueQuan.Clear();
            lblMaHopDong.Text = ".";
            lblSoPhong.Text = "00";
            lsvDetailGuest.Items.Clear();
            txtMaKhach.Enabled = true;
        }

        private void cbbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<DTO.Guest> guests = bllGuest.FillGuestStatus(cbbStatus.SelectedItem.ToString());
            lsvGuest.Items.Clear();
            foreach (DTO.Guest g in guests)
            {
                ListViewItem lvi = new ListViewItem(g.MaKhach.ToString());
                lvi.SubItems.Add(g.HoTen);
                lvi.SubItems.Add(g.NgaySinh.ToShortDateString());
                lvi.SubItems.Add(g.CCCD);
                lvi.SubItems.Add(g.SoDienThoai);
                lvi.SubItems.Add(g.QueQuan);
                lvi.SubItems.Add(g.TrangThai);
                lvi.SubItems.Add(g.Email);
                lsvGuest.Items.Add(lvi);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<DTO.Guest> guests = bllGuest.FillGuestKey(txtSearch.Text);
            lsvGuest.Items.Clear();
            foreach (DTO.Guest g in guests)
            {
                ListViewItem lvi = new ListViewItem(g.MaKhach.ToString());
                lvi.SubItems.Add(g.HoTen);
                lvi.SubItems.Add(g.NgaySinh.ToShortDateString());
                lvi.SubItems.Add(g.CCCD);
                lvi.SubItems.Add(g.SoDienThoai);
                lvi.SubItems.Add(g.QueQuan);
                lvi.SubItems.Add(g.TrangThai);
                lvi.SubItems.Add(g.Email);
                lsvGuest.Items.Add(lvi);
            }
        }

        
    }
}
