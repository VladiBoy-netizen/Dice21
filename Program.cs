namespace Dice21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Dice 21";
            int playerCash = 250;

            int playerPoints = 0;
            int cpuPoints = 0;

            while (playerCash > 0)
            {
                showUp(playerCash, "You have:");
                print("\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();
                string inputCash;
                int inptCash;

                while (true)
                {
                    inputCash = input("How mutch do you want to put in?\nMaximum is: " + playerCash);
                    try
                    {
                        inptCash = int.Parse(inputCash);
                        if (inptCash > playerCash)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            print("You don't have " + inptCash);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            print("You putted in " + playerCash);
                            Console.ResetColor();
                            inptCash = playerCash;
                            print("\nPress any key to continue");
                            Console.ReadKey();
                        }
                        Console.Clear();
                        break;
                    }
                    catch
                    {
                        print("It's not a number!\nTry again"); 
                    }
                }

                bool game = true;
                while (game)
                {
                    playerPoints = randint(1, 6);
                    playerPoints += randint(1, 6);
                    print("You got: " + playerPoints);

                    cpuPoints = randint(1, 6);
                    cpuPoints += randint(1, 6);
                    print("Dealer got: " + cpuPoints);

                    while (true)
                    {
                        print("\n[h]Hit or [s]Stand?");
                        ConsoleKeyInfo key = Console.ReadKey();
                        if (key.Key == ConsoleKey.H)
                        {
                            Console.Clear();
                            playerPoints += randint(1, 6);
                            print("You got: " + playerPoints);
                            if (playerPoints > 21)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                print("You busted!");
                                playerCash = lose(playerCash, inptCash);
                                game = false;
                                break;
                            }
                            if (cpuPoints <= 15)
                            {
                                cpuPoints += randint(1, 6);
                                print("Dealer got: " + cpuPoints);
                            }
                            else
                            {
                                print("Dealer stands with: " + cpuPoints);
                            }
                        }
                        else if (key.Key == ConsoleKey.S)
                        {
                            Console.Clear();
                            while (true)
                            {
                                Console.Clear();
                                if (cpuPoints <= 15)
                                {
                                    print("You got: " + playerPoints);
                                    cpuPoints += randint(1, 6);
                                    print("Dealer got: " + cpuPoints);
                                }
                                else
                                {
                                    print("You got: " + playerPoints);
                                    print("Dealer stands with: " + cpuPoints);
                                    break;
                                }
                            }

                            if (playerPoints > cpuPoints)
                            {
                                playerCash = win(playerCash, inptCash);
                            }
                            else
                            {
                                playerCash = lose(playerCash, inptCash);
                            }

                            game = false;
                            break;
                        }
                    }
                }

                print("\nPress any key to continue");
                Console.ReadKey();
            }
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            print("                                      \r\n ███▀▀▀██ ███▀▀▀███ ███▀█▄█▀███ ██▀▀▀ \r\n ██    ██ ██     ██ ██   █   ██ ██    \r\n ██   ▄▄▄ ██▄▄▄▄▄██ ██   ▀   ██ ██▀▀▀ \r\n ██    ██ ██     ██ ██       ██ ██    \r\n ███▄▄▄██ ██     ██ ██       ██ ██▄▄▄ \r\n                                      \r\n ███▀▀▀███ ▀███  ██▀ ██▀▀▀ ██▀▀▀▀██▄  \r\n ██     ██   ██  ██  ██    ██     ██  \r\n ██     ██   ██  ██  ██▀▀▀ ██▄▄▄▄▄▀▀  \r\n ██     ██   ██  █▀  ██    ██     ██  \r\n ███▄▄▄███    ▀█▀    ██▄▄▄ ██     ██▄ \r\n                                      ");
            Console.ResetColor();

            // From python stuff
            static void print(string text)
            { Console.WriteLine(text); }

            static string input(string text)
            { if (text != null) { print(text); } return Console.ReadLine(); }

            static int randint(int a, int b)
            { Random rand = new Random(); return rand.Next(a, b++); }

            // In game fun
            static int lose(int bank, int bet)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                print("You lost " + bet);
                Console.ResetColor();
                return bank - bet;
            }

            static int win(int bank, int bet)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                print("You won! You recive: " + (bet * 2));
                Console.ResetColor();
                return bank + (bet * 2);
            }

            static void PrintNumber(int number)
            {
                string strNum = number.ToString();

                string[] rows = new string[5];

                foreach (char c in strNum)
                {
                    string[] digitArt = GetAsciiArt(c);
                    for (int i = 0; i < 5; i++)
                    {
                        rows[i] += digitArt[i] + " ";
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(rows[i]);
                    Thread.Sleep(10);
                }
            }

            static string[] GetAsciiArt(char digit)
            {
                switch (digit)
                {
                    case '0':
                        return new string[]
                        {
                    " 000 ",
                    "0   0",
                    "0   0",
                    "0   0",
                    " 000 "
                        };
                    case '1':
                        return new string[]
                        {
                    "  1  ",
                    " 11  ",
                    "  1  ",
                    "  1  ",
                    " 111 "
                        };
                    case '2':
                        return new string[]
                        {
                    " 222 ",
                    "    2",
                    " 222 ",
                    "2    ",
                    " 222 "
                        };
                    case '3':
                        return new string[]
                        {
                    " 333 ",
                    "    3",
                    " 333 ",
                    "    3",
                    " 333 "
                        };
                    case '4':
                        return new string[]
                        {
                    "   4 ",
                    "  44 ",
                    " 4 4 ",
                    " 4444",
                    "   4 "
                        };
                    case '5':
                        return new string[]
                        {
                    " 5555",
                    " 5   ",
                    " 555 ",
                    "    5",
                    " 555 "
                        };
                    case '6':
                        return new string[]
                        {
                    " 666 ",
                    "6    ",
                    "6666 ",
                    "6   6",
                    " 666 "
                        };
                    case '7':
                        return new string[]
                        {
                    " 77777",
                    "    7",
                    "   7 ",
                    "  7  ",
                    " 7   "
                        };
                    case '8':
                        return new string[]
                        {
                    " 888 ",
                    "8   8",
                    " 888 ",
                    "8   8",
                    " 888 "
                        };
                    case '9':
                        return new string[]
                        {
                    " 999 ",
                    "9   9",
                    " 9999",
                    "    9",
                    " 999 "
                        };
                    default:
                        return new string[]
                        {
                    "     ",
                    "     ",
                    "     ",
                    "     ",
                    "     "
                        };
                }
            }

            static List<int> digitToMaxMin(int digit)
            {
                string min = "1";
                for (int i = 1; i < digit; i++)
                {
                    min += "0";
                }

                string max = "9";
                for (int i = 1; i < digit; i++)
                {
                    max += "9";
                }

                return new List<int> { int.Parse(min), int.Parse(max) };
            }

            static void showUp(int number, string text)
            {
                string length = number.ToString();
                for (int i = 0; i < length.Length; i++)
                {
                    Console.Clear();
                    print(text);
                    List<int> somethin = digitToMaxMin(i);
                    PrintNumber(randint(somethin[0], somethin[1]));
                    Thread.Sleep(200);
                }
                Console.Clear();
                print(text);
                PrintNumber(number);
            }
        }
    }
}