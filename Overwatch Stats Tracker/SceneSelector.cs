using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Overwatch_Stats_Tracker
{
    public static class SceneSelector
    {
        public static void loadScene(string name, Panel pnl_background)
        {
            if(name == "Home")
            {
                Home.DrawScene(pnl_background);
            }
            else if(name == "About")
            {
                About.DrawScene(pnl_background);
            }
            else if(name == "Add Match")
            {
                Add_Match.DrawScene(pnl_background);
            }
            else if(name == "Hero Statistics")
            {
                Hero_Stats.DrawScene(pnl_background);
            }
            else if (name == "Map Statistics")
            {
                Map_Stats.DrawScene(pnl_background);
            }
            else if(name == "Hero Stats Per Map")
            {
                Hero_Stats_Per_Map.DrawScene(pnl_background);
            }
            else if(name == "Other Statistics")
            {
                Other_Stats.DrawScene(pnl_background);
            }
            else if(name == "How To")
            {
                How_To.DrawScene(pnl_background);
            }
        }
    }
}
