using System.Drawing;
using System.Windows.Forms;

namespace QuanLyPhongTro.GUI.UC.Room
{
    partial class UC_Rooms
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
            this.lsvRoom = new System.Windows.Forms.ListView();
            this.idRoom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeRoom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusRoom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priceRoom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.noteRoom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imagelist = new System.Windows.Forms.ImageList(this.components);
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.btnRemoveRoom = new System.Windows.Forms.Button();
            this.btnModifyRoom = new System.Windows.Forms.Button();
            this.btnManageTypeRoom = new System.Windows.Forms.Button();
            this.cbbType = new System.Windows.Forms.ComboBox();
            this.cbbStatus = new System.Windows.Forms.ComboBox();
            this.btnLoadCbb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadCbb)).BeginInit();
            this.SuspendLayout();
            // 
            // lsvRoom
            // 
            this.lsvRoom.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lsvRoom.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idRoom,
            this.typeRoom,
            this.statusRoom,
            this.priceRoom,
            this.noteRoom});
            this.lsvRoom.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lsvRoom.FullRowSelect = true;
            this.lsvRoom.GridLines = true;
            this.lsvRoom.HideSelection = false;
            this.lsvRoom.Location = new System.Drawing.Point(21, 88);
            this.lsvRoom.Name = "lsvRoom";
            this.lsvRoom.Size = new System.Drawing.Size(1115, 572);
            this.lsvRoom.SmallImageList = this.imagelist;
            this.lsvRoom.TabIndex = 0;
            this.lsvRoom.UseCompatibleStateImageBehavior = false;
            this.lsvRoom.View = System.Windows.Forms.View.Details;
           
            // 
            // idRoom
            // 
            this.idRoom.Text = "Số phòng";
            this.idRoom.Width = 100;
            // 
            // typeRoom
            // 
            this.typeRoom.Text = "Loại phòng";
            this.typeRoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.typeRoom.Width = 250;
            // 
            // statusRoom
            // 
            this.statusRoom.Text = "Trạng thái";
            this.statusRoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusRoom.Width = 250;
            // 
            // priceRoom
            // 
            this.priceRoom.Text = "Giá phòng";
            this.priceRoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.priceRoom.Width = 200;
            // 
            // noteRoom
            // 
            this.noteRoom.Text = "Ghi chú";
            this.noteRoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.noteRoom.Width = 350;
            // 
            // imagelist
            // 
            this.imagelist.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imagelist.ImageSize = new System.Drawing.Size(1, 30);
            this.imagelist.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddRoom.FlatAppearance.BorderSize = 0;
            this.btnAddRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRoom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAddRoom.ForeColor = System.Drawing.Color.White;
            this.btnAddRoom.Location = new System.Drawing.Point(31, 19);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(145, 37);
            this.btnAddRoom.TabIndex = 1;
            this.btnAddRoom.Text = "Thêm phòng";
            this.btnAddRoom.UseVisualStyleBackColor = false;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // btnRemoveRoom
            // 
            this.btnRemoveRoom.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRemoveRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveRoom.FlatAppearance.BorderSize = 0;
            this.btnRemoveRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveRoom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnRemoveRoom.ForeColor = System.Drawing.Color.White;
            this.btnRemoveRoom.Location = new System.Drawing.Point(358, 19);
            this.btnRemoveRoom.Name = "btnRemoveRoom";
            this.btnRemoveRoom.Size = new System.Drawing.Size(145, 37);
            this.btnRemoveRoom.TabIndex = 2;
            this.btnRemoveRoom.Text = "Xóa phòng";
            this.btnRemoveRoom.UseVisualStyleBackColor = false;
            this.btnRemoveRoom.Click += new System.EventHandler(this.btnRemoveRoom_Click);
            // 
            // btnModifyRoom
            // 
            this.btnModifyRoom.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnModifyRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModifyRoom.FlatAppearance.BorderSize = 0;
            this.btnModifyRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifyRoom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnModifyRoom.ForeColor = System.Drawing.Color.White;
            this.btnModifyRoom.Location = new System.Drawing.Point(194, 19);
            this.btnModifyRoom.Name = "btnModifyRoom";
            this.btnModifyRoom.Size = new System.Drawing.Size(145, 37);
            this.btnModifyRoom.TabIndex = 3;
            this.btnModifyRoom.Text = "Sửa phòng";
            this.btnModifyRoom.UseVisualStyleBackColor = false;
            this.btnModifyRoom.Click += new System.EventHandler(this.btnModifyRoom_Click);
            // 
            // btnManageTypeRoom
            // 
            this.btnManageTypeRoom.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnManageTypeRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManageTypeRoom.FlatAppearance.BorderSize = 0;
            this.btnManageTypeRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageTypeRoom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnManageTypeRoom.ForeColor = System.Drawing.Color.White;
            this.btnManageTypeRoom.Location = new System.Drawing.Point(524, 19);
            this.btnManageTypeRoom.Name = "btnManageTypeRoom";
            this.btnManageTypeRoom.Size = new System.Drawing.Size(145, 37);
            this.btnManageTypeRoom.TabIndex = 4;
            this.btnManageTypeRoom.Text = "Quản lý loại phòng";
            this.btnManageTypeRoom.UseVisualStyleBackColor = false;
            this.btnManageTypeRoom.Click += new System.EventHandler(this.btnManageTypeRoom_Click);
            // 
            // cbbType
            // 
            this.cbbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbbType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbType.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbbType.ForeColor = System.Drawing.Color.Black;
            this.cbbType.FormattingEnabled = true;
            this.cbbType.Items.AddRange(new object[] {
            "-- Tất cả --"});
            this.cbbType.Location = new System.Drawing.Point(772, 29);
            this.cbbType.Name = "cbbType";
            this.cbbType.Size = new System.Drawing.Size(148, 27);
            this.cbbType.TabIndex = 5;
            this.cbbType.SelectedIndexChanged += new System.EventHandler(this.cbbType_SelectedIndexChanged);
            // 
            // cbbStatus
            // 
            this.cbbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbbStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStatus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbbStatus.ForeColor = System.Drawing.Color.Black;
            this.cbbStatus.FormattingEnabled = true;
            this.cbbStatus.Items.AddRange(new object[] {
            "--Trạng thái--",
            "Trống",
            "Đang thuê",
            "Đang sửa chữa"});
            this.cbbStatus.Location = new System.Drawing.Point(941, 29);
            this.cbbStatus.Name = "cbbStatus";
            this.cbbStatus.Size = new System.Drawing.Size(148, 27);
            this.cbbStatus.TabIndex = 6;
            this.cbbStatus.SelectedIndexChanged += new System.EventHandler(this.cbbStatus_SelectedIndexChanged);
            // 
            // btnLoadCbb
            // 
            this.btnLoadCbb.Image = global::QuanLyPhongTro.Properties.Resources.reload;
            this.btnLoadCbb.Location = new System.Drawing.Point(1114, 29);
            this.btnLoadCbb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoadCbb.Name = "btnLoadCbb";
            this.btnLoadCbb.Size = new System.Drawing.Size(22, 24);
            this.btnLoadCbb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLoadCbb.TabIndex = 7;
            this.btnLoadCbb.TabStop = false;
            this.btnLoadCbb.Click += new System.EventHandler(this.btnLoadCbb_Click);
            // 
            // UC_Rooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLoadCbb);
            this.Controls.Add(this.cbbStatus);
            this.Controls.Add(this.cbbType);
            this.Controls.Add(this.btnManageTypeRoom);
            this.Controls.Add(this.btnModifyRoom);
            this.Controls.Add(this.btnRemoveRoom);
            this.Controls.Add(this.btnAddRoom);
            this.Controls.Add(this.lsvRoom);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "UC_Rooms";
            this.Size = new System.Drawing.Size(1231, 712);
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadCbb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvRoom;
        private System.Windows.Forms.ColumnHeader idRoom;
        private System.Windows.Forms.ColumnHeader typeRoom;
        private System.Windows.Forms.ColumnHeader statusRoom;
        private System.Windows.Forms.ColumnHeader noteRoom;
        private ImageList imagelist;
        private ColumnHeader priceRoom;
        private Button btnAddRoom;
        private Button btnRemoveRoom;
        private Button btnModifyRoom;
        private Button btnManageTypeRoom;
        private ComboBox cbbType;
        private ComboBox cbbStatus;
        private PictureBox btnLoadCbb;
    }
}
