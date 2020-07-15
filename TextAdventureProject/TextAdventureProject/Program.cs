using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TextAdventureProject.TextAdventureFramework;

namespace TextAdventureProject
{
    class Program
    {
        public const ConsoleColor DefaultColor = ConsoleColor.Gray;
        public const ConsoleColor HighlightColor = ConsoleColor.White;
        public const ConsoleColor InputColor = ConsoleColor.Green;
        public const ConsoleColor WarningColor = ConsoleColor.DarkRed;
        public const ConsoleColor ErrorColor = ConsoleColor.Red;

        static void Main(string[] args)
        {
            //AdventurePlayer p = AdventurePlayer.Generate();

            BaseStoryOption[] testOptions = 
            {
                new SimpleStoryOption("Target01", "Display01"),
                new SimpleStoryOption("Target02", "Display02"),
                new SimpleStoryOption("Target03", "Display03"),
            };
            int input = ProcessPlayerChoice(testOptions);

            Console.WriteLine("Target was: " + testOptions[input].TargetKey);
        }


        public static void WriteColored(string text, ConsoleColor textColor)
        {
            using (new ColorSwitcher(textColor))
            {
                Console.Write(text);
            }
        }

        public static void WriteLineColored(string text, ConsoleColor textColor)
        {
            using (new ColorSwitcher(textColor))
            {
                Console.WriteLine(text);
            }
        }

        public static int ReadNumericInput(int maxNumber, int minNumber = 1)
        {
            int result;
            do
            {
                WriteColored($"Input a number ({minNumber} - {maxNumber}): ", InputColor);

                try
                {
                    using (new ColorSwitcher(InputColor))
                    {
                        result = Convert.ToInt32(Console.ReadLine());
                    }
                }
                catch (FormatException e)
                {
                    WriteLineColored($"Input format invalid! [{e.Message}]", ErrorColor);
                    continue;
                }
                catch (OverflowException e)
                {
                    WriteLineColored($"Input size invalid! [{e.Message}]", ErrorColor);
                    continue;
                }
                catch (IOException e)
                {
                    WriteLineColored($"Input invalid! [{e.Message}]", ErrorColor);
                    continue;
                }
                catch (OutOfMemoryException e)
                {
                    WriteLineColored($"Out of memory! [{e.Message}]", ErrorColor);
                    continue;
                }
                catch (ArgumentOutOfRangeException e)
                {
                    WriteLineColored($"Input invalid! [{e.Message}]", ErrorColor);
                    continue;
                }

                if (result < minNumber || result > maxNumber)
                {
                    WriteLineColored($"Input invalid! Input must be between {minNumber} and {maxNumber}", ErrorColor);
                    continue;
                }

                break;
            } while (true);
            return result;
        }

        public static string ReadStringInput(string label)
        {
            string nameInput;

            do
            {
                using (new ColorSwitcher(InputColor))
                {
                    string nameLabel = $"Input {label}: ";
                    Console.Write(nameLabel);

                    try
                    {
                        nameInput = Console.ReadLine()?.Trim();
                    }
                    catch (IOException e)
                    {
                        WriteLineColored($"Input invalid! [{e.Message}]", ErrorColor);
                        continue;
                    }
                    catch (OutOfMemoryException e)
                    {
                        WriteLineColored($"Out of memory! [{e.Message}]", ErrorColor);
                        continue;
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        WriteLineColored($"Input invalid! [{e.Message}]", ErrorColor);
                        continue;
                    }
                    
                    if (string.IsNullOrWhiteSpace(nameInput))
                    {
                        WriteLineColored("Input cannot be empty!", ErrorColor);
                        continue;
                    }
                }
                break;
            } while (true);

            return nameInput;
        }

        public static int ProcessPlayerChoice(string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i+1}: {options[i]}");
            }
            return ReadNumericInput(options.Length) - 1;
        }

        public static int ProcessPlayerChoice(BaseStoryOption[] options)
        {
            return ProcessPlayerChoice(options.Select(t => t.DisplayText).ToArray());
        }

        public struct ColorSwitcher : IDisposable
        {
            private readonly ConsoleColor _cachedColor;
            public ColorSwitcher(ConsoleColor color)
            {
                _cachedColor = Console.ForegroundColor;
                Console.ForegroundColor = color;
            }

            public void Dispose()
            {
                Console.ForegroundColor = _cachedColor;
            }
        }
    }
}
