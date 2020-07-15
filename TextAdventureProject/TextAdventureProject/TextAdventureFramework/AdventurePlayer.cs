using System;

namespace TextAdventureProject.TextAdventureFramework
{
    class AdventurePlayer
    {
        private const int DefaultStatValue = 8;
        public string Name;

        public int Str { get; private set; }
        public int Dex { get; private set; }
        public int Int { get; private set; }

        public AdventurePlayer(string name)
        {
            Name = name;

            Str = DefaultStatValue;
            Dex = DefaultStatValue;
            Int = DefaultStatValue;
        }


        public static AdventurePlayer Generate(int statPoints = 10)
        {
            throw new NotImplementedException();
        }


        public void SetStat(PlayerStat stat, int value)
        {
            switch (stat)
            {
                case PlayerStat.STR:
                    Str = value;
                    break;
                case PlayerStat.DEX:
                    Dex = value;
                    break;
                case PlayerStat.INT:
                    Int = value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(stat), stat, null);
            }
        }

        private int GetPlayerStatValueByStat(PlayerStat stat)
        {
            switch (stat)
            {
                case PlayerStat.STR:
                    return Str;
                case PlayerStat.DEX:
                    return Dex;
                case PlayerStat.INT:
                    return Int;
                default:
                    throw new ArgumentOutOfRangeException(nameof(stat), stat, null);
            }
        }
    }

    public enum PlayerStat
    {
        STR,
        DEX,
        INT
    }
}
