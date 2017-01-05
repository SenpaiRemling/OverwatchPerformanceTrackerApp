using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Overwatch_Stats_Tracker
{
    public static class About
    {
        public static void DrawScene(Panel pnl_background)
        {
            pnl_background.Controls.Clear();

            string aboutText = "Overwatch Performance Tracker is a Tool, developed to help you Tracking your Overwatch Ranked Games.\nWith the Data you Input the Tool will calculate your Perfomance on certain Champions on certain Maps\n with a lot of other factors.\n\n\nThis isnt my Idea, i got the Idea\nfrom the Reddit User: 'MasterDex'\nLink to his Post: https://www.goo.gl/hjS00c \n\n\nIf you got suggestions to Improve the Tool or you found a Bug\nsend me an Email: owperformancetracker@gmail.com";

            Label text = new Label
            {
                Font = new Font(CustomFont.getFont().Families.First(), 30),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(pnl_background.Width - 25, pnl_background.Height + 150),
                Location = new Point(0, 10),
                ForeColor = Color.FromArgb(255, 215, 130),
                Text = aboutText,
            };

            pnl_background.Controls.Add(text);
        }
    }
}
