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
    public partial class ContractForm : Form
    {
        BLL_Contract bllContract = new BLL_Contract();
        BLL_Rooms bllRoom = new BLL_Rooms();    
        BLL_Guest bllGuest = new BLL_Guest();
        public delegate void ReLoad();
        public event ReLoad ReloadEvent;

        // CONTRUCTER 
        public ContractForm()
        {
            InitializeComponent();
            setUp();
        }
        public ContractForm(string IDHD)
        {
            InitializeComponent();
           
            ShowDetail(IDHD);
            btnChangeId.Visible = false;
            ShowListGuest();
        }
        public ContractForm(string IDHD, int view)
        {
            InitializeComponent();

            ShowDetail(IDHD);
            btnChangeId.Visible = false;
            btnAdd.Visible = false;
        }

        // SET UP
        private DTO.Contract getContract()
        {
            DTO.Contract contract = new DTO.Contract();
            contract.Id = lblID.Text;
            contract.NgayThue = dtpNgayThue.Value;
            contract.HanThue = dtpHanThue.Value;
            contract.SoPhong = Convert.ToInt32(cbbRoom.Text);
            contract.GiaPhong = Convert.ToDecimal(txtPrice.Text);
            contract.TrangThai = cbbTrangThai.SelectedItem.ToString();
            contract.NgayTaoHopDong = dtpNgayTaoHD.Value;

            return contract;
        }
        private void setUp()
        {
            ChangeID();
            cbbTrangThai.SelectedIndex = 0;
            LoadCombBoxRoom();
            ShowListGuest();
        }
        private string RandomCode()
        {
            string hd = "HDT";
            Random rnd = new Random();
            string code = rnd.Next(1, 99999).ToString();
            return hd + code;
        }
        private void ChangeID()
        {
            string id = "1";
            do
            {

                id = RandomCode();
            }
            while (bllContract.ExistContract(id));

            lblID.Text = id.ToString();
        }
        private void btnChangeId_Click(object sender, EventArgs e)
        {
            ChangeID();
        }
        private void cbbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTypeRoom.Text = bllRoom.GetTypeRoomByID(cbbRoom.SelectedItem.ToString());
            txtPrice.Text = string.Format("{0:n0}", bllRoom.GetPriceRoomByID(cbbRoom.SelectedItem.ToString()));
        }
     


        // CRUD
        private void btnAddGuest_Click(object sender, EventArgs e)
        {
           
            if (lsvKhachThue.SelectedItems.Count > 0) {
                if (lsvDetailGuest.Items.Count == 0)
                {
                    ListViewItem item = new ListViewItem(lsvKhachThue.SelectedItems[0].Text);
                    item.SubItems.Add(lsvKhachThue.SelectedItems[0].SubItems[1].Text);
                    item.SubItems.Add("Khách Chính");
                    lsvDetailGuest.Items.Add(item);
                }
                else
                {
                    ListViewItem item = new ListViewItem(lsvKhachThue.SelectedItems[0].Text);
                    item.SubItems.Add(lsvKhachThue.SelectedItems[0].SubItems[1].Text);
                    item.SubItems.Add("Khách Phụ");
                    lsvDetailGuest.Items.Add(item);
                }
              
            }
        }
        private void btnRemoveGuest_Click(object sender, EventArgs e)
        {
            if (lsvDetailGuest.SelectedItems.Count > 0)
            {
                lsvDetailGuest.Items.RemoveAt(lsvDetailGuest.SelectedItems[0].Index);
                if(lsvDetailGuest.Items.Count == 1)
                {
                    lsvDetailGuest.Items[0].SubItems[2].Text = "Khách Chính";
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvDetailGuest.Items.Count > 0)
                {
                    if (!bllContract.ExistContract(lblID.Text))
                    {
                        if (bllContract.AddContract(getContract()) && saveDetailContract())
                        {
                            Notify.Notifi.Show("Tạo hợp đồng thành công", Notifi.typeNotify.success);
                            ReloadEvent?.Invoke();
                        }
                        else
                        {
                            Notify.Notifi.Show("Tạo hợp đồng không thành công", Notifi.typeNotify.warning);
                        }

                    }
                    else
                    {
                        DTO.Contract contract = getContract();
                        if (contract.TrangThai != "Đã Hủy")
                        {
                            bllContract.RemoveContract(lblID.Text);

                            if (bllContract.AddContract(getContract()) && saveDetailContract())
                            {
                                Notify.Notifi.Show("Cập nhật hợp đồng thành công", Notifi.typeNotify.success);
                                ReloadEvent?.Invoke();
                            }
                        }
                        else
                        {
                            if (bllContract.CancelContract(contract.Id))
                            {
                                Notify.Notifi.Show("Cập nhật hợp đồng thành công", Notifi.typeNotify.success);
                                ReloadEvent?.Invoke();
                            }
                        }

                    }
                    this.Close();
                }
                else
                {
                    Notify.Notifi.Show("Hợp đồng không có khách thuê", Notifi.typeNotify.warning);
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
        private bool saveDetailContract()
        {
            for (int i = 0; i < lsvDetailGuest.Items.Count; i++)
            {
                DetailContract dtc = new DetailContract();
                dtc.IDHopDong = lblID.Text;
                dtc.MaKhach = Convert.ToInt32(lsvDetailGuest.Items[i].Text);
                dtc.VaiTro = lsvDetailGuest.Items[i].SubItems[2].Text;
                if (!bllContract.AddDetailContract(dtc))
                {
                    return false;
                }
            }
            return true;
        }

        // SHOW 
        private void ShowListGuest()
        {
            List<DTO.Guest> guests = bllGuest.getListGuest();
            foreach (DTO.Guest g in guests)
            {
                ListViewItem item = new ListViewItem(g.MaKhach.ToString());
                item.SubItems.Add(g.HoTen);
                item.SubItems.Add(g.TrangThai);
                lsvKhachThue.Items.Add(item);
            }
        }
        private void LoadCombBoxRoom()
        {
            List<string> listRoom = bllRoom.getListRoomEmpty();
            foreach (string room in listRoom)
            {
                cbbRoom.Items.Add(room);
            }
            cbbRoom.SelectedIndex = 0;
        }
        private void ShowDetail(string mahd)
        {
            DTO.Contract contract = bllContract.FindContractByIDContract(mahd);
            List<DTO.DetailContract> detailContracts = bllContract.GetDetailContractList(mahd);
            
           
            lblID.Text = contract.Id;
            cbbTrangThai.Text = contract.TrangThai;
            dtpNgayTaoHD.Text = contract.NgayTaoHopDong.ToShortDateString();
            dtpNgayThue.Text = contract.NgayThue.ToShortDateString();
            dtpHanThue.Text = contract.HanThue.ToShortDateString();
            cbbRoom.Text = contract.SoPhong.ToString();
            lblTypeRoom.Text = bllRoom.GetTypeRoomByID(contract.SoPhong.ToString());
            txtPrice.Text = contract.GiaPhong.ToString();


            foreach(DetailContract dtctr in detailContracts)
            {
                ListViewItem item = new ListViewItem(dtctr.MaKhach.ToString());
                string name = bllGuest.getGuestName(dtctr.MaKhach);
                item.SubItems.Add(name);
                item.SubItems.Add(dtctr.VaiTro);
                lsvDetailGuest.Items.Add(item);
            }
        }
        
    }
}
