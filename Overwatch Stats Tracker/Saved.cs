using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Overwatch_Stats_Tracker
{
    public partial class Saved : Form
    {
        public Saved()
        {
            InitializeComponent();
            label1.Font = new Font(CustomFont.getFont().Families[0], 50);
            label1.ForeColor = Color.FromArgb(79,79,79);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
