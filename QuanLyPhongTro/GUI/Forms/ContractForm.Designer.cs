namespace QuanLyPhongTro.GUI.Forms
{
    partial class ContractForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsvKhachThue = new System.Windows.Forms.ListView();
            this.IDKhach = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TenKhach = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TrangThai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dtpNgayTaoHD = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTypeRoom = new System.Windows.Forms.Label();
            this.cbbRoom = new System.Windows.Forms.ComboBox();
            this.btnChangeId = new System.Windows.Forms.PictureBox();
            this.lblID = new System.Windows.Forms.Label();
            this.dtpHanThue = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayThue = new System.Windows.Forms.DateTimePicker();
            this.cbbTrangThai = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lsvDetailGuest = new System.Windows.Forms.ListView();
            this.MaKhach = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ten = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VaiTro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddGuest = new System.Windows.Forms.Button();
            this.btnRemoveGuest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnChangeId)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsvKhachThue);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(28, 25);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(329, 215);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách khách thuê";
            // 
            // lsvKhachThue
            // 
            this.lsvKhachThue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDKhach,
            this.TenKhach,
            this.TrangThai});
            this.lsvKhachThue.FullRowSelect = true;
            this.lsvKhachThue.HideSelection = false;
            this.lsvKhachThue.Location = new System.Drawing.Point(14, 24);
            this.lsvKhachThue.Margin = new System.Windows.Forms.Padding(2);
            this.lsvKhachThue.Name = "lsvKhachThue";
            this.lsvKhachThue.Size = new System.Drawing.Size(308, 175);
            this.lsvKhachThue.TabIndex = 0;
            this.lsvKhachThue.UseCompatibleStateImageBehavior = false;
            this.lsvKhachThue.View = System.Windows.Forms.View.Details;
            // 
            // IDKhach
            // 
            this.IDKhach.Text = "Mã Khách";
            this.IDKhach.Width = 50;
            // 
            // TenKhach
            // 
            this.TenKhach.Text = "Tên Khách";
            this.TenKhach.Width = 150;
            // 
            // TrangThai
            // 
            this.TrangThai.Text = "Trạng Thái";
            this.TrangThai.Width = 120;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPrice);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.dtpNgayTaoHD);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblTypeRoom);
            this.groupBox2.Controls.Add(this.cbbRoom);
            this.groupBox2.Controls.Add(this.btnChangeId);
            this.groupBox2.Controls.Add(this.lblID);
            this.groupBox2.Controls.Add(this.dtpHanThue);
            this.groupBox2.Controls.Add(this.dtpNgayThue);
            this.groupBox2.Controls.Add(this.cbbTrangThai);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.Location = new System.Drawing.Point(370, 25);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(583, 416);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hợp đồng";
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtPrice.Location = new System.Drawing.Point(107, 267);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(133, 29);
            this.txtPrice.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(254, 274);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 21);
            this.label8.TabIndex = 32;
            this.label8.Text = "VND";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(239, 326);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(138, 43);
            this.btnAdd.TabIndex = 30;
            this.btnAdd.Text = "Lưu";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dtpNgayTaoHD
            // 
            this.dtpNgayTaoHD.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpNgayTaoHD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTaoHD.Location = new System.Drawing.Point(182, 66);
            this.dtpNgayTaoHD.Margin = new System.Windows.Forms.Padding(2);
            this.dtpNgayTaoHD.Name = "dtpNgayTaoHD";
            this.dtpNgayTaoHD.Size = new System.Drawing.Size(151, 29);
            this.dtpNgayTaoHD.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(21, 71);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(158, 21);
            this.label10.TabIndex = 28;
            this.label10.Text = "Ngày tạo hợp đồng:";
            // 
            // lblTypeRoom
            // 
            this.lblTypeRoom.AutoSize = true;
            this.lblTypeRoom.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTypeRoom.Location = new System.Drawing.Point(121, 233);
            this.lblTypeRoom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTypeRoom.Name = "lblTypeRoom";
            this.lblTypeRoom.Size = new System.Drawing.Size(95, 21);
            this.lblTypeRoom.TabIndex = 27;
            this.lblTypeRoom.Text = "Loại phòng";
            // 
            // cbbRoom
            // 
            this.cbbRoom.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbbRoom.FormattingEnabled = true;
            this.cbbRoom.Location = new System.Drawing.Point(122, 194);
            this.cbbRoom.Margin = new System.Windows.Forms.Padding(2);
            this.cbbRoom.Name = "cbbRoom";
            this.cbbRoom.Size = new System.Drawing.Size(151, 28);
            this.cbbRoom.TabIndex = 26;
            this.cbbRoom.SelectedIndexChanged += new System.EventHandler(this.cbbRoom_SelectedIndexChanged);
            // 
            // btnChangeId
            // 
            this.btnChangeId.Image = global::QuanLyPhongTro.Properties.Resources.reload;
            this.btnChangeId.Location = new System.Drawing.Point(239, 32);
            this.btnChangeId.Margin = new System.Windows.Forms.Padding(2);
            this.btnChangeId.Name = "btnChangeId";
            this.btnChangeId.Size = new System.Drawing.Size(18, 20);
            this.btnChangeId.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnChangeId.TabIndex = 25;
            this.btnChangeId.TabStop = false;
            this.btnChangeId.Click += new System.EventHandler(this.btnChangeId_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblID.ForeColor = System.Drawing.Color.Red;
            this.lblID.Location = new System.Drawing.Point(136, 32);
            this.lblID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(72, 21);
            this.lblID.TabIndex = 10;
            this.lblID.Text = "HD9999";
            // 
            // dtpHanThue
            // 
            this.dtpHanThue.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpHanThue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHanThue.Location = new System.Drawing.Point(140, 149);
            this.dtpHanThue.Margin = new System.Windows.Forms.Padding(2);
            this.dtpHanThue.Name = "dtpHanThue";
            this.dtpHanThue.Size = new System.Drawing.Size(151, 29);
            this.dtpHanThue.TabIndex = 9;
            // 
            // dtpNgayThue
            // 
            this.dtpNgayThue.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpNgayThue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayThue.Location = new System.Drawing.Point(140, 107);
            this.dtpNgayThue.Margin = new System.Windows.Forms.Padding(2);
            this.dtpNgayThue.Name = "dtpNgayThue";
            this.dtpNgayThue.Size = new System.Drawing.Size(151, 29);
            this.dtpNgayThue.TabIndex = 8;
            // 
            // cbbTrangThai
            // 
            this.cbbTrangThai.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbbTrangThai.FormattingEnabled = true;
            this.cbbTrangThai.Items.AddRange(new object[] {
            "Đang Hiệu Lực",
            "Hết Hiệu Lực",
            "Đã Hủy"});
            this.cbbTrangThai.Location = new System.Drawing.Point(375, 25);
            this.cbbTrangThai.Margin = new System.Windows.Forms.Padding(2);
            this.cbbTrangThai.Name = "cbbTrangThai";
            this.cbbTrangThai.Size = new System.Drawing.Size(179, 28);
            this.cbbTrangThai.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(274, 32);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 21);
            this.label7.TabIndex = 6;
            this.label7.Text = "Trạng Thái:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(22, 270);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "Giá Thuê:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(22, 233);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Loại Phòng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(20, 194);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số Phòng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(20, 154);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hạn Thuê:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(20, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày Thuê:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(20, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Hợp Đồng:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lsvDetailGuest);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox3.Location = new System.Drawing.Point(28, 275);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(329, 166);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách khách thuê";
            // 
            // lsvDetailGuest
            // 
            this.lsvDetailGuest.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaKhach,
            this.Ten,
            this.VaiTro});
            this.lsvDetailGuest.FullRowSelect = true;
            this.lsvDetailGuest.HideSelection = false;
            this.lsvDetailGuest.Location = new System.Drawing.Point(14, 24);
            this.lsvDetailGuest.Margin = new System.Windows.Forms.Padding(2);
            this.lsvDetailGuest.Name = "lsvDetailGuest";
            this.lsvDetailGuest.Size = new System.Drawing.Size(308, 131);
            this.lsvDetailGuest.TabIndex = 0;
            this.lsvDetailGuest.UseCompatibleStateImageBehavior = false;
            this.lsvDetailGuest.View = System.Windows.Forms.View.Details;
            // 
            // MaKhach
            // 
            this.MaKhach.Text = "Mã Khách";
            // 
            // Ten
            // 
            this.Ten.Text = "Tên Khách";
            this.Ten.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Ten.Width = 150;
            // 
            // VaiTro
            // 
            this.VaiTro.Text = "Vai Trò";
            this.VaiTro.Width = 100;
            // 
            // btnAddGuest
            // 
            this.btnAddGuest.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAddGuest.Location = new System.Drawing.Point(228, 247);
            this.btnAddGuest.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddGuest.Name = "btnAddGuest";
            this.btnAddGuest.Size = new System.Drawing.Size(51, 28);
            this.btnAddGuest.TabIndex = 2;
            this.btnAddGuest.Text = "Thêm";
            this.btnAddGuest.UseVisualStyleBackColor = true;
            this.btnAddGuest.Click += new System.EventHandler(this.btnAddGuest_Click);
            // 
            // btnRemoveGuest
            // 
            this.btnRemoveGuest.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnRemoveGuest.Location = new System.Drawing.Point(284, 247);
            this.btnRemoveGuest.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveGuest.Name = "btnRemoveGuest";
            this.btnRemoveGuest.Size = new System.Drawing.Size(51, 28);
            this.btnRemoveGuest.TabIndex = 3;
            this.btnRemoveGuest.Text = "Loại";
            this.btnRemoveGuest.UseVisualStyleBackColor = true;
            this.btnRemoveGuest.Click += new System.EventHandler(this.btnRemoveGuest_Click);
            // 
            // ContractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(974, 457);
            this.Controls.Add(this.btnRemoveGuest);
            this.Controls.Add(this.btnAddGuest);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "ContractForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contract";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnChangeId)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lsvKhachThue;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbTrangThai;
        private System.Windows.Forms.DateTimePicker dtpNgayThue;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.DateTimePicker dtpHanThue;
        private System.Windows.Forms.PictureBox btnChangeId;
        private System.Windows.Forms.ComboBox cbbRoom;
        private System.Windows.Forms.Label lblTypeRoom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpNgayTaoHD;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lsvDetailGuest;
        private System.Windows.Forms.ColumnHeader MaKhach;
        private System.Windows.Forms.ColumnHeader Ten;
        private System.Windows.Forms.ColumnHeader IDKhach;
        private System.Windows.Forms.ColumnHeader TenKhach;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAddGuest;
        private System.Windows.Forms.Button btnRemoveGuest;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ColumnHeader TrangThai;
        private System.Windows.Forms.ColumnHeader VaiTro;
    }
}