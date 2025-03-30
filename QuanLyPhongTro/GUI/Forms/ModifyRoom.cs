using QuanLyPhongTro.BLL;
using QuanLyPhongTro.DTO;
using QuanLyPhongTro.GUI.Custom;
using QuanLyPhongTro.GUI.Notify;
using QuanLyPhongTro.GUI.UC.Room;
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
    public partial class ModifyRoom : Form
    {
        public delegate void ReLoad();
        public event ReLoad ReloadEvent;
        BLL_Rooms bllRoom = new BLL_Rooms();
        public ModifyRoom()
        {
            InitializeComponent();
            loadComboBoxType();
            btnAddRoom.Click -= btnUpdate_Click;
            btnAddRoom.Click += btnAddRoom_Click;
        }
        public ModifyRoom(int soPhong)
        {
            InitializeComponent();
            loadComboBoxType();
            LoadInfor(soPhong);
            txtIDRoom.Enabled = false;
            btnAddRoom.Click -= btnAddRoom_Click;
            btnAddRoom.Click += btnUpdate_Click;

        }
        private void LoadInfor(int soPhong)
        {
            DTO.Room room = bllRoom.FindRoomByID(soPhong);
            if (room != null) { 
                txtIDRoom.Text = room.SoPhong.ToString();
                cbbTypeRoom.Text = room.TenLoai;
                if (room.TrangThai == "Trống")
                {
                    rdbStatus1.Checked = true;
                }
                else if (room.TrangThai == "Đang thuê")
                {
                    rdbStatus2.Checked = true;
                }
                else if (room.TrangThai == "Đang sửa chữa")
                {
                    rdbStatus3.Checked = true;
                }
                rtbNote.Text = room.GhiChu.ToString();
            }
        }

        // SET UP 
        private void btnCloses_Click(object sender, EventArgs e)
        {
            DialogResult dg = Notify.Message.Show("Bạn có muốn thoát không ?");
            if (dg == DialogResult.Yes) { 
                this.Close();
            }
        }
        private void loadComboBoxType()
        {
            cbbTypeRoom.DataSource = bllRoom.GetTypeRoom();
            cbbTypeRoom.DisplayMember = "TenLoai";
            cbbTypeRoom.ValueMember = "MaLoai";
        }
        private void btnResetTextBox_Click(object sender, EventArgs e)
        {
            txtIDRoom.Clear();
            cbbTypeRoom.SelectedIndex = 0;
            rdbStatus1.Checked = false;
            rdbStatus2.Checked = false;
            rdbStatus3.Checked = false;
            rtbNote.Clear();
            txtIDRoom.Focus();
        }
        private DTO.Room getRoom()
        {
            DTO.Room room = new DTO.Room();
            room.SoPhong = txtIDRoom.Text;
           
            room.MaLoai = cbbTypeRoom.SelectedValue.ToString();
            if (rdbStatus1.Checked)
            {
                room.TrangThai = "Trống";
            }
            else if (rdbStatus2.Checked) {
                room.TrangThai = "Đang thuê";
            }
            else if (rdbStatus3.Checked)
            {
                room.TrangThai = "Đang sửa chữa";
            }  
            room.GhiChu = rtbNote.Text;
             
            return room;
        }


        // CRUD 
        private void btnAddRoom_Click(object sender, EventArgs e)
        {

            try
            {
                if (bllRoom.roomExist(txtIDRoom.Text))
                {
                    Notifi.Show("Phòng đã tồn tại", Notifi.typeNotify.error);
                }
                else
                {
                    DTO.Room r = getRoom();
                    if (bllRoom.AddRoom(r) == true)
                    {
                        ReloadEvent?.Invoke();
                        btnResetTextBox_Click(sender, e);
                        Notifi.Show("Thực hiện thêm thanh công", Notifi.typeNotify.success);
                        
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
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                if (bllRoom.roomExist(txtIDRoom.Text))
                {

                    DTO.Room r = getRoom();
                    if (bllRoom.UpdateRoom(r) == true)
                    {
                        ReloadEvent?.Invoke();
                        Notifi.Show("Thực hiện cập nhật thanh công", Notifi.typeNotify.success);
                       
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

        private void txtIDRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) { 
                e.Handled = true;
            }
        }

    }
}
