using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overwatch_Stats_Tracker
{

    #region enums

    public enum Maps
    {
        Dorado,
        Eichenwalde,
        Hanamura,
        Hollywood,
        Ilios,
        Kings_Row,
        Lijiang_Tower,
        Nepal,
        Numbani,
        Oasis,
        Route_66,
        Temple_of_Anubis,
        Volskaya_Industries,
        Watchpoint_Gibraltar
    }

    public enum Gamemode
    {
        Assault,
        Escort,
        Hybrid,
        Control,
    }

    public enum Heroes
    {
        Genji,
        McCree,
        Pharah,
        Reaper,
        Soldier_76,
        Sombra,
        Tracer,
        Bastion,
        Hanzo,
        Junkrat,
        Mei,
        Torbjörn,
        Widowmaker,
        Dva,
        Reinhardt,
        Roadhog,
        Winston,
        Zarya,
        Ana,
        Lucio,
        Mercy,
        Symmetra,
        Zenyatta
    }

    public enum Roles
    {
        Offense,
        Defense,
        Tank,
        Support,
    }

    public enum GroupSize
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six
    }

    public enum Times
    {
        From_12_pm_To_3_pm,
        From_3_pm_To_6_pm,
        From_6_pm_To_9_pm,
        From_9_pm_To_12_am,
        From_12_am_To_3_am,
        From_3_am_To_6_am,
        From_6_am_To_9_am,
        From_9_am_To_12_pm,
    }

    #endregion enums


    public class OWPerformanceTracker
    {
        public Map_Statistics mapstatistics = new Map_Statistics();
        public Hero_Statistics herostatistics = new Hero_Statistics();
        public HeroStatisticsPerMap herostatisticspermap = new HeroStatisticsPerMap();
        public OtherStatistics otherstatistics = new OtherStatistics();
    }



    #region MapStatistics

    public class Map_Statistics
    {
        public List<Map_Statistics_Map> maps = new List<Map_Statistics_Map>();
    }

    public class Map_Statistics_Map
    {
        public Maps mapname;
        public Gamemode gamemode;
        public Map_Statistics_Stats statistics = new Map_Statistics_Stats();
    }

    public class Map_Statistics_Stats
    {
        public int wins = 0;
        public int losses = 0;
        public int draws = 0;
    }

    #endregion

    #region HeroStatistics

    public class Hero_Statistics
    {
        public List<Hero_Statistics_Heros> heroes = new List<Hero_Statistics_Heros>();
    }

    public class Hero_Statistics_Heros
    {
        public Heroes hero;
        public Roles role;
        public Hero_Statistics_Stats statistics = new Hero_Statistics_Stats();
    }

    public class Hero_Statistics_Stats
    {
        public int wins = 0;
        public int losses = 0;
        public int draws = 0;
    }

    #endregion

    #region HeroStatisticsPerMap

    public class HeroStatisticsPerMap
    {
        public List<HeroStatisticsPerMap_Maps> maps = new List<HeroStatisticsPerMap_Maps>();
    }

    public class HeroStatisticsPerMap_Maps
    {
        public Maps mapname;
        public List<HeroStatisticsPerMap_Heroes> heroes = new List<HeroStatisticsPerMap_Heroes>();
    }

    public class HeroStatisticsPerMap_Heroes
    {
        public Heroes hero;
        public Roles role;
        public HeroStatisticsPerMap_Stats statistics = new HeroStatisticsPerMap_Stats();
    }

    public class HeroStatisticsPerMap_Stats
    {
        public int wins = 0;
        public int losses = 0;
        public int draws = 0;
    }
    #endregion

    #region OtherStatistics 

    public class OtherStatistics
    {
        public OtherStatistics_TotalStatistics totalstatistics = new OtherStatistics_TotalStatistics();
        public List<OtherStatistics_GroupStatistics> groupstatistics = new List<OtherStatistics_GroupStatistics>();
        public List<OtherStatistics_TimeStatistics> timestatistics = new List<OtherStatistics_TimeStatistics>();
    }

    public class OtherStatistics_TotalStatistics
    {
        public int gamesplayed = 0;
        public int wins = 0;
        public int losses = 0;
        public int draws = 0;
        public int losestreak = 0;
        public int winstreak = 0;
        public int highestSRGain = 0;
        public int lowestSRGain = 100000;
        public int highestSRLose = 0;
        public int lowestSRLose = 100000;
        public int highestRank = 0;
        public int lowestRank = 100000;
        public int currRank = 0;
    }

    public class OtherStatistics_GroupStatistics
    {
        public GroupSize size;
        public int wins = 0;
        public int losses = 0;
        public int draws = 0;
    }

    public class OtherStatistics_TimeStatistics
    {
        public Times time;
        public int wins = 0;
        public int losses = 0;
        public int draws = 0;
    }

    #endregion
}
