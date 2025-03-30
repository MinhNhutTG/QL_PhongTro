namespace QuanLyPhongTro.GUI.Notify
{
    partial class Notifi
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
            this.lblContent = new System.Windows.Forms.Label();
            this.iconNotifi = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconNotifi)).BeginInit();
            this.SuspendLayout();
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblContent.ForeColor = System.Drawing.Color.White;
            this.lblContent.Location = new System.Drawing.Point(60, 18);
            this.lblContent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContent.MaximumSize = new System.Drawing.Size(218, 73);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(199, 32);
            this.lblContent.TabIndex = 1;
            this.lblContent.Text = " label1 la  label1 label1 label1 bel1 label1 ";
            // 
            // iconNotifi
            // 
            this.iconNotifi.Image = global::QuanLyPhongTro.Properties.Resources._checked;
            this.iconNotifi.InitialImage = null;
            this.iconNotifi.Location = new System.Drawing.Point(9, 10);
            this.iconNotifi.Margin = new System.Windows.Forms.Padding(2);
            this.iconNotifi.Name = "iconNotifi";
            this.iconNotifi.Size = new System.Drawing.Size(35, 35);
            this.iconNotifi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconNotifi.TabIndex = 0;
            this.iconNotifi.TabStop = false;
            // 
            // Notifi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(213)))), ((int)(((byte)(2)))));
            this.ClientSize = new System.Drawing.Size(285, 62);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.iconNotifi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Notifi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Notifi";
            ((System.ComponentModel.ISupportInitialize)(this.iconNotifi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox iconNotifi;
        private System.Windows.Forms.Label lblContent;
    }
}