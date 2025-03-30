using QuanLyPhongTro.DAL;
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
using QuanLyPhongTro.GUI.Custom;
using QuanLyPhongTro.GUI.Notify;

namespace QuanLyPhongTro.GUI.UC.Config
{
    public partial class UC_EmailSystem : UserControl
    {
        BLL.BLL_Config bll = new BLL.BLL_Config();

        public UC_EmailSystem()
        {
            InitializeComponent();
            loadEmail();
        }
        private void loadEmail()
        {
            DTO.Config cf = new DTO.Config();
            cf = bll.getconfig();
            txtEmail.Text = cf.EmailSystem;
            txtAppPass.Text = cf.AppPassword;
        }

        private void btnLuuBanking_Click(object sender, EventArgs e)
        {

            try
            {
                DTO.Config cf = new DTO.Config();
                cf.EmailSystem = txtEmail.Text;
                cf.AppPassword = txtAppPass.Text;
                if (bll.editInforEmail(cf))
                {
                    loadEmail();
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
            catch (Exception ex)
            {
                Notifi.Show("Lỗi hệ thống: " + ex.Message, Notifi.typeNotify.warning);
            }
        }
    }
}
