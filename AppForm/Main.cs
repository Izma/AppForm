using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AppForm
{

    public partial class Main : Form
    {
        [DllImport("User32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hand, int message, int wparam, int lparam);

        public Main()
        {
            InitializeComponent();
        }


        private void CollapseButton_Click(object sender, EventArgs e)
        {
            if(MenuLeft.Width==250)
            {
                MenuLeft.Width = 50;
            }
            else
            {
                MenuLeft.Width = 250;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BtnMinimize.Visible = true;
            BtnMaximize.Visible = false;
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal ;
            BtnMinimize.Visible = false;
            BtnMaximize.Visible = true;
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0xA1, 0x2, 0);
        }

        private void LoadFormChild(object childForm)
        {
            if (Container.Controls.Count > 0)
                Container.Controls.RemoveAt(0);
            Form form = childForm as Form;
            form.TopLevel = false;
            Dock = DockStyle.Fill;
            Container.Controls.Add(form);
            Container.Tag = form;
            form.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            LoadFormChild(new Products());
        }
    }
}
