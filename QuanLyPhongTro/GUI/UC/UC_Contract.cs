using QuanLyPhongTro.BLL;
using QuanLyPhongTro.GUI.Forms;
using QuanLyPhongTro.GUI.Notify;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro.GUI.UC
{
    public partial class UC_Contract : UserControl
    {
        BLL_Contract bllContract = new BLL_Contract();
        public UC_Contract()
        {
            InitializeComponent();
            LoadContracts(bllContract.getListContract());
        }

        // SETUP 
        public void Reload()
        {

            LoadContracts(bllContract.getListContract());
        }
        private void LoadContracts(List<DTO.Contract> contracts)
        {
            lsvContract.Items.Clear();
            foreach (DTO.Contract contract in contracts)
            {
                ListViewItem item = new ListViewItem(contract.Id);
                item.SubItems.Add(contract.NgayThue.ToShortDateString());
                item.SubItems.Add(contract.HanThue.ToShortDateString());
                item.SubItems.Add(contract.SoPhong.ToString());
                item.SubItems.Add(string.Format("{0:n0}", contract.GiaPhong));
                item.SubItems.Add(contract.TrangThai.ToString());
                item.SubItems.Add(contract.NgayTaoHopDong.ToShortDateString());
                lsvContract.Items.Add(item);
            }

        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            lsvContract.Items.Clear();
            LoadContracts(bllContract.getListContract());
        }


        // CRUD
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ContractForm frm = new ContractForm();
            frm.ReloadEvent += Reload;
            frm.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lsvContract.SelectedItems.Count > 0) {
                ContractForm frm = new ContractForm(lsvContract.SelectedItems[0].Text);
                frm.ReloadEvent += Reload;
                frm.Show();
            }
           
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lsvContract.SelectedItems.Count > 0) {
                if (bllContract.RemoveContract(lsvContract.SelectedItems[0].Text))
                {
                 
                    Notify.Notifi.Show("Xóa thành công",Notifi.typeNotify.success);
                    Reload();
                }
                else
                {
                    Notify.Notifi.Show("Xóa không công", Notifi.typeNotify.warning);
                }
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (lsvContract.SelectedItems.Count > 0)
            {
                ContractForm frm = new ContractForm(lsvContract.SelectedItems[0].Text,1);
                frm.ReloadEvent += Reload;
                frm.Show();
            }
        }

        // FILL AND FIND
        private void cbbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadContracts(bllContract.FillContractStatus(cbbTrangThai.SelectedItem.ToString()));
        }
    }
}
