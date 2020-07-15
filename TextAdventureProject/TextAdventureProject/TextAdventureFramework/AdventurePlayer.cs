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
            Console.WriteLine("### Player Generator started! ###");
            Console.WriteLine("First, enter a name for your character.");

            string tempName;
            AdventurePlayer player;
            do
            {
                tempName = Program.ReadStringInput("name");
                player = new AdventurePlayer(tempName);

                Console.WriteLine("Next, lets shape your character. Your character has three stats: STRENGTH, DEXTERITY and INTELLIGENCE.");
                Console.WriteLine("Your characters current stats are: ");
                Program.WriteLineColored($"STRENGTH: {player.Str}", Program.HighlightColor);
                Program.WriteLineColored($"DEXTERITY: {player.Dex}", Program.HighlightColor);
                Program.WriteLineColored($"INTELLIGENCE: {player.Int}", Program.HighlightColor);
                Console.WriteLine($"You possess {statPoints} skill-points to add to the stats step by step.");
                Console.WriteLine($"How many points do you want to spent on STRENGTH?");
                int strPlus = Program.ReadNumericInput(statPoints, 0);
                statPoints -= strPlus;
                player.Str += strPlus;
                if (statPoints > 0)
                {
                    Console.WriteLine($"You have {statPoints} skill-points left.");
                    Console.WriteLine($"How many points do you want to spent on DEXTERITY? Remaining points will be added to INTELLIGENCE.");

                    int dexPlus = Program.ReadNumericInput(statPoints, 0);
                    statPoints -= dexPlus;
                    player.Dex += dexPlus;
                    player.Int += statPoints;
                }
                Console.WriteLine("You spent all your points! Your characters final stats are: ");
                Program.WriteLineColored($"STRENGTH: {player.Str}", Program.HighlightColor);
                Program.WriteLineColored($"DEXTERITY: {player.Dex}", Program.HighlightColor);
                Program.WriteLineColored($"INTELLIGENCE: {player.Int}", Program.HighlightColor);

                Console.WriteLine($"Are you fine with {player.Name}?");
                if(Program.ProcessPlayerChoice(new[] { "Yes", "No. Redo." }) != 0)
                    continue;

                break;
            } while (true);
            return player;
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
