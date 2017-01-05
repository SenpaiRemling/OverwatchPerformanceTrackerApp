using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Overwatch_Stats_Tracker
{
    public static class Hero_Stats_Per_Map
    {
        private static Label lbl_map;
        private static int selectedmap = 0;
        private static List<string> maps = new List<string>();

        private static List<string> heroes = new List<string>();

        private static List<List<Label>> statistics = new List<List<Label>>();

        private static Panel background;


        public static void DrawScene(Panel pnl_background)
        {
            selectedmap = 0;
            maps.Clear();
            statistics.Clear();
            heroes.Clear();

            background = pnl_background;
            pnl_background.Controls.Clear();

            foreach (var item in Enum.GetValues(typeof(Maps)))
            {
                maps.Add(item.ToString());
            }


            foreach (var item in Enum.GetValues(typeof(Heroes)))
            {
                heroes.Add(item.ToString());
            }

            Label lbl_selected_map = new Label { BorderStyle = BorderStyle.FixedSingle, Size = new Size(300, 70), Location = new Point(270, 20), Text = maps[selectedmap].Replace('_', ' '), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.FromArgb(255, 215, 130) };
            lbl_map = lbl_selected_map;
            Label lbl_selected_map_change_left = new Label { Tag = "left", Cursor = Cursors.Hand, BorderStyle = BorderStyle.FixedSingle, Size = new Size(20, lbl_selected_map.Height), Location = new Point(lbl_selected_map.Location.X - 20, lbl_selected_map.Location.Y), Text = "<", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.FromArgb(255, 215, 130) };
            Label lbl_selected_map_change_right = new Label { Tag = "right", Cursor = Cursors.Hand, BorderStyle = BorderStyle.FixedSingle, Size = new Size(20, lbl_selected_map.Height), Location = new Point(lbl_selected_map.Location.X + lbl_selected_map.Width, lbl_selected_map.Location.Y), Text = ">", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.FromArgb(255, 215, 130) };
            lbl_selected_map_change_left.MouseMove += Lbl_change_MouseMove; lbl_selected_map_change_left.MouseLeave += Lbl_change_MouseLeave;
            lbl_selected_map_change_right.MouseMove += Lbl_change_MouseMove; lbl_selected_map_change_right.MouseLeave += Lbl_change_MouseLeave;
            lbl_selected_map_change_left.Click += Lbl_map_change_Click; lbl_selected_map_change_right.Click += Lbl_map_change_Click;
            pnl_background.Controls.AddRange(new Control[] { lbl_selected_map, lbl_selected_map_change_left, lbl_selected_map_change_right });

            Point title_pos = new Point(170,140);
            Point stats_pos = new Point(40, 230);

            for (int i = 0; i < heroes.Count; i++)
            {
                Label lbl_hero = new Label { TextAlign = ContentAlignment.MiddleCenter, Text = heroes[i].Replace('_',' '), Location = title_pos, AutoSize = false, Size = new Size(500, 60), BackColor = Color.FromArgb(255, 215, 130), ForeColor = Color.FromArgb(79,79,79), Font = new Font(CustomFont.getFont().Families.First(), 40) };

                Panel p1 = new Panel { Size = new Size(210, 150), Location = stats_pos, BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
                Label title1 = new Label { Text = "Wins", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
                Label text1 = new Label { Text = "0", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 50), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
                Label l1 = new Label { Text = "0% / 0 Games", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 30), Location = new Point(0, 110), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 15), };

                p1.Controls.AddRange(new Control[] { title1, text1, l1 });

                stats_pos.X += 275;
                Panel p2 = new Panel { Size = new Size(210, 150), Location = stats_pos, BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
                Label title2 = new Label { Text = "Losses", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
                Label text2 = new Label { Text = "0", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 50), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
                Label l2 = new Label { Text = "0% / 0 Games", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 30), Location = new Point(0, 110), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 15), };

                p2.Controls.AddRange(new Control[] { title2, text2, l2 });

                stats_pos.X += 275;
                Panel p3 = new Panel { Size = new Size(210, 150), Location = stats_pos, BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
                Label title3 = new Label { Text = "Draws", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
                Label text3 = new Label { Text = "0", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 50), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
                Label l3 = new Label { Text = "0% / 0 Games", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 30), Location = new Point(0, 110), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 15), };

                p3.Controls.AddRange(new Control[] { title3, text3, l3 });
                pnl_background.Controls.AddRange(new Control[] { p2, p3, p1, lbl_hero });

                statistics.Add(new List<Label> { text1, l1, text2, l2, text3, l3, });

                title_pos.Y = stats_pos.Y + 190;
                stats_pos.X = 40;
                stats_pos.Y = title_pos.Y + 90;
            }

            Panel empty = new Panel { Size = new Size(1,1), Location = title_pos };
            pnl_background.Controls.Add(empty);
            showStats(maps[selectedmap]);
        }

        private static void showStats(string map)
        {
            foreach (var item in JsonFile.owpt.herostatisticspermap.maps)
            {
                if(item.mapname.ToString() == map)
                {
                    int i = 0;
                    foreach (var hero in heroes)
                    {
                        int totalgames = item.heroes[i].statistics.wins + item.heroes[i].statistics.losses + item.heroes[i].statistics.draws;

                        if (totalgames > 0)
                        {
                            statistics[i][0].Text = item.heroes[i].statistics.wins.ToString();
                            statistics[i][1].Text = Math.Round((double)(item.heroes[i].statistics.wins * 100) / totalgames).ToString() + "% / " + totalgames + " Games";
                            statistics[i][2].Text = item.heroes[i].statistics.losses.ToString();
                            statistics[i][3].Text = Math.Round((double)(item.heroes[i].statistics.losses * 100) / totalgames).ToString() + "% / " + totalgames + " Games";
                            statistics[i][4].Text = item.heroes[i].statistics.draws.ToString();
                            statistics[i][5].Text = Math.Round((double)(item.heroes[i].statistics.draws * 100) / totalgames).ToString() + "% / " + totalgames + " Games";
                        }
                        else
                        {
                            statistics[i][0].Text = "0";
                            statistics[i][1].Text = "0% / 0";
                            statistics[i][2].Text = "0";
                            statistics[i][3].Text = "0% / 0";
                            statistics[i][4].Text = "0";
                            statistics[i][5].Text = "0% / 0";
                        }

                        i++;
                    }
                }
            }
        }

        private static void Lbl_map_change_Click(object sender, EventArgs e)
        {
            Label l = sender as Label;

            if (l.Tag.ToString() == "left")
            {
                if (selectedmap == 0)
                    selectedmap = maps.Count - 1;
                else
                    selectedmap--;
            }
            else if (l.Tag.ToString() == "right")
            {
                if (selectedmap == maps.Count - 1)
                    selectedmap = 0;
                else
                    selectedmap++;
            }

            lbl_map.Text = maps[selectedmap].Replace('_', ' ');
            showStats(maps[selectedmap]);
        }



        private static void Lbl_change_MouseLeave(object sender, EventArgs e)
        {
            Label l = sender as Label;

            l.ForeColor = Color.FromArgb(255, 215, 130);
            l.BackColor = Color.FromArgb(79, 79, 79);
        }

        private static void Lbl_change_MouseMove(object sender, MouseEventArgs e)
        {
            Label l = sender as Label;

            l.BackColor = Color.FromArgb(255, 215, 130);
            l.ForeColor = Color.FromArgb(79, 79, 79);
        }
    }
}
