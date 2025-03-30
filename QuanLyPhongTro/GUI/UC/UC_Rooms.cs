using QuanLyPhongTro.BLL;
using QuanLyPhongTro.GUI.Custom;
using QuanLyPhongTro.GUI.Forms;
using QuanLyPhongTro.GUI.Notify;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro.GUI.UC.Room
{
    public partial class UC_Rooms : UserControl
    {
        BLL_Rooms bllRoom = new BLL_Rooms();
        string selectedItemTypeRoom = string.Empty;
        string selectedItemStatusRooom = string.Empty;
        public UC_Rooms()
        {
            InitializeComponent();
            loadListRoom(bllRoom.getlistRoom());
            loadComboBoxTypeRoom();
            loadComboBoxStatusRoom();
        }

        // SET UP  AND SHOW 
        private void loadListRoom(List<DTO.Room> list) 
        {
            lsvRoom.Items.Clear();
            foreach (DTO.Room r in list) { 
                ListViewItem item = new ListViewItem(r.SoPhong);
                item.SubItems.Add(r.TenLoai);
                item.SubItems.Add(r.TrangThai);
                item.SubItems.Add(string.Format("{0:n0}", r.Gia) + " VND");
                item.SubItems.Add(r.GhiChu);
                if(r.TrangThai == "Đang Thuê")
                {
                    item.BackColor = ColorTranslator.FromHtml("#D91656");
                    item.ForeColor = Color.White;
                }
                else if (r.TrangThai == "Đang sửa chữa")
                {
                        item.BackColor = ColorTranslator.FromHtml("#FFEB00");
                }
                lsvRoom.Items.Add(item);
            }
        }
        private void loadComboBoxTypeRoom()
        {
            cbbType.DataSource = bllRoom.GetTypeRoom();
            cbbType.DisplayMember = "TenLoai";
            cbbType.ValueMember = "MaLoai";
        }
        private void loadComboBoxStatusRoom()
        {
            cbbStatus.SelectedIndex = 0;
        }
        private void cbbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbType.SelectedIndex != 0)
            {
                selectedItemTypeRoom = cbbType.SelectedValue.ToString();
              
               
            }
            else
            {
                selectedItemTypeRoom = null;

            }
            fill();

        }
        private void cbbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbStatus.SelectedIndex != 0)
            {
                selectedItemStatusRooom = cbbStatus.Text;
            }
            else
            {
                selectedItemStatusRooom = null;
            }
            fill();
        }
        private void btnLoadCbb_Click(object sender, EventArgs e)
        {
            cbbStatus.SelectedIndex = 0;
            cbbType.SelectedIndex = 0;
            loadListRoom(bllRoom.getlistRoom());
        }
        public void ReLoad()
        {
            loadListRoom(bllRoom.getlistRoom());
        }

        // FILL
        private void fill()
        { 

            List<DTO.Room> listRoom = new List<DTO.Room>();

            if (!string.IsNullOrEmpty(selectedItemTypeRoom) && !string.IsNullOrEmpty(selectedItemStatusRooom)) {
                listRoom = bllRoom.fillerStatusAndType(selectedItemTypeRoom, selectedItemStatusRooom);
            }
            else if (!string.IsNullOrEmpty(selectedItemTypeRoom)) {
                
                listRoom = bllRoom.fillerTypeRoom(selectedItemTypeRoom);
            }
            else if (!string.IsNullOrEmpty(selectedItemStatusRooom))
            {
              
                listRoom = bllRoom.fillerStatusRoom(selectedItemStatusRooom);
            }
            else
            {
                listRoom = bllRoom.getlistRoom();
            }
           
            loadListRoom(listRoom);
        }
        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvRoom.SelectedItems.Count == 1)
                {
                    string id = lsvRoom.SelectedItems[0].Text;
                 
                    DialogResult dg = Notify.Message.Show("Nếu xóa phòng sẽ xóa toàn bộ thông tin liên quan đến phòng, bạn có chắc xóa không ?");
                    if (dg == DialogResult.Yes)
                    {
                        if (bllRoom.removeRoom(id))
                        {
                            loadListRoom(bllRoom.getlistRoom());
                            Notifi.Show("Xóa phòng thành công", Notifi.typeNotify.success);
                        }
                    }
                }
                else
                {
                    Notifi.Show("Bạn cần phải chọn phòng cần xóa", Notifi.typeNotify.error);
                }
            }
            catch (BusinessException ex) {
                Notifi.Show("Lỗi hệ thống: " + ex.Message, Notifi.typeNotify.warning);
            }
            catch (Exception ex)
            {
                Notifi.Show("Lỗi nghiệp vụ: " + ex.Message, Notifi.typeNotify.warning);
            }
        }
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            ModifyRoom frm = new ModifyRoom();
            frm.ReloadEvent += ReLoad;
            frm.ShowDialog();
            
        }
        private void btnModifyRoom_Click(object sender, EventArgs e)
        {
            if (lsvRoom.SelectedItems.Count > 0) {
                ModifyRoom frm = new ModifyRoom(Convert.ToInt32(lsvRoom.SelectedItems[0].SubItems[0].Text));
                frm.ReloadEvent += ReLoad;
                frm.ShowDialog();

            }
            else
            {
                Notifi.Show("Cần chọn phòng để chỉnh sửa", Notifi.typeNotify.error);
            }
           
        }
        private void btnManageTypeRoom_Click(object sender, EventArgs e)
        {
            ModifyTypeRoom frm = new ModifyTypeRoom();
            frm.ShowDialog();
        }

     
    }
}
