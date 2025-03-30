using QuanLyPhongTro.BLL;
using QuanLyPhongTro.DTO;
using QuanLyPhongTro.GUI.Custom;
using QuanLyPhongTro.GUI.Forms;
using QuanLyPhongTro.GUI.Notify;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace QuanLyPhongTro.GUI.UC.Service
{
    public partial class UC_Service : UserControl
    {
        BLL_Service bllService =  new BLL_Service();
        BLL_RoomService historyService = new BLL_RoomService();
        BLL_Contract bllcontract =   new BLL_Contract();
        public int currentIndexRoom = -1;

        //////////// Constructer 
        ///
        private RoomService getHistoryServiec()
        {
            DTO.RoomService historyService = new DTO.RoomService();
            historyService.ID = Convert.ToInt32(lblID.Text);
            historyService.MaHopDong = txtMaHD.Text; 
            historyService.SoPhong = txtRoomID.Text;
            historyService.Ki = txtKi.Text;
            historyService.SoDienCu = Convert.ToInt32(txtSoDienCu.Text);
            historyService.SoDienMoi = Convert.ToInt32(txtDienMoi.Text);
            historyService.SoNuocCu = Convert.ToInt32(txtSoNuocCu.Text);
            historyService.SoNuocMoi = Convert.ToInt32(txtNuocMoi.Text);
            historyService.GiaDien = Convert.ToDecimal(txtGiaDien.Text);
            historyService.GiaNuoc = Convert.ToDecimal(txtGiaNuoc.Text);
            historyService.NgayTao = Convert.ToDateTime(txtNgayTao.Value.ToShortDateString());
            historyService.TienMang = Convert.ToDecimal(txtTienMang.Text);
            historyService.TrangThai = cbbStatus.Text;
           
            return historyService;
        }
        public UC_Service()
        {
            InitializeComponent();
            setMocThag();
            ShowPriceService();
            ShowDateCreate();
            showListHistoryService(historyService.SortKI_DESC());
            changeID();
            rdbSortKiDesc.Checked = true;
            cbbStatus.SelectedIndex = 0;
        }

        //////////// Hỗ trợ        ///
       
        private void ChangeRoom()
        {
            BLL_Rooms bllroom = new BLL_Rooms();
            List<string> listIDRoom = bllroom.ListRoomInContract();
           

            if (currentIndexRoom < 0 )
            {
                currentIndexRoom = 0;
            }
            else if (currentIndexRoom > listIDRoom.Count )
            {
                currentIndexRoom = listIDRoom.Count-1;
                string idContract = bllcontract.getIDContractByIDRoom(txtRoomID.Text);
                txtMaHD.Text = idContract;
            }
            if (currentIndexRoom >= 0 && currentIndexRoom <= listIDRoom.Count -1)
            {
                txtRoomID.Text = listIDRoom[currentIndexRoom];
                string idContract = bllcontract.getIDContractByIDRoom(txtRoomID.Text);
                txtMaHD.Text = idContract;
            }
        }        // Đổi số phòng textbox số phòng
        private int randomID()
        {
            Random rnd = new Random();
            int id = rnd.Next(1, 99999);
            return id;
        } // Tạo id 
        private void btnChangeId_Click(object sender, EventArgs e)
        {
            changeID();

        }
        private void changeID()
        {
            int id = 0;
            do
            {

                id = randomID();
            }
            while (historyService.ExistID(id));

            lblID.Text = id.ToString();
        }
        private void setMocThag()
        {
            DateTime now = DateTime.Now;
            string Ki = now.Month.ToString() + "-" + now.Year.ToString();
            txtKi.Text = Ki;

        }
        public void ShowPriceService()
        {
            List<DTO.Service> list = bllService.getListService();
            if (list == null || list.Count == 0)
            {
                txtGiaDien.Text = "0";
                txtGiaNuoc.Text = "0";
                txtTienMang.Text = "0";
            }
            else
            {
                txtGiaDien.Text = string.Format("{0:n0}", list[0].GiaDichVu);
                txtGiaNuoc.Text = string.Format("{0:n0}", list[1].GiaDichVu);
                txtTienMang.Text = string.Format("{0:n0}", list[2].GiaDichVu);
            }
           
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            currentIndexRoom -= 1;
            ChangeRoom();
            changeID();
            List<int> list = historyService.getValueOldService(txtRoomID.Text);

            if (list.Count > 0)
            {
                txtSoDienCu.Text = list[0].ToString();
                txtSoNuocCu.Text = list[1].ToString();
            }
            else
            {
                txtSoDienCu.Text = "0";

                txtSoNuocCu.Text = "0";
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentIndexRoom += 1;
            ChangeRoom();
            changeID();
            List<int> list = historyService.getValueOldService(txtRoomID.Text);

            if (list.Count > 0)
            {
                txtSoDienCu.Text = list[0].ToString();
                txtSoNuocCu.Text = list[1].ToString();
            }
            else
            {
                txtSoDienCu.Text = "0";

                txtSoNuocCu.Text = "0";
            }
        }
  
        private void txtRoomID_TextChanged(object sender, EventArgs e)
        {
            List<int> list = historyService.getValueOldService(txtRoomID.Text);
           
            if (list.Count > 0)
            {
                txtSoDienCu.Text = list[0].ToString();
                txtSoNuocCu.Text = list[1].ToString();
                
            }
            else
            {
                txtSoDienCu.Text = "0";

                txtSoNuocCu.Text = "0";
            }
            if (txtRoomID.Text == "0")
            {
                showListHistoryService(historyService.GetListHistoryService());
            }
            else
            {
                showListHistoryService(historyService.HistoryServicesByIDRoom(txtRoomID.Text));
            }

        }


        ///////// Display 
        ///

        private void ShowDateCreate()
        {
            DateTime time = DateTime.Now;
            txtNgayTao.Text = time.ToShortDateString();
        }


        private void btnReload_Click(object sender, EventArgs e)
        {
            changeID();
            txtRoomID.Text = "0";
            txtSoDienCu.Text = "0";
            txtDienMoi.Text = "0";
            txtSoNuocCu.Text = "0";
            txtNuocMoi.Text = "0";
            setMocThag();
            ShowPriceService();
            ShowDateCreate();
            currentIndexRoom = -1;
        }

        ////////////// CRUD
        ////
        private void btnSave_Click(object sender, EventArgs e)
        {
            int sodienmoi = Convert.ToInt32(txtDienMoi.Text);
            int sonuocmoi = Convert.ToInt32(txtNuocMoi.Text);
            int sodiencu = Convert.ToInt32(txtSoDienCu.Text);
            int sonuoccu = Convert.ToInt32(txtSoNuocCu.Text);
            bool Add = true;
            if (sodienmoi < sodiencu)
            {
                Notifi.Show("Số điện mới phải lớn hơn hoặc bằng số điện cũ", Notifi.typeNotify.error);
                Add = false;
            }
            if (sonuocmoi < sonuoccu)
            {
                Notifi.Show("Số nước mới phải lớn hơn hoặc bằng số nước cũ", Notifi.typeNotify.error);
                Add = false;
            }
            if (Add)
            {
                try
                {
                    RoomService rsv = getHistoryServiec();
                    if (!historyService.ExistID(rsv.ID))
                    {
                        if (historyService.AddHistoryService(rsv))
                        {
                            Notifi.Show("Thêm lịch sử dịch vụ thành công", Notifi.typeNotify.success);
                            showListHistoryService(historyService.SortKI_DESC());
                            changeID();
                        }
                        else
                        {
                            Notifi.Show("Thêm lịch sử dịch vụ không thành công", Notifi.typeNotify.error);
                        }
                    }
                    else
                    {
                        Notifi.Show("Mã đã tồn tại", Notifi.typeNotify.error);
                    }
                   
                }
                catch (BusinessException ex)
                {
                    Notifi.Show("Lỗi nghiệp vụ: " + ex.Message, Notifi.typeNotify.warning);
                }
                catch (Exception ex)
                {
                    Notifi.Show("Lỗi hệ thống: " + ex.Message, Notifi.typeNotify.warning);
                }
            }


        }            // Thêm  
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lsvService.SelectedItems.Count > 0)
            {
                DialogResult dg = Notify.Message.Show("Bạn có muốn lịch sử dịch vụ này không");
                if (dg == DialogResult.Yes)
                {
                    if (historyService.RemoveHistoryService(Convert.ToInt32(lsvService.SelectedItems[0].Text)))
                    {
                        Notifi.Show("Xóa lịch sử dịch vụ thành công", Notifi.typeNotify.success);
                        showListHistoryService(historyService.SortKI_DESC());
                        
                        changeID();
                    }
                }

            }
            else
            {
                Notifi.Show("Hãy chọn lịch sử dịch vụ cần xóa", Notifi.typeNotify.error);
            }
        }           // Xóa 
        private void ShowHistory(DTO.RoomService service)
        {
            lblID.Text = service.ID.ToString();
            txtMaHD.Text = service.MaHopDong.ToString();
            txtRoomID.Text = service.SoPhong.ToString();
            
            txtKi.Text = service.Ki.ToString();
            txtSoDienCu.Text = service.SoDienCu.ToString();
            txtDienMoi.Text = service.SoDienMoi.ToString();
            txtSoNuocCu.Text = service.SoNuocCu.ToString();
            txtNuocMoi.Text = service.SoNuocMoi.ToString();
            txtGiaDien.Text = string.Format("{0:n0}", service.GiaDien);
            txtGiaNuoc.Text = string.Format("{0:n0}", service.GiaNuoc);
            txtNgayTao.Text = service.NgayTao.ToShortDateString();
            txtTienMang.Text = string.Format("{0:n0}", service.TienMang);
            cbbStatus.SelectedItem = service.TrangThai;
        }
       
        private void showListHistoryService(List<RoomService> list)
        {
          
            lsvService.Items.Clear();
            if (list.Count > 0)
            {
                foreach (RoomService sv in list)
                {
                    ListViewItem item = new ListViewItem(sv.ID.ToString());
                    item.SubItems.Add(sv.MaHopDong);
                    item.SubItems.Add(sv.SoPhong);
                    item.SubItems.Add(sv.Ki);
                    item.SubItems.Add(sv.SoDienCu.ToString());
                    item.SubItems.Add(sv.SoDienMoi.ToString());

                    item.SubItems.Add(sv.SoNuocCu.ToString());
                    item.SubItems.Add(sv.SoNuocMoi.ToString());
                    item.SubItems.Add(string.Format("{0:n0}", sv.GiaDien));
                    item.SubItems.Add(string.Format("{0:n0}", sv.GiaNuoc));
                    item.SubItems.Add(sv.TrangThai);
                    if (sv.TrangThai == "Chờ Lập Hóa Đơn")
                    {
                        item.BackColor = ColorTranslator.FromHtml("#FBA518");
                        item.ForeColor = Color.White;
                    }
                    item.SubItems.Add(sv.NgayTao.ToShortDateString());
                    item.SubItems.Add(string.Format("{0:n0}", sv.TienMang));
                    if (bllcontract.CheckCancelContract(sv.MaHopDong))
                    {
                        item.BackColor = ColorTranslator.FromHtml("#5C7285");
                        item.ForeColor = Color.White;
                    }
                   
                    lsvService.Items.Add(item);
                }
            }

        }                                         // Hiển thị danh sách 
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int sodienmoi = Convert.ToInt32(txtDienMoi.Text);
            int sonuocmoi = Convert.ToInt32(txtNuocMoi.Text);
            int sodiencu = Convert.ToInt32(txtSoDienCu.Text);
            int sonuoccu = Convert.ToInt32(txtSoNuocCu.Text);
            bool Update = true;
            if (sodienmoi < sodiencu)
            {
                Notifi.Show("Số điện mới phải lớn hơn hoặc bằng số điện cũ", Notifi.typeNotify.error);
                Update = false;
            }
            if (sonuocmoi < sonuoccu)
            {
                Notifi.Show("Số nước mới phải lớn hơn hoặc bằng số nước cũ", Notifi.typeNotify.error);
                Update = false;
            }
            if (Update)
            {
                try
                {

                    if (historyService.UpdateHistoryService(getHistoryServiec()))
                    {
                        Notifi.Show("Cập nhật lịch sử dịch vụ thành công", Notifi.typeNotify.success);
                        showListHistoryService(historyService.SortKI_DESC());
                        changeID();
                    }
                    else
                    {
                        Notifi.Show("Cập nhật lịch sử dịch vụ không thành công", Notifi.typeNotify.error);
                    }

                }
                catch (BusinessException ex)
                {
                    Notifi.Show("Lỗi nghiệp vụ: " + ex.Message, Notifi.typeNotify.warning);
                }
                catch (Exception ex)
                {
                    Notifi.Show("Lỗi hệ thống: " + ex.Message, Notifi.typeNotify.warning);
                }
            }
        }          // Cập nhật

        private void rdbSortKiDesc_CheckedChanged(object sender, EventArgs e)
        {
            showListHistoryService(historyService.SortKI_DESC());
        }
        
        private void rdbSortKiASC_CheckedChanged(object sender, EventArgs e)
        {
            showListHistoryService(historyService.SortKI_ASC());
        }

        private void btnPriceService_Click(object sender, EventArgs e)
        {
            PriceService frm = new PriceService();
            frm.ReloadEvent += ShowPriceService;
            frm.Show();
        }

        private void lsvService_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lsvService.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(lsvService.SelectedItems[0].Text);
               
                DTO.RoomService service = historyService.getHistoryServiceByID(id);
                ShowHistory(service);
            }
        }

    
        private void cbbFillStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            showListHistoryService(historyService.FillHistoryByStatus(cbbFillStatus.SelectedItem.ToString()));
        }

      
    }
}
