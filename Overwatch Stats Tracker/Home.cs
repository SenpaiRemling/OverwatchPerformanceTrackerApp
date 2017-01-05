using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Overwatch_Stats_Tracker
{
    public static class Home
    {
        private static string[] getstats()
        {
            string[] stats = new string[6];

            int highest = 0;
            string hero = "- - - -";
            string map = "- - - -";
            string groupsize = "- - - -";
            string time = "- - - -";

            int totalgames = 0;

            int games = 0;

            foreach (var item in JsonFile.owpt.herostatistics.heroes)
            {
                totalgames = item.statistics.wins + item.statistics.draws + item.statistics.losses;

                if (totalgames != 0)
                {
                    double winrate = Math.Round((double)((item.statistics.wins * 100) / totalgames), 0);

                    if (winrate >= highest)
                    {
                        highest = (int)winrate;
                        hero = item.hero.ToString();
                        games = totalgames;
                    }
                }
            }
            stats[0] = hero + "/" + highest + "/" + games;

            highest = 0;
            foreach (var item in JsonFile.owpt.mapstatistics.maps)
            {
                totalgames = item.statistics.wins + item.statistics.draws + item.statistics.losses;

                if (totalgames != 0)
                {
                    double winrate = Math.Round((double)((item.statistics.wins * 100) / totalgames), 0);

                    if (winrate >= highest)
                    {
                        highest = (int)winrate;
                        map = item.mapname.ToString();
                        games = totalgames;
                    }
                }
            }
            stats[1] = map + "/" + highest + "/" + games;

            highest = 0;
            foreach (var item in JsonFile.owpt.otherstatistics.groupstatistics)
            {
                totalgames = item.wins + item.draws + item.losses;

                if (totalgames != 0)
                {
                    double winrate = Math.Round((double)((item.wins * 100) / totalgames), 0);

                    if (winrate >= highest)
                    {
                        highest = (int)winrate;
                        groupsize = item.size.ToString();
                        games = totalgames;
                    }
                }
            }
            stats[2] = groupsize + "/" + highest + "/" + games;


            highest = 0;
            foreach (var item in JsonFile.owpt.otherstatistics.timestatistics)
            {
                totalgames = item.wins + item.draws + item.losses;

                if (totalgames != 0)
                {
                    double winrate = Math.Round((double)((item.wins * 100) / totalgames), 0);

                    if (winrate >= highest)
                    {
                        highest = (int)winrate;
                        time = item.time.ToString();
                        games = totalgames;
                    }
                }
            }
            stats[3] = time.Remove(0, 5) + "/" + highest + "/" + games;

            highest = JsonFile.owpt.otherstatistics.totalstatistics.highestRank;

            stats[4] = highest.ToString();

            if (highest < 1500)
                stats[5] = "Bronze";
            if (highest > 1499)
                stats[5] = "Silver";
            if (highest > 1999)
                stats[5] = "Gold";
            if (highest > 2499)
                stats[5] = "Platinum";
            if (highest > 2999)
                stats[5] = "Diamond";
            if (highest > 3499)
                stats[5] = "Master";
            if (highest > 3999)
                stats[5] = "Grand Master";

            return stats;
        }


        public static void DrawScene(Panel pnl_background)
        {
            string[] titles = new string[] { "Best Hero","Best Map","Best Groupsize","Best Time to Play","Highest SR","Highest Rank" };

            string[] texts = getstats(); 

            int index = 0;

            pnl_background.Controls.Clear();

            Point pos = new Point(40,50);

            for (int a = 0; a < 2; a++)
            {
                for (int i = 0; i < 3; i++)
                {
                    string[] s = texts[index].Split('/');

                    Panel p = new Panel { Size = new Size(210,150), Location = pos, BackColor = Color.FromArgb(79,79,79), BorderStyle = BorderStyle.FixedSingle };

                    Label title = new Label { Text = titles[index], BackColor = Color.FromArgb(155,0,155), AutoSize = false, Size = new Size(210, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(),25), ForeColor = Color.White };

                    Label text = null;

                    if (s.Length == 1)
                        text = new Label { Text = s[0].Replace('_',' '), ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 90), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
                    else
                    {
                        text = new Label { Text = s[0].Replace('_', ' '), ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 60), Location = new Point(0, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 25), };
                        Label l = new Label { Text = s[1] + "% Winrate / " + s[2] + " Games", ForeColor = Color.FromArgb(255, 215, 130), AutoSize = false, Size = new Size(210, 30), Location = new Point(0, 110), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(CustomFont.getFont().Families.First(), 15), };

                        p.Controls.Add(l);
                    }

                    p.Controls.AddRange(new Control[] { title, text });

                    pnl_background.Controls.Add(p);

                    pos.X += 275;
                    index++;
                }
                pos.X = 40;
                pos.Y += 220;
            }
        }
    }
}
