using QuanLyPhongTro.GUI.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro.GUI.Forms
{
    public partial class Login : Form
    {
        UserControl ucLogin = new UC.UC_Login();    
        public Login()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Controls.Add(ucLogin);
        }

     

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
