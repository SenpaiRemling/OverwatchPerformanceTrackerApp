using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Overwatch_Stats_Tracker
{
    public static class Other_Stats
    {
        static Label currSelected;
        static List<Label> menubar = new List<Label>();
        static Panel background;
        static List<Control> controls = new List<Control>();

        public static void DrawScene(Panel pnl_background)
        {
            currSelected = null;
            menubar.Clear();

            pnl_background.Controls.Clear();
            background = pnl_background;

            Label lbl_totalstats = new Label {Tag = "1", Cursor = Cursors.Hand, Location = new Point(0,0), BorderStyle = BorderStyle.FixedSingle, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families[0], 30), ForeColor = Color.FromArgb(255, 215, 130), BackColor = Color.FromArgb(79,79,79), Text = "Total Statistics", AutoSize = false, Size = new Size(279,60) };
            lbl_totalstats.MouseLeave += Lbl_change_MouseLeave;
            lbl_totalstats.MouseMove += Lbl_change_MouseMove;
            lbl_totalstats.Click += Lbl_Click;
            currSelected = lbl_totalstats;
            menubar.Add(lbl_totalstats);

            Label lbl_groupstats = new Label { Tag = "2", Cursor = Cursors.Hand, Location = new Point(279, 0), BorderStyle = BorderStyle.FixedSingle, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families[0], 30), ForeColor = Color.FromArgb(79, 79, 79), BackColor = Color.FromArgb(255, 215, 130), Text = "Group Statistics", AutoSize = false, Size = new Size(279, 60) };
            lbl_groupstats.MouseLeave += Lbl_change_MouseLeave;
            lbl_groupstats.MouseMove += Lbl_change_MouseMove;
            lbl_groupstats.Click += Lbl_Click;
            menubar.Add(lbl_groupstats);

            Label lbl_timestats = new Label { Tag = "3", Cursor = Cursors.Hand, Location = new Point(558, 0), BorderStyle = BorderStyle.FixedSingle, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families[0], 30), ForeColor = Color.FromArgb(79, 79, 79), BackColor = Color.FromArgb(255, 215, 130), Text = "Time Statistics", AutoSize = false, Size = new Size(279, 60) };
            lbl_timestats.MouseLeave += Lbl_change_MouseLeave;
            lbl_timestats.MouseMove += Lbl_change_MouseMove;
            lbl_timestats.Click += Lbl_Click;
            menubar.Add(lbl_timestats);

            pnl_background.Controls.AddRange(new Control[] { lbl_timestats, lbl_groupstats, lbl_totalstats });

            drawtotalstats();
        }


        private static void drawtotalstats()
        {
            clearcontrols();
            OtherStatistics_TotalStatistics stats = JsonFile.owpt.otherstatistics.totalstatistics;

            Label lbl_totalwins = new Label { TextAlign = ContentAlignment.MiddleCenter, Text = "Games Played: " + stats.gamesplayed.ToString(), Location = new Point(170, 100), AutoSize = false, Size = new Size(500, 60), BackColor = Color.FromArgb(255, 215, 130), ForeColor = Color.FromArgb(79, 79, 79), Font = new Font(CustomFont.getFont().Families.First(), 40) };


            Panel p = new Panel { Size = new Size(210, 150), Location = new Point(40, 200), BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
            Label title = new Label { Text = "Wins", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label text = new Label { Text = stats.wins.ToString(), ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 50), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
            Label l = new Label { Text = Math.Round((double)(stats.wins * 100) / stats.gamesplayed,0).ToString() + "% Winrate", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 30), Location = new Point(0, 110), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 15), };

            p.Controls.AddRange(new Control[] { title, text, l });

            Panel p1 = new Panel { Size = new Size(210, 150), Location = new Point(315, 200), BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
            Label title1 = new Label { Text = "Losses", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label text1 = new Label { Text = stats.losses.ToString(), ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 50), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
            Label l1 = new Label { Text = Math.Round((double)(stats.losses * 100) / stats.gamesplayed, 0).ToString() + "% Loserate", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 30), Location = new Point(0, 110), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 15), };

            p1.Controls.AddRange(new Control[] { title1, text1, l1 });

            Panel p2 = new Panel { Size = new Size(210, 150), Location = new Point(585, 200), BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
            Label title2 = new Label { Text = "Draws", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label text2 = new Label { Text = stats.draws.ToString(), ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 50), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
            Label l2 = new Label { Text = Math.Round((double)(stats.draws * 100) / stats.gamesplayed, 0).ToString() + "% Drawrate", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 30), Location = new Point(0, 110), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 15), };

            p2.Controls.AddRange(new Control[] { title2, text2, l2 });


            Panel p3 = new Panel { Size = new Size(210, 150), Location = new Point(178, 400), BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
            Label title3 = new Label { Text = "Highest Winstreak", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 23), ForeColor = Color.White };
            Label text3 = new Label { Text = stats.winstreak.ToString(), ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 90), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 40), };
            p3.Controls.AddRange(new Control[] { title3, text3 });

            Panel p4 = new Panel { Size = new Size(210, 150), Location = new Point(453, 400), BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
            Label title4 = new Label { Text = "Highest Losestreak", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 23), ForeColor = Color.White };
            Label text4 = new Label { Text = stats.losestreak.ToString(), ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 90), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 40), };
            p4.Controls.AddRange(new Control[] { title4, text4 });


            Label lbl_currRank = new Label { TextAlign = ContentAlignment.MiddleCenter, Text = "Current Rank: " + stats.currRank.ToString(), Location = new Point(170, 600), AutoSize = false, Size = new Size(500, 60), BackColor = Color.FromArgb(255, 215, 130), ForeColor = Color.FromArgb(79, 79, 79), Font = new Font(CustomFont.getFont().Families.First(), 40) };


            Panel p5 = new Panel { Size = new Size(210, 150), Location = new Point(178, 710), BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
            Label title5 = new Label { Text = "Highest SR Gain", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label text5 = new Label { Text = stats.highestSRGain.ToString(), ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 90), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 40), };
            p5.Controls.AddRange(new Control[] { title5, text5, });

            Panel p6 = new Panel { Size = new Size(210, 150), Location = new Point(453, 710), BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
            Label title6 = new Label { Text = "Lowest SR Gain", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label text6 = new Label { Text = (stats.lowestSRGain != 100000) ? stats.lowestSRGain.ToString() : "0", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 90), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 40), };
            p6.Controls.AddRange(new Control[] { title6, text6, });

            Panel p7 = new Panel { Size = new Size(210, 150), Location = new Point(178, 910), BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
            Label title7 = new Label { Text = "Highest SR Lose", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label text7 = new Label { Text = stats.highestSRLose.ToString(), ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 90), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 40), };
            p7.Controls.AddRange(new Control[] { title7, text7, });

            Panel p8 = new Panel { Size = new Size(210, 150), Location = new Point(453, 910), BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
            Label title8 = new Label { Text = "Lowest SR Lose", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label text8 = new Label { Text = (stats.lowestSRLose != 100000) ? stats.lowestSRLose.ToString() : "0", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 90), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 40), };
            p8.Controls.AddRange(new Control[] { title8, text8, });

            Panel p9 = new Panel { Size = new Size(210, 150), Location = new Point(178, 1110), BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
            Label title9 = new Label { Text = "Highest Rank", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label text9 = new Label { Text = stats.highestRank.ToString(), ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 90), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 40), };
            p9.Controls.AddRange(new Control[] { title9, text9, });

            Panel p10 = new Panel { Size = new Size(210, 150), Location = new Point(453, 1110), BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
            Label title10 = new Label { Text = "Lowest Rank", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label text10 = new Label { Text = (stats.lowestRank != 100000) ? stats.lowestRank.ToString() : "0", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 90), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 40), };
            p10.Controls.AddRange(new Control[] { title10, text10, });

            background.Controls.AddRange(new Control[] { p, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, lbl_totalwins, lbl_currRank });
            controls.AddRange(new Control[] { p, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, lbl_totalwins, lbl_currRank });
        }


        private static void drawgroupstatistics()
        {
            clearcontrols();

            List<OtherStatistics_GroupStatistics> stats = JsonFile.owpt.otherstatistics.groupstatistics;

            Point title_pos = new Point(170, 100);
            Point stats_pos = new Point(40, 200);

            foreach (var item in stats)
            {
                int totalgames = item.wins + item.draws + item.losses;
                Label lbl_time = new Label { TextAlign = ContentAlignment.MiddleCenter, Text = "Groupesize of " + item.size.ToString().Replace('_', ' '), Location = title_pos, AutoSize = false, Size = new Size(500, 60), BackColor = Color.FromArgb(255, 215, 130), ForeColor = Color.FromArgb(79, 79, 79), Font = new Font(CustomFont.getFont().Families.First(), 40) };

                Panel p1 = new Panel { Size = new Size(210, 150), Location = stats_pos, BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
                Label title1 = new Label { Text = "Wins", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
                Label text1 = new Label { Text = item.wins.ToString(), ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 48), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
                Label l1 = new Label { Text = (totalgames != 0) ? Math.Round((double)(item.wins * 100) / totalgames,0) +  "% / " + totalgames + " Games" : "0% /0 Games", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 30), Location = new Point(0, 110), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 15), };

                p1.Controls.AddRange(new Control[] { title1, text1, l1 });

                stats_pos.X += 275;
                Panel p2 = new Panel { Size = new Size(210, 150), Location = stats_pos, BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
                Label title2 = new Label { Text = "Losses", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
                Label text2 = new Label { Text = item.losses.ToString(), ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 48), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
                Label l2 = new Label { Text = (totalgames != 0) ? Math.Round((double)(item.losses * 100) / totalgames, 0) + "% / " + totalgames + " Games" : "0% /0 Games", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 30), Location = new Point(0, 110), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 15), };

                p2.Controls.AddRange(new Control[] { title2, text2, l2 });

                stats_pos.X += 275;
                Panel p3 = new Panel { Size = new Size(210, 150), Location = stats_pos, BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
                Label title3 = new Label { Text = "Draws", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
                Label text3 = new Label { Text = item.draws.ToString(), ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 48), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
                Label l3 = new Label { Text = (totalgames != 0) ? Math.Round((double)(item.draws * 100) / totalgames, 0) + "% / " + totalgames + " Games" : "0% /0 Games", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 30), Location = new Point(0, 110), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 15), };

                p3.Controls.AddRange(new Control[] { title3, text3, l3 });

                background.Controls.AddRange(new Control[] { p1, p2, p3, lbl_time });
                controls.AddRange(new Control[] { lbl_time, p1, p2, p3 });

                title_pos.Y = stats_pos.Y + 190;
                stats_pos.X = 40;
                stats_pos.Y = title_pos.Y + 90;
            }
        }

        private static void drawtimestatistics()
        {
            clearcontrols();

            List<OtherStatistics_TimeStatistics> stats = JsonFile.owpt.otherstatistics.timestatistics;

            Point title_pos = new Point(170, 100);
            Point stats_pos = new Point(40, 200);

            foreach (var item in stats)
            {
                int totalgames = item.wins + item.draws + item.losses;
                Label lbl_time = new Label { TextAlign = ContentAlignment.MiddleCenter, Text = item.time.ToString().Replace('_', ' '), Location = title_pos, AutoSize = false, Size = new Size(500, 60), BackColor = Color.FromArgb(255, 215, 130), ForeColor = Color.FromArgb(79, 79, 79), Font = new Font(CustomFont.getFont().Families.First(), 40) };

                Panel p1 = new Panel { Size = new Size(210, 150), Location = stats_pos, BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
                Label title1 = new Label { Text = "Wins", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
                Label text1 = new Label { Text = item.wins.ToString(), ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 48), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
                Label l1 = new Label { Text = (totalgames != 0) ? Math.Round((double)(item.wins * 100) / totalgames, 0) + "% / " + totalgames + " Games" : "0% /0 Games", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 30), Location = new Point(0, 110), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 15), };

                p1.Controls.AddRange(new Control[] { title1, text1, l1 });

                stats_pos.X += 275;
                Panel p2 = new Panel { Size = new Size(210, 150), Location = stats_pos, BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
                Label title2 = new Label { Text = "Losses", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
                Label text2 = new Label { Text = item.losses.ToString(), ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 48), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
                Label l2 = new Label { Text = (totalgames != 0) ? Math.Round((double)(item.losses * 100) / totalgames, 0) + "% / " + totalgames + " Games" : "0% /0 Games", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 30), Location = new Point(0, 110), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 15), };

                p2.Controls.AddRange(new Control[] { title2, text2, l2 });

                stats_pos.X += 275;
                Panel p3 = new Panel { Size = new Size(210, 150), Location = stats_pos, BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
                Label title3 = new Label { Text = "Draws", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
                Label text3 = new Label { Text = item.draws.ToString(), ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 48), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
                Label l3 = new Label { Text = (totalgames != 0) ? Math.Round((double)(item.draws * 100) / totalgames, 0) + "% / " + totalgames + " Games" : "0% /0 Games", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 30), Location = new Point(0, 110), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 15), };

                p3.Controls.AddRange(new Control[] { title3, text3, l3 });

                background.Controls.AddRange(new Control[] { p1, p2, p3, lbl_time });
                controls.AddRange(new Control[] { lbl_time, p1, p2, p3 });

                title_pos.Y = stats_pos.Y + 190;
                stats_pos.X = 40;
                stats_pos.Y = title_pos.Y + 90;
            }
        }

        private static void clearcontrols()
        {
            foreach (var item in controls)
            {
                background.Controls.Remove(item);
            }
        }


        private static void Lbl_Click(object sender, EventArgs e)
        {
            Label l = sender as Label;

            if (l.Tag.ToString() != currSelected.Tag.ToString())
            {
                l.ForeColor = Color.FromArgb(255, 215, 130);
                l.BackColor = Color.FromArgb(79, 79, 79);
                currSelected.BackColor = Color.FromArgb(255, 215, 130);
                currSelected.ForeColor = Color.FromArgb(79, 79, 79);
                currSelected = l;

                if (currSelected.Tag.ToString() == "1")
                    drawtotalstats();
                else if (currSelected.Tag.ToString() == "2")
                    drawgroupstatistics();
                else if (currSelected.Tag.ToString() == "3")
                    drawtimestatistics();
            }
        }

        private static void Lbl_change_MouseLeave(object sender, EventArgs e)
        {
            Label l = sender as Label;

            if(l.Tag.ToString() != currSelected.Tag.ToString())
            {
                l.BackColor = Color.FromArgb(255, 215, 130);
                l.ForeColor = Color.FromArgb(79, 79, 79);
            }

        }

        private static void Lbl_change_MouseMove(object sender, MouseEventArgs e)
        {
            Label l = sender as Label;

            if (l.Tag.ToString() != currSelected.Tag.ToString())
            {
                l.ForeColor = Color.FromArgb(255, 215, 130);
                l.BackColor = Color.FromArgb(79, 79, 79);
            }

        }



    }
}