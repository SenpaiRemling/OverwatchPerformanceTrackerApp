using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overwatch_Stats_Tracker
{
    public static class JsonFile
    {
        public static OWPerformanceTracker owpt = new OWPerformanceTracker();

        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);



        public static void save_to_json()
        {
            string json = JsonConvert.SerializeObject(owpt, Formatting.Indented);

            Directory.CreateDirectory(path + @"\OverwatchPerformanceTracker");

            File.WriteAllText(path + @"\OverwatchPerformanceTracker\statistics.json", json);
        }


        public static void insertStandartValues()
        {
            if (File.Exists(path + @"\OverwatchPerformanceTracker\statistics.json"))
            {
                using (StreamReader r = new StreamReader(path + @"\OverwatchPerformanceTracker\statistics.json"))
                {
                    string json = r.ReadToEnd();
                    owpt = JsonConvert.DeserializeObject<OWPerformanceTracker>(json);
                }
            }
            else
            {
                #region Insert_MapsStatistics

                owpt.mapstatistics.maps.AddRange
                    (
                        new Map_Statistics_Map[]
                        {
                        new Map_Statistics_Map
                        {
                            gamemode = Gamemode.Assault,
                            mapname = Maps.Hanamura
                        },
                        new Map_Statistics_Map
                        {
                            gamemode = Gamemode.Assault,
                            mapname = Maps.Temple_of_Anubis
                        },
                        new Map_Statistics_Map
                        {
                            gamemode = Gamemode.Assault,
                            mapname = Maps.Volskaya_Industries
                        },
                        new Map_Statistics_Map
                        {
                            gamemode = Gamemode.Escort,
                            mapname = Maps.Dorado
                        },
                        new Map_Statistics_Map
                        {
                            gamemode = Gamemode.Escort,
                            mapname = Maps.Route_66
                        },
                        new Map_Statistics_Map
                        {
                            gamemode = Gamemode.Escort,
                            mapname = Maps.Watchpoint_Gibraltar
                        },
                        new Map_Statistics_Map
                        {
                            gamemode = Gamemode.Hybrid,
                            mapname = Maps.Hollywood
                        },
                        new Map_Statistics_Map
                        {
                            gamemode = Gamemode.Hybrid,
                            mapname = Maps.Kings_Row
                        },
                        new Map_Statistics_Map
                        {
                            gamemode = Gamemode.Hybrid,
                            mapname = Maps.Numbani
                        },
                        new Map_Statistics_Map
                        {
                            gamemode = Gamemode.Hybrid,
                            mapname = Maps.Eichenwalde
                        },
                        new Map_Statistics_Map
                        {
                            gamemode = Gamemode.Control,
                            mapname = Maps.Ilios
                        },
                        new Map_Statistics_Map
                        {
                            gamemode = Gamemode.Control,
                            mapname = Maps.Lijiang_Tower
                        },
                        new Map_Statistics_Map
                        {
                            gamemode = Gamemode.Control,
                            mapname = Maps.Nepal
                        },
                        new Map_Statistics_Map
                        {
                            gamemode = Gamemode.Control,
                            mapname = Maps.Oasis
                        },

                        }

                    );

                #endregion

                #region Insert_HeroStatistics

                owpt.herostatistics.heroes.AddRange
                    (
                        new Hero_Statistics_Heros[]
                        {
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Genji,
                                    role = Roles.Offense
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.McCree,
                                    role = Roles.Offense
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Pharah,
                                    role = Roles.Offense
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Reaper,
                                    role = Roles.Offense
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Soldier_76,
                                    role = Roles.Offense
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Sombra,
                                    role = Roles.Offense
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Tracer,
                                    role = Roles.Offense
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Bastion,
                                    role = Roles.Defense
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Hanzo,
                                    role = Roles.Defense
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Junkrat,
                                    role = Roles.Defense
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Mei,
                                    role = Roles.Defense
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Torbjörn,
                                    role = Roles.Defense
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Widowmaker,
                                    role = Roles.Defense
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Dva,
                                    role = Roles.Tank
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Reinhardt,
                                    role = Roles.Tank
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Roadhog,
                                    role = Roles.Tank
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Winston,
                                    role = Roles.Tank
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Zarya,
                                    role = Roles.Tank
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Ana,
                                    role = Roles.Support
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Lucio,
                                    role = Roles.Support
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Mercy,
                                    role = Roles.Support
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Symmetra,
                                    role = Roles.Support
                                },
                                new Hero_Statistics_Heros
                                {
                                    hero = Heroes.Zenyatta,
                                    role = Roles.Support
                                },
                        }
                    );

                #endregion

                #region Insert_HeroStatisticsPerMap

                List<HeroStatisticsPerMap_Maps> maps = new List<HeroStatisticsPerMap_Maps>();

                foreach (Maps map in Enum.GetValues(typeof(Maps)))
                {
                    maps.Add
                        (
                            new HeroStatisticsPerMap_Maps
                            {
                                mapname = map,
                                heroes = new List<HeroStatisticsPerMap_Heroes>
                                {
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Genji,
                                    role = Roles.Offense
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.McCree,
                                    role = Roles.Offense
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Pharah,
                                    role = Roles.Offense
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Reaper,
                                    role = Roles.Offense
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Soldier_76,
                                    role = Roles.Offense
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Sombra,
                                    role = Roles.Offense
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Tracer,
                                    role = Roles.Offense
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Bastion,
                                    role = Roles.Defense
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Hanzo,
                                    role = Roles.Defense
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Junkrat,
                                    role = Roles.Defense
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Mei,
                                    role = Roles.Defense
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Torbjörn,
                                    role = Roles.Defense
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Widowmaker,
                                    role = Roles.Defense
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Dva,
                                    role = Roles.Tank
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Reinhardt,
                                    role = Roles.Tank
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Roadhog,
                                    role = Roles.Tank
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Winston,
                                    role = Roles.Tank
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Zarya,
                                    role = Roles.Tank
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Ana,
                                    role = Roles.Support
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Lucio,
                                    role = Roles.Support
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Mercy,
                                    role = Roles.Support
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Symmetra,
                                    role = Roles.Support
                                },
                                new HeroStatisticsPerMap_Heroes
                                {
                                    hero = Heroes.Zenyatta,
                                    role = Roles.Support
                                },
                                }
                            }
                        );
                }

                owpt.herostatisticspermap.maps = maps;
                #endregion

                #region Insert_OtherStatistics

                owpt.otherstatistics.groupstatistics.AddRange
                    (
                        new OtherStatistics_GroupStatistics[]
                        {
                        new OtherStatistics_GroupStatistics
                        {
                            size = GroupSize.One,
                        },
                        new OtherStatistics_GroupStatistics
                        {
                            size = GroupSize.Two,
                        },
                        new OtherStatistics_GroupStatistics
                        {
                            size = GroupSize.Three,
                        },
                        new OtherStatistics_GroupStatistics
                        {
                            size = GroupSize.Four,
                        },
                        new OtherStatistics_GroupStatistics
                        {
                            size = GroupSize.Five,
                        },
                        new OtherStatistics_GroupStatistics
                        {
                            size = GroupSize.Six,
                        }
                        }

                    );

                owpt.otherstatistics.timestatistics.AddRange
                    (
                        new OtherStatistics_TimeStatistics[]
                        {
                        new OtherStatistics_TimeStatistics
                        {
                            time = Times.From_12_am_To_3_am
                        },
                        new OtherStatistics_TimeStatistics
                        {
                            time = Times.From_3_am_To_6_am
                        },
                        new OtherStatistics_TimeStatistics
                        {
                            time = Times.From_6_am_To_9_am
                        },
                        new OtherStatistics_TimeStatistics
                        {
                            time = Times.From_9_am_To_12_pm
                        },
                        new OtherStatistics_TimeStatistics
                        {
                            time = Times.From_12_pm_To_3_pm
                        },
                        new OtherStatistics_TimeStatistics
                        {
                            time = Times.From_3_pm_To_6_pm
                        },
                        new OtherStatistics_TimeStatistics
                        {
                            time = Times.From_6_pm_To_9_pm
                        },
                        new OtherStatistics_TimeStatistics
                        {
                            time = Times.From_9_pm_To_12_am
                        },

                        }
                    );

                #endregion

                save_to_json();
            }
        }

    }
}
