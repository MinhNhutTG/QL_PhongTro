using QuanLyPhongTro.BLL;
using QuanLyPhongTro.DTO;
using QuanLyPhongTro.GUI.Notify;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Windows.Forms;
using System.Net;

namespace QuanLyPhongTro.GUI.Forms
{
    public partial class BillDetail : Form
    {
        BLL_Config bllConfig = new BLL_Config();
        BLL_Bill bllbill = new BLL_Bill();
        BLL_Guest bllguest = new BLL_Guest();
        BLL_RoomService bllhistoryService = new BLL_RoomService();
        public BillDetail(string id)
        {
            InitializeComponent();
            ShowDetail(id);
            
        }
        
        private void ShowDetail(string id) {
            DTO.Bill bill = bllbill.FindBillByID(id);
            ShowHistoryService(bill.IdDichVu ?? 0);
            lblMaHoaDon.Text = bill.IdHoaDon;
            lblMaDichVu.Text = bill.IdDichVu.ToString();
            lblSoPhong.Text = bill.SoPhong.ToString();
            lblSoDien.Text = bill.SoDien.ToString();
            lblSoNuoc.Text = bill.SoNuoc.ToString();
            lblTrangThaiHD.Text = string.Format("{0:n0}", bill.TrangThai);
            lblNgayLap.Text = bill.NgayLapHoaDon.ToString();
            lblTienPhong.Text = string.Format("{0:n0}", bill.GiaPhong) + " VND";
            lblTienDien.Text = string.Format("{0:n0}", bill.TienDien) + " VND";
            lblTienNuoc.Text = string.Format("{0:n0}", bill.TienNuoc) + " VND";
            lblTienKhac.Text = string.Format("{0:n0}", bill.PhiKhac) + " VND";
            lblTongTien.Text = string.Format("{0:n0}", bill.TongTien) + " VND"; 
            rtbGhiChu.Text = bill.GhiChu;
        }
        private void ShowHistoryService(int mals)
        {
            DTO.RoomService hs = bllhistoryService.getHistoryServiceByID(mals);
            lblTienMang.Text = string.Format("{0:n0}", hs.TienMang) + " VND";
            lblSoNuocCu.Text = hs.SoNuocCu.ToString();
            lblSoNuocMoi.Text = hs.SoNuocMoi.ToString();
            lblGiaNuoc.Text =  string.Format("{0:n0}", hs.GiaNuoc) + " VND";
            lblSoDienCu.Text = hs.SoDienCu.ToString();
            lblSoDienMoi.Text = hs.SoDienMoi.ToString();
            lblGiaDien.Text = string.Format("{0:n0}", hs.GiaDien) + " VND";
        }

        private void lblTrangThaiHD_TextChanged(object sender, EventArgs e)
        {
            if (lblTrangThaiHD.Text == "Đã thanh toán")
            {
                lblTrangThaiHD.BackColor = ColorTranslator.FromHtml("25, 135, 84");
                lblTrangThaiHD.ForeColor = Color.White;
            }
            else if (lblTrangThaiHD.Text == "Chưa thanh toán")
            {
                lblTrangThaiHD.BackColor = Color.Red;
                lblTrangThaiHD.ForeColor = Color.White;
            }
        }

       
        private void btnSave_Click(object sender, EventArgs e)
        {
            Thread thr = new Thread(() =>
            {
                DTO.Bill bill = bllbill.FindBillByID(lblMaHoaDon.Text);
                DTO.RoomService hs = bllhistoryService.getHistoryServiceByID(Convert.ToInt32(bill.IdDichVu));
                DTO.Config config = bllConfig.getconfig();
                string htmlContent = $@"
                <!DOCTYPE html>
                <html lang='vi'>
                <head>
                    <meta charset='UTF-8'>
                    <style>
                        body {{ font-family: Arial, sans-serif; background: #f9f9f9; padding: 20px; }}
                        .invoice-container {{ width: 600px; background: #fff; padding: 20px; margin: auto; border-radius: 10px; box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1); }}
                        .header {{ text-align: center; font-size: 24px; font-weight: bold; color: #2e8b57; margin-bottom: 15px; }}
                        .section {{ border: 1px solid #ddd; padding: 10px; border-radius: 8px; margin-bottom: 10px; }}
                        .section h3 {{ color: #2e8b57; margin-top: 0; }}
                        .status {{ color: white; background-color: red; padding: 5px 10px; border-radius: 5px; font-weight: bold; }}
                        .total {{ color: red; font-weight: bold; font-size: 20px; }}
                    </style>
                </head>
                <body>
                    <div class='invoice-container'>
                        <div class='header'>HÓA ĐƠN TIỀN TRỌ</div>
                        <div class='section'>
                            <h3>Thông tin nhà trọ</h3>
                            <p><strong>Tên trọ:</strong> {config.TenNhaTro} </p>
                            <p><strong>Số tài khoản:</strong> {config.SoTaiKhoan} </p>
                            <p><strong>Ngân hàng:</strong> {config.TenNganHang}</p>
                            <p><strong>Chủ tài khoản:</strong> {config.TenTaiKhoan}</p>
                        </div>
                        <div class='section'>
                            <h3>Hóa đơn</h3>
                            <p><strong>Mã hóa đơn:</strong> {string.Format("{0:n0}", bill.IdHoaDon)}</p>
                            <p><strong>Trạng thái:</strong> <span class='status'>{bill.TrangThai}</span></p>
                            <p><strong>Ngày lập:</strong> {bill.NgayLapHoaDon}</p>
                        </div>
                        <div class='section'>
                            <h3>Dịch vụ</h3>
                            <p><strong>Số phòng:</strong> {bill.SoPhong}</p>
                            <p><strong>Tiền phòng:</strong> {string.Format("{0:n0}", bill.GiaPhong)} VNĐ</p>
                            <p><strong>Tiền điện:</strong> {string.Format("{0:n0}", bill.TienDien)} VNĐ</p>
                            <p><strong>Tiền nước:</strong> {string.Format("{0:n0}", bill.TienNuoc)} VNĐ</p>
                            <p><strong>Tiền mạng:</strong> {string.Format("{0:n0}", hs.TienMang)} VNĐ</p>
                            <p><strong>Phí khác:</strong> {string.Format("{0:n0}", bill.PhiKhac)} VNĐ</p>
                            <p class='total'>Tổng tiền: {string.Format("{0:n0}", bill.TongTien)} VNĐ</p>
                            <p><strong>Ghi chú:</strong> {bill.GhiChu}</p>  
                        </div>
                    </div>
                </body>
                </html>";

                try
                {
                    string mailTo = bllguest.getEmail(Convert.ToInt32(bill.SoPhong));
                    if (mailTo != null)
                    {
                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                        {
                            Credentials = new NetworkCredential("vietnamboardinghouse@gmail.com", "ziau vrck nvyt viem"),
                            EnableSsl = true
                        };


                        MailMessage mailMessage = new MailMessage
                        {
                            From = new MailAddress("vietnamboardinghouse@gmail.com"),
                            Subject = "Hóa Đơn Boarding House]",
                            Body = htmlContent,
                            IsBodyHtml = true
                        };
                        mailMessage.To.Add(mailTo);
                        client.Send(mailMessage);

                    }
                    else
                    {
                        Notifi.Show("Không có Email", Notifi.typeNotify.warning);
                    }
                }
                catch (Exception ex)
                {
                    Notifi.Show(ex.Message, Notifi.typeNotify.warning);
                }

            });
           
            thr.Start();
            Notifi.Show("Gửi hóa đơn thành công", Notifi.typeNotify.success);
            

        }
    }
    
}
