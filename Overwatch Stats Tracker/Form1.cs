using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Overwatch_Stats_Tracker
{
    public partial class Form1 : Form
    {
        private Panel pnl_menu;

        private Label currSelectedMenuPoint;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CustomFont.Instantiate();

            JsonFile.insertStandartValues();

            lbl_title.Font = new Font(CustomFont.getFont().Families[0],65);

            createMenu();

            pnl_background.HorizontalScroll.Maximum = 0;
            pnl_background.AutoScroll = false;
            pnl_background.VerticalScroll.Visible = false;
            pnl_background.AutoScroll = true;
        }

        #region moveform
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void transpCtrl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        #region close/minimize
        private void label1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

        private void createMenu()
        {
            string[] menupoints = new string[] { "Home", "Add Match", "Hero Statistics", "Map Statistics", "Hero Stats Per Map", "Other Statistics", "How To", "Placeholder", "About" };

            pnl_menu = new Panel { Size = new Size(264, 490), BackColor = Color.FromArgb(255, 215, 130), Location = new Point(0, 110) };

            for (int i = 0; i < menupoints.Length; i++)
            {
                Panel p = new Panel { Size = new Size(264,50), BackColor = Color.Transparent, Location = new Point(1, (i * 50) + 20) };

                Label l = new Label { Tag = i.ToString(), AutoSize = false, Size = p.Size, Text = menupoints[i], Font = new Font(CustomFont.getFont().Families[0],25), TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.FromArgb(79, 79, 79) };

                l.MouseLeave += L_MouseLeave;
                l.MouseMove += L_MouseMove;
                l.Click += L_Click;
                l.Cursor = Cursors.Hand;

                p.Controls.Add(l);

                pnl_menu.Controls.Add(p);

                if (i == 0)
                {
                    currSelectedMenuPoint = l;
                    l.ForeColor = Color.FromArgb(255, 215, 130);
                    p.BackColor = Color.FromArgb(79, 79, 79);
                }
            }

            this.Controls.Add(pnl_menu);

            SceneSelector.loadScene("Home", pnl_background);
        }


        private void L_Click(object sender, EventArgs e)
        {
            Label l = sender as Label;

            if (l.Tag.ToString() != currSelectedMenuPoint.Tag.ToString())
            {
                currSelectedMenuPoint.ForeColor = Color.FromArgb(79, 79, 79);
                currSelectedMenuPoint.Parent.BackColor = Color.FromArgb(255, 215, 130);

                currSelectedMenuPoint = l;

                currSelectedMenuPoint.ForeColor = Color.FromArgb(255, 215, 130);
                currSelectedMenuPoint.Parent.BackColor = Color.FromArgb(79, 79, 79);

                SceneSelector.loadScene(l.Text, pnl_background);
            }
        }

        private void L_MouseMove(object sender, MouseEventArgs e)
        {
            Label l = sender as Label;

            if (l.Tag.ToString() != currSelectedMenuPoint.Tag.ToString())
            {
                l.ForeColor = Color.FromArgb(255, 215, 130);
                l.Parent.BackColor = Color.FromArgb(79, 79, 79);
            }
        }

        private void L_MouseLeave(object sender, EventArgs e)
        {
            Label l = sender as Label;

            if (l.Tag.ToString() != currSelectedMenuPoint.Tag.ToString())
            {
                l.ForeColor = Color.FromArgb(79, 79, 79);
                l.Parent.BackColor = Color.Transparent;
            }
        }

    }
}
