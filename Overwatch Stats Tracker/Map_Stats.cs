using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Overwatch_Stats_Tracker
{
    public static class Map_Stats
    {
        private static Label lbl_map;
        private static int selectedmap = 0;
        private static List<string> maps = new List<string>();
        private static List<Label> statistics = new List<Label>();

        private static Panel background;

        public static void DrawScene(Panel pnl_background)
        {
            selectedmap = 0;
            maps.Clear();
            statistics.Clear();

            background = pnl_background;
            pnl_background.Controls.Clear();

            foreach (var item in Enum.GetValues(typeof(Maps)))
            {
                maps.Add(item.ToString());
            }

            #region heroselection

            Label lbl_selected_map = new Label { BorderStyle = BorderStyle.FixedSingle, Size = new Size(300, 70), Location = new Point(270, 20), Text = maps[selectedmap].Replace('_', ' '), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.FromArgb(255, 215, 130) };
            lbl_map = lbl_selected_map;
            Label lbl_selected_map_change_left = new Label { Tag = "left", Cursor = Cursors.Hand, BorderStyle = BorderStyle.FixedSingle, Size = new Size(20, lbl_selected_map.Height), Location = new Point(lbl_selected_map.Location.X - 20, lbl_selected_map.Location.Y), Text = "<", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.FromArgb(255, 215, 130) };
            Label lbl_selected_map_change_right = new Label { Tag = "right", Cursor = Cursors.Hand, BorderStyle = BorderStyle.FixedSingle, Size = new Size(20, lbl_selected_map.Height), Location = new Point(lbl_selected_map.Location.X + lbl_selected_map.Width, lbl_selected_map.Location.Y), Text = ">", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.FromArgb(255, 215, 130) };
            lbl_selected_map_change_left.MouseMove += Lbl_change_MouseMove; lbl_selected_map_change_left.MouseLeave += Lbl_change_MouseLeave;
            lbl_selected_map_change_right.MouseMove += Lbl_change_MouseMove; lbl_selected_map_change_right.MouseLeave += Lbl_change_MouseLeave;
            lbl_selected_map_change_left.Click += Lbl_map_change_Click; lbl_selected_map_change_right.Click += Lbl_map_change_Click;
            pnl_background.Controls.AddRange(new Control[] { lbl_selected_map, lbl_selected_map_change_left, lbl_selected_map_change_right });

            #endregion

            #region showstats

            Panel pnl_wins = new Panel { Size = new Size(210, 150), Location = new Point(40, 140), BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
            Label pnl_wins_title = new Label { Text = "Wins", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label pnl_wins_text = new Label { Text = "0", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 90), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
            statistics.Add(pnl_wins_text);

            pnl_wins.Controls.AddRange(new Control[] { pnl_wins_text, pnl_wins_title });


            Panel pnl_losses = new Panel { Size = new Size(210, 150), Location = new Point(315, 140), BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
            Label pnl_losses_title = new Label { Text = "Losses", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label pnl_losses_text = new Label { Text = "0", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 90), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
            statistics.Add(pnl_losses_text);

            pnl_losses.Controls.AddRange(new Control[] { pnl_losses_text, pnl_losses_title });


            Panel pnl_draws = new Panel { Size = new Size(210, 150), Location = new Point(590, 140), BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
            Label pnl_draws_title = new Label { Text = "Draws", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label pnl_draws_text = new Label { Text = "0", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 90), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
            statistics.Add(pnl_draws_text);

            pnl_draws.Controls.AddRange(new Control[] { pnl_draws_text, pnl_draws_title });


            Panel pnl_wins_percentage = new Panel { Size = new Size(210, 150), Location = new Point(40, 360), BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
            Label pnl_wins_percentage_title = new Label { Text = "Wins %", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label pnl_wins_percentage_text = new Label { Text = "0%", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 90), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
            statistics.Add(pnl_wins_percentage_text);

            pnl_wins_percentage.Controls.AddRange(new Control[] { pnl_wins_percentage_text, pnl_wins_percentage_title });


            Panel pnl_losses_percentage = new Panel { Size = new Size(210, 150), Location = new Point(315, 360), BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
            Label pnl_losses_percentage_title = new Label { Text = "Losses %", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label pnl_losses_percentage_text = new Label { Text = "0%", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 90), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
            statistics.Add(pnl_losses_percentage_text);

            pnl_losses_percentage.Controls.AddRange(new Control[] { pnl_losses_percentage_text, pnl_losses_percentage_title });


            Panel pnl_draws_percentage = new Panel { Size = new Size(210, 150), Location = new Point(590, 360), BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
            Label pnl_draws_percentage_title = new Label { Text = "Draws %", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label pnl_draws_percentage_text = new Label { Text = "0%", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 90), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
            statistics.Add(pnl_draws_percentage_text);

            pnl_draws_percentage.Controls.AddRange(new Control[] { pnl_draws_percentage_text, pnl_draws_percentage_title });


            Panel pnl_total_games = new Panel { Size = new Size(210, 150), Location = new Point(40, 580), BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
            Label pnl_total_games_title = new Label { Text = "Total Games", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label pnl_total_games_text = new Label { Text = "0", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 90), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
            statistics.Add(pnl_total_games_text);

            pnl_total_games.Controls.AddRange(new Control[] { pnl_total_games_text, pnl_total_games_title });


            Panel pnl_best_hero = new Panel { Size = new Size(210, 150), Location = new Point(315, 580), BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
            Label pnl_best_hero_title = new Label { Text = "Best hero", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label pnl_best_hero_text = new Label { Text = "- - - -", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 90), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
            statistics.Add(pnl_best_hero_text);

            pnl_best_hero.Controls.AddRange(new Control[] { pnl_best_hero_text, pnl_best_hero_title });


            Panel pnl_worst_hero = new Panel { Size = new Size(210, 150), Location = new Point(590, 580), BackColor = Color.FromArgb(79, 79, 79), BorderStyle = BorderStyle.FixedSingle };
            Label pnl_worst_hero_title = new Label { Text = "Worst hero", BackColor = Color.FromArgb(155, 0, 155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label pnl_worst_hero_text = new Label { Text = "- - - -", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 90), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
            statistics.Add(pnl_worst_hero_text);

            pnl_worst_hero.Controls.AddRange(new Control[] { pnl_worst_hero_text, pnl_worst_hero_title });


            Panel empty = new Panel { Location = new Point(0, 760), Size = new Size(1, 1) };

            pnl_background.Controls.AddRange(new Control[] { empty, pnl_worst_hero, pnl_best_hero, pnl_total_games, pnl_draws_percentage, pnl_losses_percentage, pnl_wins_percentage, pnl_draws, pnl_losses, pnl_wins });

            showStats(maps[selectedmap]);
            #endregion
        }

        private static void showStats(string map)
        {
            foreach (var item in JsonFile.owpt.mapstatistics.maps)
            {
                if (item.mapname.ToString() == maps[selectedmap])
                {
                    int totalgames = item.statistics.wins + item.statistics.losses + item.statistics.draws;

                    if (totalgames > 0)
                    {
                        statistics[0].Text = item.statistics.wins.ToString();
                        statistics[1].Text = item.statistics.losses.ToString();
                        statistics[2].Text = item.statistics.draws.ToString();

                        statistics[3].Text = Math.Round((double)(item.statistics.wins * 100) / totalgames, 0).ToString() + "%";
                        statistics[4].Text = Math.Round((double)(item.statistics.losses * 100) / totalgames, 0).ToString() + "%";
                        statistics[5].Text = Math.Round((double)(item.statistics.draws * 100) / totalgames, 0).ToString() + "%";

                        statistics[6].Text = totalgames.ToString();
                    }
                    else
                    {
                        statistics[0].Text = "0";
                        statistics[1].Text = "0";
                        statistics[2].Text = "0";

                        statistics[3].Text = "0%";
                        statistics[4].Text = "0%";
                        statistics[5].Text = "0%";

                        statistics[6].Text = "0";
                    }

                    int currbest = 0;
                    int currworst = 100;
                    string herobest = "- - - -";
                    string heroworst = "- - - -";

                    foreach (var item2 in JsonFile.owpt.herostatisticspermap.maps)
                    {
                        if (item2.mapname.ToString() == maps[selectedmap])
                        {
                            foreach (var item3 in item2.heroes)
                            {
                                int games = item3.statistics.wins + item3.statistics.losses + item3.statistics.draws;
                                int winrate = (int)Math.Round((double)(item3.statistics.wins * 100) / games, 0);

                                if (games > 0)
                                {
                                    if (currbest < winrate)
                                    {
                                        currbest = winrate;
                                        herobest = item3.hero.ToString();
                                    }
                                    if (currworst > winrate)
                                    {
                                        currworst = winrate;
                                        heroworst = item3.hero.ToString();
                                    }
                                }
                            }
                            break;
                        }
                    }

                    statistics[7].Text = herobest.Replace('_', ' ');
                    statistics[8].Text = heroworst.Replace('_', ' ');


                    break;
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
