using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Overwatch_Stats_Tracker
{
    public static class Add_Match
    {
        private static List<string> maps = new List<string>();
        private static int selectedmap = 0;
        private static Label lbl_selectedmap;

        private static List<string> groupsize = new List<string>();
        private static int selectedgroupsize = 0;
        private static Label lbl_groupsize;

        private static List<string> heroes = new List<string>();
        private static int selectedhero1 = 0;
        private static int selectedhero2 = 0;
        private static int selectedhero3 = 0;
        private static Label lbl_hero1;
        private static Label lbl_hero2;
        private static Label lbl_hero3;

        private static List<string> times = new List<string>();
        private static int selectedtime = 0;
        private static Label lbl_selectedtime;

        private static TextBox txtbox_win_losses;
        private static TextBox txtbox_sr_change;
        private static TextBox txtbox_rank;
        private static TextBox txtbox_win_lose_streak;

        public static void DrawScene(Panel pnl_background)
        {
            foreach (var item in Enum.GetValues(typeof(Maps)))
            {
                maps.Add(item.ToString());
            }

            foreach (var item in Enum.GetValues(typeof(GroupSize)))
            {
                groupsize.Add(item.ToString());
            }

            heroes.Add("- - - -");
            foreach (var item in Enum.GetValues(typeof(Heroes)))
            {
                heroes.Add(item.ToString());
            }

            foreach (var item in Enum.GetValues(typeof(Times)))
            {
                times.Add(item.ToString());
            }

            pnl_background.Controls.Clear();

            Panel pnl_wins_losses = new Panel { Size = new Size(350,150), Location = new Point(50,50), BorderStyle = BorderStyle.FixedSingle };
            Label lbl_wins_losses_title = new Label { Size = new Size(350, 60), BackColor = Color.FromArgb(155, 0, 155), Text = "Win/Lose/Draw", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            txtbox_win_losses = new TextBox { BackColor = Color.FromArgb(79,79,79), Font = new Font(CustomFont.getFont().Families[0], 40), ForeColor = Color.FromArgb(255, 215, 130), Size = new Size(350,0), Location = new Point(0,75), BorderStyle = BorderStyle.FixedSingle, TextAlign = HorizontalAlignment.Center };
            pnl_wins_losses.Controls.AddRange(new Control[] { lbl_wins_losses_title, txtbox_win_losses });


            Panel pnl_sr_change = new Panel { Size = new Size(350, 150), Location = new Point(440, 50), BorderStyle = BorderStyle.FixedSingle };
            Label lbl_sr_change_title = new Label { Size = new Size(350, 60), BackColor = Color.FromArgb(155, 0, 155), Text = "SR Change", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            txtbox_sr_change = new TextBox { BackColor = Color.FromArgb(79, 79, 79), Font = new Font(CustomFont.getFont().Families[0], 40), ForeColor = Color.FromArgb(255, 215, 130), Size = new Size(350, 0), Location = new Point(0, 75), BorderStyle = BorderStyle.FixedSingle, TextAlign = HorizontalAlignment.Center };
            pnl_sr_change.Controls.AddRange(new Control[] { lbl_sr_change_title, txtbox_sr_change });
            txtbox_sr_change.KeyPress += Txtbox_only_numbers;


            Panel pnl_rank = new Panel { Size = new Size(350, 150), Location = new Point(50, 250), BorderStyle = BorderStyle.FixedSingle };
            Label lbl_rank_title = new Label { Size = new Size(350, 60), BackColor = Color.FromArgb(155, 0, 155), Text = "Current Rank", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            txtbox_rank = new TextBox { BackColor = Color.FromArgb(79, 79, 79), Font = new Font(CustomFont.getFont().Families[0], 40), ForeColor = Color.FromArgb(255, 215, 130), Size = new Size(350, 0), Location = new Point(0, 75), BorderStyle = BorderStyle.FixedSingle, TextAlign = HorizontalAlignment.Center };
            pnl_rank.Controls.AddRange(new Control[] { lbl_rank_title, txtbox_rank });
            txtbox_rank.KeyPress += Txtbox_only_numbers;


            Panel pnl_win_lose_streak = new Panel { Size = new Size(350, 150), Location = new Point(440, 250), BorderStyle = BorderStyle.FixedSingle };
            Label lbl_win_lose_streak_title = new Label { Size = new Size(350, 60), BackColor = Color.FromArgb(155, 0, 155), Text = "Win/Lose Streak", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            txtbox_win_lose_streak = new TextBox { BackColor = Color.FromArgb(79, 79, 79), Font = new Font(CustomFont.getFont().Families[0], 40), ForeColor = Color.FromArgb(255, 215, 130), Size = new Size(350, 0), Location = new Point(0, 75), BorderStyle = BorderStyle.FixedSingle, TextAlign = HorizontalAlignment.Center };
            pnl_win_lose_streak.Controls.AddRange(new Control[] { lbl_win_lose_streak_title, txtbox_win_lose_streak });
            txtbox_win_lose_streak.KeyPress += Txtbox_only_numbers;


            Panel pnl_map_change = new Panel { Size = new Size(350, 150), Location = new Point(50, 450), BorderStyle = BorderStyle.FixedSingle };
            Label lbl_map_change_title = new Label { Size = new Size(350, 60), BackColor = Color.FromArgb(155, 0, 155), Text = "Map", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label lbl_map = new Label { Size = new Size(310, 90), Location = new Point(20, 60), Text = maps[selectedmap].Replace('_',' '), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 30), ForeColor = Color.FromArgb(255, 215, 130) }; lbl_selectedmap = lbl_map;
            Label lbl_map_change_left = new Label { Tag = "left", Cursor = Cursors.Hand, BorderStyle = BorderStyle.FixedSingle, Size = new Size(20, 90), Location = new Point(0,60), Text = "<", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.FromArgb(255, 215, 130) };
            Label lbl_map_change_right = new Label { Tag = "right", Cursor = Cursors.Hand, BorderStyle = BorderStyle.FixedSingle, Size = new Size(20,90), Location = new Point(330,60), Text = ">", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.FromArgb(255, 215, 130) };
            lbl_map_change_left.MouseMove += Lbl_change_MouseMove; lbl_map_change_left.MouseLeave += Lbl_change_MouseLeave;
            lbl_map_change_right.MouseMove += Lbl_change_MouseMove; lbl_map_change_right.MouseLeave += Lbl_change_MouseLeave;
            lbl_map_change_left.Click += Lbl_map_change_Click; lbl_map_change_right.Click += Lbl_map_change_Click;
            pnl_map_change.Controls.AddRange(new Control[] { lbl_map, lbl_map_change_left, lbl_map_change_right, lbl_map_change_title });


            Panel pnl_group_size_change = new Panel { Size = new Size(350, 150), Location = new Point(440, 450), BorderStyle = BorderStyle.FixedSingle };
            Label lbl_group_size_change_title = new Label { Size = new Size(350, 60), BackColor = Color.FromArgb(155, 0, 155), Text = "Group Size", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label lbl_group_size = new Label { Size = new Size(310, 90), Location = new Point(20, 60), Text = groupsize[selectedmap].Replace('_', ' '), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 30), ForeColor = Color.FromArgb(255, 215, 130) }; lbl_groupsize = lbl_group_size;
            Label lbl_group_size_change_left = new Label { Tag = "left", Cursor = Cursors.Hand, BorderStyle = BorderStyle.FixedSingle, Size = new Size(20, 90), Location = new Point(0, 60), Text = "<", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.FromArgb(255, 215, 130) };
            Label lbl_group_size_change_right = new Label { Tag = "right", Cursor = Cursors.Hand, BorderStyle = BorderStyle.FixedSingle, Size = new Size(20, 90), Location = new Point(330, 60), Text = ">", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.FromArgb(255, 215, 130) };
            lbl_group_size_change_left.MouseMove += Lbl_change_MouseMove; lbl_group_size_change_left.MouseLeave += Lbl_change_MouseLeave;
            lbl_group_size_change_right.MouseMove += Lbl_change_MouseMove; lbl_group_size_change_right.MouseLeave += Lbl_change_MouseLeave;
            lbl_group_size_change_left.Click += Lbl_group_change_Click; lbl_group_size_change_right.Click += Lbl_group_change_Click;
            pnl_group_size_change.Controls.AddRange(new Control[] { lbl_group_size, lbl_group_size_change_left, lbl_group_size_change_right, lbl_group_size_change_title });


            Panel pnl_hero_1_change = new Panel { Size = new Size(350, 150), Location = new Point(50, 650), BorderStyle = BorderStyle.FixedSingle };
            Label lbl_hero_1_change_title = new Label { Size = new Size(350, 60), BackColor = Color.FromArgb(155, 0, 155), Text = "Hero 1", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label lbl_hero_1 = new Label { Size = new Size(310, 90), Location = new Point(20, 60), Text = heroes[selectedhero1].Replace('_', ' '), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 30), ForeColor = Color.FromArgb(255, 215, 130) }; lbl_hero1 = lbl_hero_1;
            Label lbl_hero_1_change_left = new Label { Tag = "left", Cursor = Cursors.Hand, BorderStyle = BorderStyle.FixedSingle, Size = new Size(20, 90), Location = new Point(0, 60), Text = "<", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.FromArgb(255, 215, 130) };
            Label lbl_hero_1_change_right = new Label { Tag = "right", Cursor = Cursors.Hand, BorderStyle = BorderStyle.FixedSingle, Size = new Size(20, 90), Location = new Point(330, 60), Text = ">", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.FromArgb(255, 215, 130) };
            lbl_hero_1_change_left.MouseMove += Lbl_change_MouseMove; lbl_hero_1_change_left.MouseLeave += Lbl_change_MouseLeave;
            lbl_hero_1_change_right.MouseMove += Lbl_change_MouseMove; lbl_hero_1_change_right.MouseLeave += Lbl_change_MouseLeave;
            lbl_hero_1_change_left.Click += Lbl_hero_1_change_Click; lbl_hero_1_change_right.Click += Lbl_hero_1_change_Click;
            pnl_hero_1_change.Controls.AddRange(new Control[] { lbl_hero_1_change_title, lbl_hero_1, lbl_hero_1_change_left, lbl_hero_1_change_right });


            Panel pnl_hero_2_change = new Panel { Size = new Size(350, 150), Location = new Point(440, 650), BorderStyle = BorderStyle.FixedSingle };
            Label lbl_hero_2_change_title = new Label { Size = new Size(350, 60), BackColor = Color.FromArgb(155, 0, 155), Text = "Hero 2", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label lbl_hero_2 = new Label { Size = new Size(310, 90), Location = new Point(20, 60), Text = heroes[selectedhero2].Replace('_', ' '), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 30), ForeColor = Color.FromArgb(255, 215, 130) }; lbl_hero2 = lbl_hero_2;
            Label lbl_hero_2_change_left = new Label { Tag = "left", Cursor = Cursors.Hand, BorderStyle = BorderStyle.FixedSingle, Size = new Size(20, 90), Location = new Point(0, 60), Text = "<", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.FromArgb(255, 215, 130) };
            Label lbl_hero_2_change_right = new Label { Tag = "right", Cursor = Cursors.Hand, BorderStyle = BorderStyle.FixedSingle, Size = new Size(20, 90), Location = new Point(330, 60), Text = ">", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.FromArgb(255, 215, 130) };
            lbl_hero_2_change_left.MouseMove += Lbl_change_MouseMove; lbl_hero_2_change_left.MouseLeave += Lbl_change_MouseLeave;
            lbl_hero_2_change_right.MouseMove += Lbl_change_MouseMove; lbl_hero_2_change_right.MouseLeave += Lbl_change_MouseLeave;
            lbl_hero_2_change_left.Click += Lbl_hero_2_change_Click; lbl_hero_2_change_right.Click += Lbl_hero_2_change_Click;
            pnl_hero_2_change.Controls.AddRange(new Control[] { lbl_hero_2_change_title, lbl_hero_2, lbl_hero_2_change_left, lbl_hero_2_change_right });


            Panel pnl_hero_3_change = new Panel { Size = new Size(350, 150), Location = new Point(50, 850), BorderStyle = BorderStyle.FixedSingle };
            Label lbl_hero_3_change_title = new Label { Size = new Size(350, 60), BackColor = Color.FromArgb(155, 0, 155), Text = "Hero 3", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label lbl_hero_3 = new Label { Size = new Size(310, 90), Location = new Point(20, 60), Text = heroes[selectedhero3].Replace('_', ' '), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 30), ForeColor = Color.FromArgb(255, 215, 130) }; lbl_hero3 = lbl_hero_3;
            Label lbl_hero_3_change_left = new Label { Tag = "left", Cursor = Cursors.Hand, BorderStyle = BorderStyle.FixedSingle, Size = new Size(20, 90), Location = new Point(0, 60), Text = "<", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.FromArgb(255, 215, 130) };
            Label lbl_hero_3_change_right = new Label { Tag = "right", Cursor = Cursors.Hand, BorderStyle = BorderStyle.FixedSingle, Size = new Size(20, 90), Location = new Point(330, 60), Text = ">", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.FromArgb(255, 215, 130) };
            lbl_hero_3_change_left.MouseMove += Lbl_change_MouseMove; lbl_hero_3_change_left.MouseLeave += Lbl_change_MouseLeave;
            lbl_hero_3_change_right.MouseMove += Lbl_change_MouseMove; lbl_hero_3_change_right.MouseLeave += Lbl_change_MouseLeave;
            lbl_hero_3_change_left.Click += Lbl_hero_3_change_Click; lbl_hero_3_change_right.Click += Lbl_hero_3_change_Click;
            pnl_hero_3_change.Controls.AddRange(new Control[] { lbl_hero_3_change_title, lbl_hero_3, lbl_hero_3_change_left, lbl_hero_3_change_right });


            Panel pnl_time_change = new Panel { Size = new Size(350, 150), Location = new Point(440, 850), BorderStyle = BorderStyle.FixedSingle };
            Label lbl_time_change_title = new Label { Size = new Size(350, 60), BackColor = Color.FromArgb(155, 0, 155), Text = "Time of day", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.White };
            Label lbl_time = new Label { Size = new Size(310, 90), Location = new Point(20, 60), Text = times[selectedtime].Replace('_', ' '), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 30), ForeColor = Color.FromArgb(255, 215, 130) }; lbl_selectedtime = lbl_time;
            Label lbl_time_change_left = new Label { Tag = "left", Cursor = Cursors.Hand, BorderStyle = BorderStyle.FixedSingle, Size = new Size(20, 90), Location = new Point(0, 60), Text = "<", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.FromArgb(255, 215, 130) };
            Label lbl_time_change_right = new Label { Tag = "right", Cursor = Cursors.Hand, BorderStyle = BorderStyle.FixedSingle, Size = new Size(20, 90), Location = new Point(330, 60), Text = ">", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), ForeColor = Color.FromArgb(255, 215, 130) };
            lbl_time_change_left.MouseMove += Lbl_change_MouseMove; lbl_time_change_left.MouseLeave += Lbl_change_MouseLeave;
            lbl_time_change_right.MouseMove += Lbl_change_MouseMove; lbl_time_change_right.MouseLeave += Lbl_change_MouseLeave;
            lbl_time_change_left.Click += Lbl_time_change_Click; lbl_time_change_right.Click += Lbl_time_change_Click;
            pnl_time_change.Controls.AddRange(new Control[] { lbl_time_change_title, lbl_time, lbl_time_change_left, lbl_time_change_right });


            Label lbl_save = new Label { Cursor = Cursors.Hand, BorderStyle = BorderStyle.FixedSingle, Size = new Size(350, 70), Location = new Point(245, 1060), Text = "Save Game", AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 30), ForeColor = Color.FromArgb(255, 215, 130) };
            lbl_save.MouseMove += Lbl_change_MouseMove; lbl_save.MouseLeave += Lbl_change_MouseLeave;
            lbl_save.Click += Lbl_save_Click;

            Panel empty = new Panel { Location = new Point(0, 1070), BorderStyle = BorderStyle.None, BackColor = Color.FromArgb(79,79,79) };

            pnl_background.Controls.AddRange(new Control[] { empty, lbl_save, pnl_time_change, pnl_hero_3_change, pnl_hero_2_change, pnl_hero_1_change, pnl_group_size_change, pnl_wins_losses, pnl_sr_change, pnl_rank, pnl_win_lose_streak, pnl_map_change });
        }

        private static void Txtbox_only_numbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private static void Lbl_save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private static void Save()
        {
            if (lbl_hero1.Text == "- - - -" && lbl_hero2.Text == "- - - -" && lbl_hero3.Text == "- - - -")
                MessageBox.Show("Pls select atleast 1 Hero");
            else if (txtbox_rank.Text == "")
                MessageBox.Show("Pls insert your Current Rank");
            else if (txtbox_sr_change.Text == "")
                MessageBox.Show("Pls insert your SR Change");
            else if (txtbox_win_lose_streak.Text == "")
                MessageBox.Show("Pls insert your Win/Lose Streak");
            else if (txtbox_win_losses.Text.ToLower() != "win" && txtbox_win_losses.Text.ToLower() != "lose" && txtbox_win_losses.Text.ToLower() != "draw")
                MessageBox.Show("Pls insert if you won(win) the game, lost(lose) it or had a draw(draw)");
            else
            {
                List<Heroes> selectedheroes = new List<Heroes>();
                if (selectedhero1 != 0)
                    selectedheroes.Add(((Heroes)selectedhero1 - 1));
                if (selectedhero2 != 0)
                    selectedheroes.Add(((Heroes)selectedhero2 - 1));
                if(selectedhero3 != 0)
                    selectedheroes.Add(((Heroes)selectedhero3 - 1));

                Maps selmap = (Maps)selectedmap;

                GroupSize group =  GroupSize.One;

                foreach (GroupSize item in Enum.GetValues(typeof(GroupSize)))
                {
                    if (item.ToString() == lbl_groupsize.Text)
                        group = item;
                }

                #region saveherostats

                foreach (var hero in JsonFile.owpt.herostatistics.heroes)
                {
                    foreach (var selheroes in selectedheroes)
                    {
                        if(hero.hero == selheroes)
                        {
                            if (txtbox_win_losses.Text.ToLower() == "win")
                                hero.statistics.wins++;
                            else if (txtbox_win_losses.Text.ToLower() == "lose")
                                hero.statistics.losses++;
                            else if (txtbox_win_losses.Text.ToLower() == "draw")
                                hero.statistics.draws++;
                        }
                    }
                }

                #endregion

                #region savemapstats

                foreach (var map in JsonFile.owpt.mapstatistics.maps)
                {
                    if (map.mapname == selmap)
                    {
                        if (txtbox_win_losses.Text.ToLower() == "win")
                            map.statistics.wins++;
                        else if (txtbox_win_losses.Text.ToLower() == "lose")
                            map.statistics.losses++;
                        else if (txtbox_win_losses.Text.ToLower() == "draw")
                            map.statistics.draws++;
                    }
                }

                #endregion

                #region saveherostatspermap

                foreach (var map in JsonFile.owpt.herostatisticspermap.maps)
                {
                    if(map.mapname == selmap)
                    {
                        foreach (var hero in map.heroes)
                        {
                            foreach (var selhero in selectedheroes)
                            {
                                if(hero.hero == selhero)
                                {
                                    if (txtbox_win_losses.Text.ToLower() == "win")
                                        hero.statistics.wins++;
                                    else if (txtbox_win_losses.Text.ToLower() == "lose")
                                        hero.statistics.losses++;
                                    else if (txtbox_win_losses.Text.ToLower() == "draw")
                                        hero.statistics.draws++;
                                }
                            }
                        }
                    }
                }

                #endregion

                #region saveotherstats

                #region totalstats
                JsonFile.owpt.otherstatistics.totalstatistics.currRank = Convert.ToInt32(txtbox_rank.Text);
                JsonFile.owpt.otherstatistics.totalstatistics.gamesplayed++;
                
                if(txtbox_win_losses.Text.ToLower() == "win")
                {
                    JsonFile.owpt.otherstatistics.totalstatistics.wins++;

                    if (Convert.ToInt32(txtbox_win_lose_streak.Text) > JsonFile.owpt.otherstatistics.totalstatistics.winstreak)
                        JsonFile.owpt.otherstatistics.totalstatistics.winstreak = Convert.ToInt32(txtbox_win_lose_streak.Text);

                    JsonFile.owpt.otherstatistics.totalstatistics.currRank = Convert.ToInt32(txtbox_rank.Text);

                    if (JsonFile.owpt.otherstatistics.totalstatistics.currRank > JsonFile.owpt.otherstatistics.totalstatistics.highestRank)
                        JsonFile.owpt.otherstatistics.totalstatistics.highestRank = JsonFile.owpt.otherstatistics.totalstatistics.currRank;

                    if (JsonFile.owpt.otherstatistics.totalstatistics.highestSRGain < Convert.ToInt32(txtbox_sr_change.Text))
                        JsonFile.owpt.otherstatistics.totalstatistics.highestSRGain = Convert.ToInt32(txtbox_sr_change.Text);

                    if (JsonFile.owpt.otherstatistics.totalstatistics.lowestSRGain > Convert.ToInt32(txtbox_sr_change.Text))
                        JsonFile.owpt.otherstatistics.totalstatistics.lowestSRGain = Convert.ToInt32(txtbox_sr_change.Text);

                    if (JsonFile.owpt.otherstatistics.totalstatistics.lowestRank == 100000)
                        JsonFile.owpt.otherstatistics.totalstatistics.lowestRank = JsonFile.owpt.otherstatistics.totalstatistics.highestRank;
                }
                else if (txtbox_win_losses.Text.ToLower() == "lose")
                {
                    JsonFile.owpt.otherstatistics.totalstatistics.losses++;

                    if (Convert.ToInt32(txtbox_win_lose_streak.Text) > JsonFile.owpt.otherstatistics.totalstatistics.losestreak)
                        JsonFile.owpt.otherstatistics.totalstatistics.losestreak = Convert.ToInt32(txtbox_win_lose_streak.Text);

                    JsonFile.owpt.otherstatistics.totalstatistics.currRank = Convert.ToInt32(txtbox_rank.Text);

                    if (JsonFile.owpt.otherstatistics.totalstatistics.currRank < JsonFile.owpt.otherstatistics.totalstatistics.lowestRank)
                        JsonFile.owpt.otherstatistics.totalstatistics.lowestRank = JsonFile.owpt.otherstatistics.totalstatistics.currRank;

                    if (JsonFile.owpt.otherstatistics.totalstatistics.highestSRLose < Convert.ToInt32(txtbox_sr_change.Text))
                        JsonFile.owpt.otherstatistics.totalstatistics.highestSRLose = Convert.ToInt32(txtbox_sr_change.Text);

                   if (JsonFile.owpt.otherstatistics.totalstatistics.lowestSRLose > Convert.ToInt32(txtbox_sr_change.Text))
                        JsonFile.owpt.otherstatistics.totalstatistics.lowestSRLose = Convert.ToInt32(txtbox_sr_change.Text);

                    if (JsonFile.owpt.otherstatistics.totalstatistics.highestRank == 0)
                        JsonFile.owpt.otherstatistics.totalstatistics.highestRank = JsonFile.owpt.otherstatistics.totalstatistics.lowestRank;

                }
                else if (txtbox_win_losses.Text.ToLower() == "draw")
                {
                    JsonFile.owpt.otherstatistics.totalstatistics.draws++;
                }

                #endregion

                #region groupstats

                foreach (var item in JsonFile.owpt.otherstatistics.groupstatistics)
                {
                    if(item.size == group)
                    {
                        if (txtbox_win_losses.Text.ToLower() == "win")
                            item.wins++;
                        else if (txtbox_win_losses.Text.ToLower() == "lose")
                            item.losses++;
                        else if (txtbox_win_losses.Text.ToLower() == "draw")
                            item.draws++;
                    }
                }

                #endregion

                #region timestats

                foreach (var item in JsonFile.owpt.otherstatistics.timestatistics)
                {
                    if(item.time.ToString() == lbl_selectedtime.Text.Replace(' ','_'))
                    {
                        if (txtbox_win_losses.Text.ToLower() == "win")
                            item.wins++;
                        else if (txtbox_win_losses.Text.ToLower() == "lose")
                            item.losses++;
                        else if (txtbox_win_losses.Text.ToLower() == "draw")
                            item.draws++;
                    }
                }

                #endregion


                #endregion

                JsonFile.save_to_json();
                Reset();
                Saved s = new Saved();
                s.Show();
            }
        }

        private static void Reset()
        {
            selectedhero1 = 0;
            selectedhero2 = 0;
            selectedhero3 = 0;
            selectedtime = 0;
            selectedgroupsize = 0;
            selectedmap = 0;

            lbl_hero1.Text = heroes[selectedhero1].Replace('_', ' ');
            lbl_hero2.Text = heroes[selectedhero2].Replace('_', ' ');
            lbl_hero3.Text = heroes[selectedhero3].Replace('_', ' ');
            lbl_groupsize.Text = groupsize[selectedgroupsize].Replace('_', ' ');
            lbl_selectedmap.Text = maps[selectedmap].Replace('_', ' ');
            lbl_selectedtime.Text = times[selectedtime].Replace('_', ' ');

            txtbox_win_losses.Text = "";
            txtbox_sr_change.Text = "";
            txtbox_rank.Text = "";
            txtbox_win_lose_streak.Text = "";
        }

        private static void Lbl_time_change_Click(object sender, EventArgs e)
        {
            Label l = sender as Label;

            if (l.Tag.ToString() == "left")
            {
                if (selectedtime == 0)
                    selectedtime = times.Count - 1;
                else
                    selectedtime--;
            }
            else if (l.Tag.ToString() == "right")
            {
                if (selectedtime == times.Count - 1)
                    selectedtime = 0;
                else
                    selectedtime++;
            }

            lbl_selectedtime.Text = times[selectedtime].Replace('_', ' ');
        }

        private static void Lbl_hero_3_change_Click(object sender, EventArgs e)
        {
            Label l = sender as Label;

            if (l.Tag.ToString() == "left")
            {
                if (selectedhero3 == 0)
                    selectedhero3 = heroes.Count - 1;
                else
                    selectedhero3--;
            }
            else if (l.Tag.ToString() == "right")
            {
                if (selectedhero3 == heroes.Count - 1)
                    selectedhero3 = 0;
                else
                    selectedhero3++;
            }

            lbl_hero3.Text = heroes[selectedhero3].Replace('_', ' ');
        }

        private static void Lbl_hero_2_change_Click(object sender, EventArgs e)
        {
            Label l = sender as Label;

            if (l.Tag.ToString() == "left")
            {
                if (selectedhero2 == 0)
                    selectedhero2 = heroes.Count - 1;
                else
                    selectedhero2--;
            }
            else if (l.Tag.ToString() == "right")
            {
                if (selectedhero2 == heroes.Count - 1)
                    selectedhero2 = 0;
                else
                    selectedhero2++;
            }

            lbl_hero2.Text = heroes[selectedhero2].Replace('_', ' ');
        }

        private static void Lbl_hero_1_change_Click(object sender, EventArgs e)
        {
            Label l = sender as Label;

            if (l.Tag.ToString() == "left")
            {
                if (selectedhero1 == 0)
                    selectedhero1 = heroes.Count - 1;
                else
                    selectedhero1--;
            }
            else if (l.Tag.ToString() == "right")
            {
                if (selectedhero1 == heroes.Count - 1)
                    selectedhero1 = 0;
                else
                    selectedhero1++;
            }

            lbl_hero1.Text = heroes[selectedhero1].Replace('_', ' ');
        }

        private static void Lbl_group_change_Click(object sender, EventArgs e)
        {
            Label l = sender as Label;

            if (l.Tag.ToString() == "left")
            {
                if (selectedgroupsize == 0)
                    selectedgroupsize = groupsize.Count - 1;
                else
                    selectedgroupsize--;
            }
            else if (l.Tag.ToString() == "right")
            {
                if (selectedgroupsize == groupsize.Count - 1)
                    selectedgroupsize = 0;
                else
                    selectedgroupsize++;
            }

            lbl_groupsize.Text = groupsize[selectedgroupsize].Replace('_', ' ');
        }

        private static void Lbl_map_change_Click(object sender, EventArgs e)
        {
            Label l = sender as Label;

            if(l.Tag.ToString() == "left")
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

            lbl_selectedmap.Text = maps[selectedmap].Replace('_',' ');
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
