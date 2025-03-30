using System.Drawing;
using System.Windows.Forms;

namespace QuanLyPhongTro.GUI.UC.Bill
{
    partial class UC_Bill
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lsvHoaDon = new System.Windows.Forms.ListView();
            this.IDHoaDon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IdDichVu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoPhong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoDien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TienDien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoNuoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TienNuoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PhiKhac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TongTien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TrangThai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GiaPhong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NgayLapHoaDon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GhiChu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnAddBillAuto = new System.Windows.Forms.Button();
            this.btnRemoveBill = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.btnAddBill = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.rdbUnpaid = new System.Windows.Forms.RadioButton();
            this.rdbPaid = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeId = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnChangeId)).BeginInit();
            this.SuspendLayout();
            // 
            // lsvHoaDon
            // 
            this.lsvHoaDon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDHoaDon,
            this.IdDichVu,
            this.SoPhong,
            this.SoDien,
            this.TienDien,
            this.SoNuoc,
            this.TienNuoc,
            this.PhiKhac,
            this.TongTien,
            this.TrangThai,
            this.GiaPhong,
            this.NgayLapHoaDon,
            this.GhiChu});
            this.lsvHoaDon.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lsvHoaDon.FullRowSelect = true;
            this.lsvHoaDon.GridLines = true;
            this.lsvHoaDon.HideSelection = false;
            this.lsvHoaDon.Location = new System.Drawing.Point(21, 106);
            this.lsvHoaDon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lsvHoaDon.Name = "lsvHoaDon";
            this.lsvHoaDon.Size = new System.Drawing.Size(964, 591);
            this.lsvHoaDon.SmallImageList = this.imageList;
            this.lsvHoaDon.TabIndex = 0;
            this.lsvHoaDon.UseCompatibleStateImageBehavior = false;
            this.lsvHoaDon.View = System.Windows.Forms.View.Details;
            // 
            // IDHoaDon
            // 
            this.IDHoaDon.Text = "Mã hóa đơn";
            this.IDHoaDon.Width = 100;
            // 
            // IdDichVu
            // 
            this.IdDichVu.Text = "Mã dịch vụ";
            this.IdDichVu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IdDichVu.Width = 100;
            // 
            // SoPhong
            // 
            this.SoPhong.Text = "Số phòng";
            this.SoPhong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SoPhong.Width = 80;
            // 
            // SoDien
            // 
            this.SoDien.Text = "Số điện";
            this.SoDien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SoDien.Width = 70;
            // 
            // TienDien
            // 
            this.TienDien.Text = "Tiền điện";
            this.TienDien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TienDien.Width = 100;
            // 
            // SoNuoc
            // 
            this.SoNuoc.Text = "Số nước";
            this.SoNuoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SoNuoc.Width = 70;
            // 
            // TienNuoc
            // 
            this.TienNuoc.Text = "Tiền nước";
            this.TienNuoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TienNuoc.Width = 100;
            // 
            // PhiKhac
            // 
            this.PhiKhac.Text = "Phí Khác";
            this.PhiKhac.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PhiKhac.Width = 100;
            // 
            // TongTien
            // 
            this.TongTien.Text = "Tổng tiền";
            this.TongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TongTien.Width = 140;
            // 
            // TrangThai
            // 
            this.TrangThai.Text = "Trạng Thái";
            this.TrangThai.Width = 100;
            // 
            // GiaPhong
            // 
            this.GiaPhong.Text = "Giá phòng";
            this.GiaPhong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.GiaPhong.Width = 100;
            // 
            // NgayLapHoaDon
            // 
            this.NgayLapHoaDon.Text = "Ngày lập hóa đơn";
            this.NgayLapHoaDon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NgayLapHoaDon.Width = 100;
            // 
            // GhiChu
            // 
            this.GhiChu.Text = "Ghi chú";
            this.GhiChu.Width = 200;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(1, 30);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnAddBillAuto
            // 
            this.btnAddBillAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.btnAddBillAuto.FlatAppearance.BorderSize = 0;
            this.btnAddBillAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBillAuto.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAddBillAuto.ForeColor = System.Drawing.Color.White;
            this.btnAddBillAuto.Location = new System.Drawing.Point(998, 106);
            this.btnAddBillAuto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddBillAuto.Name = "btnAddBillAuto";
            this.btnAddBillAuto.Size = new System.Drawing.Size(140, 37);
            this.btnAddBillAuto.TabIndex = 2;
            this.btnAddBillAuto.Text = "Tạo HD tự động";
            this.btnAddBillAuto.UseVisualStyleBackColor = false;
            this.btnAddBillAuto.Click += new System.EventHandler(this.btnAddBillAuto_Click);
            // 
            // btnRemoveBill
            // 
            this.btnRemoveBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnRemoveBill.FlatAppearance.BorderSize = 0;
            this.btnRemoveBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveBill.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnRemoveBill.ForeColor = System.Drawing.Color.White;
            this.btnRemoveBill.Location = new System.Drawing.Point(998, 252);
            this.btnRemoveBill.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRemoveBill.Name = "btnRemoveBill";
            this.btnRemoveBill.Size = new System.Drawing.Size(140, 37);
            this.btnRemoveBill.TabIndex = 3;
            this.btnRemoveBill.Text = "Xóa hóa đơn";
            this.btnRemoveBill.UseVisualStyleBackColor = false;
            this.btnRemoveBill.Click += new System.EventHandler(this.btnRemoveBill_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(998, 204);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(140, 37);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Chỉnh sửa";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnViewDetail.FlatAppearance.BorderSize = 0;
            this.btnViewDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnViewDetail.ForeColor = System.Drawing.Color.White;
            this.btnViewDetail.Location = new System.Drawing.Point(998, 302);
            this.btnViewDetail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(140, 37);
            this.btnViewDetail.TabIndex = 5;
            this.btnViewDetail.Text = "Xem chi tiết";
            this.btnViewDetail.UseVisualStyleBackColor = false;
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // btnAddBill
            // 
            this.btnAddBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.btnAddBill.FlatAppearance.BorderSize = 0;
            this.btnAddBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBill.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAddBill.ForeColor = System.Drawing.Color.White;
            this.btnAddBill.Location = new System.Drawing.Point(998, 154);
            this.btnAddBill.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddBill.Name = "btnAddBill";
            this.btnAddBill.Size = new System.Drawing.Size(140, 37);
            this.btnAddBill.TabIndex = 6;
            this.btnAddBill.Text = "Tạo hóa đơn";
            this.btnAddBill.UseVisualStyleBackColor = false;
            this.btnAddBill.Click += new System.EventHandler(this.btnAddBill_Click_1);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(974, 46);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(79, 29);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSearch.Location = new System.Drawing.Point(660, 46);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(309, 29);
            this.txtSearch.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.rdbUnpaid);
            this.groupBox1.Controls.Add(this.rdbPaid);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(21, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 80);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lọc hóa đơn";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(76, 27);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(151, 29);
            this.dtpDate.TabIndex = 7;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // rdbUnpaid
            // 
            this.rdbUnpaid.AutoSize = true;
            this.rdbUnpaid.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdbUnpaid.Location = new System.Drawing.Point(431, 51);
            this.rdbUnpaid.Name = "rdbUnpaid";
            this.rdbUnpaid.Size = new System.Drawing.Size(127, 23);
            this.rdbUnpaid.TabIndex = 6;
            this.rdbUnpaid.TabStop = true;
            this.rdbUnpaid.Text = "Chưa thanh toán";
            this.rdbUnpaid.UseVisualStyleBackColor = true;
            this.rdbUnpaid.Click += new System.EventHandler(this.rdpUnpaid_Click);
            // 
            // rdbPaid
            // 
            this.rdbPaid.AutoSize = true;
            this.rdbPaid.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdbPaid.Location = new System.Drawing.Point(431, 20);
            this.rdbPaid.Name = "rdbPaid";
            this.rdbPaid.Size = new System.Drawing.Size(111, 23);
            this.rdbPaid.TabIndex = 5;
            this.rdbPaid.TabStop = true;
            this.rdbPaid.Text = "Đã thanh toán";
            this.rdbPaid.UseVisualStyleBackColor = true;
            this.rdbPaid.Click += new System.EventHandler(this.rdpUnpaid_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(285, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Trạng thái thanh toán :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(15, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng : ";
            // 
            // btnChangeId
            // 
            this.btnChangeId.Image = global::QuanLyPhongTro.Properties.Resources.reload;
            this.btnChangeId.Location = new System.Drawing.Point(1076, 51);
            this.btnChangeId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChangeId.Name = "btnChangeId";
            this.btnChangeId.Size = new System.Drawing.Size(18, 20);
            this.btnChangeId.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnChangeId.TabIndex = 25;
            this.btnChangeId.TabStop = false;
            this.btnChangeId.Click += new System.EventHandler(this.btnChangeId_Click);
            // 
            // UC_Bill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnChangeId);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnAddBill);
            this.Controls.Add(this.btnViewDetail);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnRemoveBill);
            this.Controls.Add(this.btnAddBillAuto);
            this.Controls.Add(this.lsvHoaDon);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UC_Bill";
            this.Size = new System.Drawing.Size(1231, 712);
            this.Load += new System.EventHandler(this.UC_Bill_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnChangeId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvHoaDon;
        private System.Windows.Forms.Button btnAddBillAuto;
        private System.Windows.Forms.Button btnRemoveBill;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnViewDetail;
        private System.Windows.Forms.Button btnAddBill;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ColumnHeader IDHoaDon;
        private System.Windows.Forms.ColumnHeader SoPhong;
        private System.Windows.Forms.ColumnHeader SoDien;
        private System.Windows.Forms.ColumnHeader SoNuoc;
        private System.Windows.Forms.ColumnHeader TongTien;
        private System.Windows.Forms.ColumnHeader TienDien;
        private System.Windows.Forms.ColumnHeader TienNuoc;
        private System.Windows.Forms.ColumnHeader TrangThai;
        private System.Windows.Forms.ColumnHeader NgayLapHoaDon;
        private ImageList imageList;
        private ColumnHeader IdDichVu;
        private ColumnHeader PhiKhac;
        private ColumnHeader GhiChu;
        private ColumnHeader GiaPhong;
        private GroupBox groupBox1;
        private Label label3;
        private RadioButton rdbUnpaid;
        private RadioButton rdbPaid;
        private Label label1;
        private DateTimePicker dtpDate;
        private PictureBox btnChangeId;
    }
}
