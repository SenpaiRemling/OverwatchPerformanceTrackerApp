using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overwatch_Stats_Tracker
{
    public static class CustomFont
    {
        static PrivateFontCollection modernFont = new PrivateFontCollection();

        public static void Instantiate()
        {
            modernFont.AddFontFile(@"Font\koverwatch.ttf");
        }

        public static PrivateFontCollection getFont()
        {
            return modernFont;
        } 

    }
}
