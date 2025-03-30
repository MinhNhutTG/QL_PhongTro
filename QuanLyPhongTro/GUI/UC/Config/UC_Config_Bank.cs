using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongTro.BLL;
using QuanLyPhongTro.DTO;
using QuanLyPhongTro.GUI.Custom;
using QuanLyPhongTro.GUI.Notify;

namespace QuanLyPhongTro.GUI.UC.Config
{
    public partial class UC_Config_Bank : UserControl
    {
        BLL_Config bll = new BLL_Config();
        public UC_Config_Bank()
        {
            InitializeComponent();
            LoadInfor();
        }
        private void LoadInfor()
        {
            DTO.Config cf = new DTO.Config();
            cf = bll.getconfig();
            txtID.Text = cf.SoTaiKhoan;
            txtNameAccount.Text = cf.TenTaiKhoan;
            txtNameBank.Text = cf.TenNganHang;
        }
        
        private void btnLuuBanking_Click(object sender, EventArgs e)
        {
            try
            {
                DTO.Config ifor = new DTO.Config();
                ifor.SoTaiKhoan = txtID.Text;
                ifor.TenTaiKhoan = txtNameAccount.Text;
                ifor.TenNganHang = txtNameBank.Text;
                if (bll.editInforBank(ifor))
                {
                    LoadInfor();
                    Notifi.Show("Cập nhật thông tin thành công", Notifi.typeNotify.success);
                }
                else
                {
                    Notifi.Show("Cập nhật thông tin không thành công", Notifi.typeNotify.error);
                }
            }
            catch (BusinessException ex)
            {
                Notifi.Show("Lỗi nghiệp vụ: " + ex.Message, Notifi.typeNotify.warning);
            }
            catch (Exception ex) {
                Notifi.Show("Lỗi hệ thống: " + ex.Message, Notifi.typeNotify.warning);
            }
           
           
        }

      
    }
}
