using QuanLyPhongTro.BLL;
using QuanLyPhongTro.GUI.Custom;
using QuanLyPhongTro.GUI.Notify;
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
    public partial class ModifyTypeRoom : Form
    {
        BLL_Rooms bllroom = new BLL_Rooms();
        public ModifyTypeRoom()
        {
            InitializeComponent();
            LoadLsvTypeRoom();
        }
        // SET UP 
        private void btnReload_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtNamType.Clear();
            txtPrice.Clear();
            txtID.Focus();
        }
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) { e.Handled = true; }
        }
        private void LoadLsvTypeRoom()
        {
            DataTable dt = bllroom.getDataTypeRoom();
            lsvTypeRoom.Items.Clear();
            foreach (DataRow r in dt.Rows)
            {
                ListViewItem item = new ListViewItem(r["MaLoai"].ToString());
                item.SubItems.Add(r["TenLoai"].ToString());

                item.SubItems.Add(string.Format("{0:n0}", r["Gia"]));

                lsvTypeRoom.Items.Add(item);
            }
        }
        private void lsvTypeRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvTypeRoom.SelectedItems.Count > 0)
            {
                txtID.Text = lsvTypeRoom.SelectedItems[0].SubItems[0].Text;
                txtNamType.Text = lsvTypeRoom.SelectedItems[0].SubItems[1].Text;
                txtPrice.Text = lsvTypeRoom.SelectedItems[0].SubItems[2].Text;
            }
        }


        // CRUD
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllroom.UpdateTypeRoom(txtID.Text, txtNamType.Text, txtPrice.Text) == true)
                {
                    Notifi.Show("Thực hiện thành công", Notifi.typeNotify.success);
                    LoadLsvTypeRoom();
                }
                else
                {
                    Notifi.Show("Thực hiện không thành công", Notifi.typeNotify.error);
                }

            }
            catch (BusinessException ex)
            {
                Notifi.Show("Lỗi nghiệp vụ: " + ex.Message, Notifi.typeNotify.error);
            }
            catch (Exception ex) {
                Notifi.Show("Lỗi hệ thống: " + ex.Message, Notifi.typeNotify.error);
            }


        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvTypeRoom.SelectedItems.Count > 0)
                {
                    DialogResult dg = Notify.Message.Show("Bạn có muốn xóa không");
                    if (dg == DialogResult.Yes)
                    {
                        bllroom.RemoveTypeRoom(lsvTypeRoom.SelectedItems[0].Text);
                        Notifi.Show("Thực hiện xóa thành công", Notifi.typeNotify.success);
                        LoadLsvTypeRoom();
                        btnReload_Click(sender, e);
                    }
                }
            }
            catch (BusinessException ex)
            {
                Notifi.Show("Lỗi nghiệp vụ: " + ex.Message, Notifi.typeNotify.error);
            }
            catch (Exception ex)
            {
                Notifi.Show("Lỗi hệ thống: " + ex.Message, Notifi.typeNotify.error);
            }
        }

      
    }
}
