using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro.GUI.Notify
{
    public partial class Message : Form
    {
        public Message()
        {
            InitializeComponent();
            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
        public Point getPointStart()
        {
            Form parents = Form.ActiveForm;
            Point p = new Point(0, 0);
            if (parents != null)
            {
                p.X = parents.Location.X;
                p.Y = parents.Location.Y;
            }
            return p;
        }
        public static DialogResult Show(string message)
        {
            
            Message msg = new Message();
            msg.Location = msg.getPointStart();
            msg.lblContent.Text = message;
            return msg.ShowDialog();
        }
    }
}
