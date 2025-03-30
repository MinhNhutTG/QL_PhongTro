namespace QuanLyPhongTro.GUI.UC.Config
{
    partial class UC_Config
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
            this.uC_EmailSystem1 = new QuanLyPhongTro.GUI.UC.Config.UC_EmailSystem();
            this.uC_Config_Bank1 = new QuanLyPhongTro.GUI.UC.Config.UC_Config_Bank();
            this.uC_Account1 = new QuanLyPhongTro.GUI.UC.Config.UC_Account();
            this.SuspendLayout();
            // 
            // uC_EmailSystem1
            // 
            this.uC_EmailSystem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.uC_EmailSystem1.Location = new System.Drawing.Point(637, 47);
            this.uC_EmailSystem1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uC_EmailSystem1.Name = "uC_EmailSystem1";
            this.uC_EmailSystem1.Size = new System.Drawing.Size(561, 217);
            this.uC_EmailSystem1.TabIndex = 1;
            // 
            // uC_Config_Bank1
            // 
            this.uC_Config_Bank1.Location = new System.Drawing.Point(25, 46);
            this.uC_Config_Bank1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uC_Config_Bank1.Name = "uC_Config_Bank1";
            this.uC_Config_Bank1.Size = new System.Drawing.Size(562, 219);
            this.uC_Config_Bank1.TabIndex = 0;
            // 
            // uC_Account1
            // 
            this.uC_Account1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.uC_Account1.Location = new System.Drawing.Point(25, 302);
            this.uC_Account1.Name = "uC_Account1";
            this.uC_Account1.Size = new System.Drawing.Size(562, 230);
            this.uC_Account1.TabIndex = 2;
            // 
            // UC_Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uC_Account1);
            this.Controls.Add(this.uC_EmailSystem1);
            this.Controls.Add(this.uC_Config_Bank1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UC_Config";
            this.Size = new System.Drawing.Size(1232, 578);
            this.ResumeLayout(false);

        }

        #endregion

        private UC_Config_Bank uC_Config_Bank1;
        private UC_EmailSystem uC_EmailSystem1;
        private UC_Account uC_Account1;
    }
}
