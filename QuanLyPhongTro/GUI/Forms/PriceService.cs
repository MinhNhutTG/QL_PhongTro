using QuanLyPhongTro.BLL;
using QuanLyPhongTro.DTO;
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
    public partial class PriceService : Form
    {
        BLL_Service bllservice = new BLL_Service();
        public delegate void ReLoad();
        public event ReLoad ReloadEvent;
        public PriceService()
        {
            InitializeComponent();
            LoadListService();
        }

        private void btnCloses_Click(object sender, EventArgs e)
        {
            DialogResult dg = Notify.Message.Show("Bạn có muốn thoát không ?");
            if (dg == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public void LoadListService() {
            lsvService.Items.Clear();
            foreach (Service sv in bllservice.getListService()) {
                ListViewItem lvi = new ListViewItem(sv.TenDichVu);
                lvi.SubItems.Add(string.Format("{0:n0}",sv.GiaDichVu));
                lsvService.Items.Add(lvi);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            txtprice.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lsvService.SelectedItems.Count > 0)
            {
                DialogResult dg = Notify.Message.Show("Bạn có muốn xóa không");
                if (dg == DialogResult.Yes)
                {
                    bllservice.DeleteService(lsvService.SelectedItems[0].Text);
                    Notifi.Show("Thực hiện xóa thành công", Notifi.typeNotify.success);
                    LoadListService();
                    btnReload_Click(sender, e);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DTO.Service sv = new DTO.Service();
                sv.TenDichVu = txtname.Text;
                sv.GiaDichVu = Convert.ToDecimal(txtprice.Text);
                if (!bllservice.ExistService(txtname.Text))
                {

                    if (bllservice.AddService(sv))
                    {
                        Notifi.Show("Thực hiện thêm thành công", Notifi.typeNotify.success);
                        LoadListService();
                        ReloadEvent?.Invoke();
                    }
                }
                else
                {
                    if (bllservice.UpdateService(sv))
                    {
                        Notifi.Show("Thực hiện cập nhật thành công", Notifi.typeNotify.success);
                        LoadListService();
                        ReloadEvent?.Invoke();
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

        private void lsvService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvService.SelectedItems.Count > 0) { 
                DTO.Service service = bllservice.GetServiceByName(lsvService.SelectedItems[0].Text);
                txtname.Text = service.TenDichVu;
                txtprice.Text = service.GiaDichVu.ToString();
            }
        }
    }
}
