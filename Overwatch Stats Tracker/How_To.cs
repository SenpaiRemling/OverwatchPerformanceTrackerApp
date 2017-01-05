using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Overwatch_Stats_Tracker
{
    public static class How_To
    {
        static Label currSel;
        static Label text = new Label();
        static Panel background;

        public static void DrawScene(Panel pnl_background)
        {
            currSel = null;
            pnl_background.Controls.Clear();
            background = pnl_background;

            string[] title = new string[] { "Add Match", "Hero Statistics", "Map Statistics", "Hero Stats Per Map", "Other Statistics" };

            for (int i = 0; i < title.Length; i++)
            {
                Label lbl_title = new Label
                {
                    Tag = i.ToString(),
                    Cursor = Cursors.Hand,
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = title[i], Location = new Point(i * 167, 0),
                    AutoSize = false, Size = new Size(167, 60),
                    BackColor = Color.FromArgb(255, 215, 130),
                    ForeColor = Color.FromArgb(79, 79, 79),
                    Font = new Font(CustomFont.getFont().Families.First(), 20)
                };

                lbl_title.MouseMove += Lbl_change_MouseMove;
                lbl_title.MouseLeave += Lbl_change_MouseLeave;
                lbl_title.Click += Lbl_title_Click;

                pnl_background.Controls.AddRange(new Control[] { lbl_title });

                if (i == 0)
                {
                    currSel = lbl_title;
                    lbl_title.ForeColor = Color.FromArgb(255, 215, 130);
                    lbl_title.BackColor = Color.FromArgb(79,79,79);
                }

            }

            text = new Label { MaximumSize = new Size(830, 0), AutoSize = true, MinimumSize = new Size(830,0), ForeColor = Color.FromArgb(255, 215, 130), TextAlign = ContentAlignment.MiddleCenter, Location = new Point(0,100), Font = new Font(CustomFont.getFont().Families.First(), 25) };
            pnl_background.Controls.Add(text);
            text_addmatch();
        }

        private static void Lbl_title_Click(object sender, EventArgs e)
        {
            Label l = sender as Label;

            if (l.Tag.ToString() != currSel.Tag.ToString())
            {
                l.ForeColor = Color.FromArgb(255, 215, 130);
                l.BackColor = Color.FromArgb(79, 79, 79);

                currSel.BackColor = Color.FromArgb(255, 215, 130);
                currSel.ForeColor = Color.FromArgb(79, 79, 79);

                currSel = l;

                if (currSel.Tag.ToString() == "0")
                    text_addmatch();
                else if (currSel.Tag.ToString() == "1")
                    text_herostats();
                else if (currSel.Tag.ToString() == "2")
                    text_mapstats();
                else if (currSel.Tag.ToString() == "3")
                    text_herostatspermap();
                else if (currSel.Tag.ToString() == "4")
                    text_otherstats();
            }
        }

        private static void text_otherstats()
        {
            text.Text = "___Other Statistics___\n\nOther Statistics is Divided in 3 Categories\n\n-Total Statistics\n-Group Statistics\n-Time Statistics\n\n___Total Statistics___\n\nHere you can find a lot of Different statistics of all Kind.\nFor Example your Total Wins/Loses/draws.\n\n___Group Statistics___\n\nHere you find Statistics about every Group Sizes. \nUse the Arrows on the side to switch Group Size.\nUse right and leftclick to switch through the Group Sizes faster.\n\n___Time Statistics___\n\nHere you find Statistics about every Time. \nUse the Arrows on the side to switch Times.\nUse right and leftclick to switch through the Times faster.\n\n";
        }

        private static void text_herostatspermap()
        {
            text.Text = "___Hero Statistics Per Map___\n\nnHere you see Statistics about every Hero on every Map. Select a Map and Scroll through all the Heroes and the Statistics\n\nUse the Arrows on the side to switch maps.\n\nUse right and leftclick to switch through the maps faster.";
        }

        private static void text_mapstats()
        {
            text.Text = "___Map Statistics___\n\nnHere you see Statistics about every Map.\n\nUse the Arrows on the side to switch maps.\n\nUse right and leftclick to switch through the maps faster.";
        }

        private static void text_herostats()
        {
            text.Text = "___Hero Statistics___\n\nHere you see Statistics about every Hero.\n\nUse the Arrows on the side to switch Heroes.\n\nUse right and leftclick to switch through the Heroes faster.";
        }

        private static void text_addmatch()
        {
            text.Text = "___How to Add a Match?___\n\n\n'Win/Lose/Draw': Here you insert how the Match went. If you won Insert Win, if you lost Insert Lose and if you draw Insert Draw\n\n'SR Change': Here you insert how much SR (or Ranked Points) you got or lost in that Match. You dont need to put a +/-, just insert the Number. if the Match was a draw just Insert 0\n\n'Current Rank': Here you Insert your Curent Rank (SR/Ranked Points)\n\n'Win/Lose Streak': Here you Insert your Current Win/Lose Streak. If you got a Win streak of 10, just Insert 10. Same for a Lose Streak\n\n'Map': Here you Select the Map you played on. Use the Arrows on the side to switch maps. Use right and leftclick to switch through the maps faster\n\n'Group size': Here you select your group size. if you played with alone select 'one' if you played with 1 friend select 'two' and so on. Use the Arrows on the side to switch group sizes. Use right and leftclick to switch through the group sizes faster\n\n'Hero 1-3': Here you Select up to 3 heroes you played that match. Use the Arrows on the side to switch heroes. Use right and leftclick to switch through the heroes faster\n\n'Time of Day': Here you Select the Time of Day the game was played on. Use the Arrows on the side to switch times. Use right and leftclick to switch through the times faster\n\n";
        }

        private static void Lbl_change_MouseLeave(object sender, EventArgs e)
        {
            Label l = sender as Label;

            if(l.Tag.ToString() != currSel.Tag.ToString())
            {
                l.BackColor = Color.FromArgb(255, 215, 130);
                l.ForeColor = Color.FromArgb(79, 79, 79);
            }
        }

        private static void Lbl_change_MouseMove(object sender, MouseEventArgs e)
        {
            Label l = sender as Label;

            if (l.Tag.ToString() != currSel.Tag.ToString())
            {
                l.ForeColor = Color.FromArgb(255, 215, 130);
                l.BackColor = Color.FromArgb(79, 79, 79);
            }
        }

    }
}
