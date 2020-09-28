using System;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Schema;

namespace Battleship_Game
{
    class Program
    {
        static string[,] Grid = new string[11, 11];
        static int[,] Battleship = new int[5,2];
        static int[,] UserGuesses = new int[8, 2];
        static bool alive = true;
        static bool playDecision = false;
        static void Main(string[] args)
        {
            while(alive)
            { 
                InitializeGrid();
                playDecision = GameIntro();
                if (playDecision)
                {
                    bool tutorialDecision = Tutorial();
                    if (tutorialDecision)
                    {
                        PlayBattleShip();
                        alive = PlayAgain();
                        Console.Clear();
                    }
                }
            }

        }

        public static bool GameIntro()
        {
            while (true) {
                Console.Clear();
                Console.Write("Do you want play Battleship?! (Y or N) : ");
                var playGameInput = Console.ReadLine();
                if (playGameInput == "y" || playGameInput == "Y") {
                    return true;
                } else if (playGameInput == "n" || playGameInput == "N") {
                    Console.Write("\nYou don't really have a choice ensign! Press Enter and get ready for war!");
                    Console.ReadLine();
                    return true;
                } else {
                    Console.Write("\nIncorrect Input press Enter to resume.");
                    Console.ReadLine();
                }
            }
        }

        public static bool PlayAgain()
        {
            while (true) {
                Console.Write("\nWould you like to play again!? (Y or N) : ");
                var playGameInput = Console.ReadLine();
                if (playGameInput == "y" || playGameInput == "Y") {
                    return true;
                } else if (playGameInput == "n" || playGameInput == "N") {
                    Console.Write("\nGood Bye");
                    return false;
                } else {
                    Console.Write("\nIncorrect Input press Enter to resume.");
                    Console.ReadLine();
                }
            }
        }

        public static string getDirection(bool left, bool right, bool up, bool down)
        {
            Random rand = new Random();
            int direction;

            if (left && right && up && down)
            {
                direction = rand.Next(1, 5);
                if (direction == 1)
                {
                    return "left";
                } else if (direction == 2)
                { 
                    return "right"; 
                } else if (direction == 3)
                { 
                    return "up"; 
                } else if (direction == 4)
                { 
                    return "down"; 
                }
            } else if (left && right && !up && down)
            {
                direction = rand.Next(1, 4);
                if (direction == 1)
                {
                    return "left";
                }
                else if (direction == 2)
                {
                    return "right";
                }
                else if (direction == 3)
                {
                    return "down";
                }

            } else if (left && right && up && !down)
            {
                direction = rand.Next(1, 4);
                if (direction == 1)
                {
                    return "left";
                }
                else if (direction == 2)
                {
                    return "right";
                }
                else if (direction == 3)
                {
                    return "up";
                }

            } else if (!left && right && up && down)
            {
                direction = rand.Next(1, 4);
                if (direction == 1)
                {
                    return "right";
                }
                else if (direction == 2)
                {
                    return "up";
                }
                else if (direction == 3)
                {
                    return "down";
                }

            } else if (left && !right && up && down)
            {
                direction = rand.Next(1, 4);
                if (direction == 1)
                {
                    return "left";
                }
                else if (direction == 2)
                {
                    return "up";
                }
                else if (direction == 3)
                {
                    return "down";
                }

            } else if (!left && right && up && !down)
            {
                direction = rand.Next(1, 3);
                if (direction == 1)
                {
                    return "right";
                }
                else if (direction == 2)
                {
                    return "up";
                }

            } else if (!left && right && !up && down)
            {
                direction = rand.Next(1, 3);
                if (direction == 1)
                {
                    return "right";
                }
                else if (direction == 2)
                {
                    return "down";
                }

            } else if (left && !right && up && !down)
            {
                direction = rand.Next(1, 3);
                if (direction == 1)
                {
                    return "left";
                }
                else if (direction == 2)
                {
                    return "up";
                }

            } else if (left && !right && !up && down)
            {
                direction = rand.Next(1, 3);
                if (direction == 1)
                {
                    return "left";
                }
                else if (direction == 2)
                {
                    return "down";
                }
            }

            return "Did not find direction";
        }

        public static void setBattleshipOnGrid(int Xinit, int Yinit, string direction)
        {
            
            if (direction == "left")
            {
                int x = Xinit;
                for (int i =1; i < 5; i++)
                {
                   for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            x --;
                            Battleship[i, j] = x;
                        } else
                        {
                            Battleship[i, j] = Yinit;
                        }
                    }
                }
            } else if (direction == "right")
            {
                int x = Xinit;
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            x++;
                            Battleship[i, j] = x;
                        }
                        else
                        {
                            Battleship[i, j] = Yinit;
                        }
                    }
                }

            } else if (direction == "up")
            {
                int y = Yinit;
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            Battleship[i, j] = Xinit;
                        }
                        else
                        {
                            y++;
                            Battleship[i, j] = y;
                        }
                    }
                }
            } else if (direction == "down")
            {
                int y = Yinit;
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            Battleship[i, j] = Xinit;
                        }
                        else
                        {
                            y--;
                            Battleship[i, j] = y;
                        }
                    }
                }
            }
            printBattleship();
        }

        public static void printBattleship()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.WriteLine("[i] = " + i);
                    Console.WriteLine("[j] = " + j);
                    Console.WriteLine("[i][j] = " + Battleship[i, j]);
                }
            }
        }

        public static void createBattleship()
        {
            Random rand = new Random();
            
            int initXValue = rand.Next(1, 10);
            int initYValue = rand.Next(1, 10);
            Battleship[0,0] = initXValue;
            Battleship[0,1] = initYValue;

            if ((initXValue == 5 || initXValue == 6) && (initYValue == 5 || initYValue == 6))
            {
                setBattleshipOnGrid(initXValue, initYValue, getDirection(true, true, true, true));
            } else if ((initXValue == 5 || initXValue == 6) && initYValue < 5) 
            {
                setBattleshipOnGrid(initXValue, initYValue, getDirection(true, true, true, false));
            } else if ((initXValue == 5 || initXValue == 6) && initYValue > 6)
            {
                setBattleshipOnGrid(initXValue, initYValue, getDirection(true, true, false, true));
            } else if (initXValue < 5  && (initYValue == 5 || initYValue == 6))
            {
                setBattleshipOnGrid(initXValue, initYValue, getDirection(false, true, true, true));
            } else if (initXValue > 6 && (initYValue == 5 || initYValue == 6))
            {
                setBattleshipOnGrid(initXValue, initYValue, getDirection(true, false, true, true));
            } else if (initXValue < 5 && initYValue < 5)
            {
                setBattleshipOnGrid(initXValue, initYValue, getDirection(false, true, true, false));
            } else if (initXValue < 5 && initYValue > 6)
            {
                setBattleshipOnGrid(initXValue, initYValue, getDirection(false, true, false, true));
            } else if (initXValue > 6 && initYValue < 5)
            {
                setBattleshipOnGrid(initXValue, initYValue, getDirection(true, false, true, false));
            } else if (initXValue > 6 && initYValue > 6)
            {
                setBattleshipOnGrid(initXValue, initYValue, getDirection(true, false, false, true));
            }

        }

        public static void printGuesses()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.WriteLine("[i] = " + i);
                    Console.WriteLine("[j] = " + j);
                    Console.WriteLine("[i][j] = " + UserGuesses[i, j]);
                }
            }
        }

        public static bool DetermineIfGuessed(int XValue, int YValue, int shotsFired)
        {
            bool XMatches = false;
            bool YMatches = false;

            for (int i = 0; i < shotsFired; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                    {
                        if (XValue == UserGuesses[i, j])
                        {
                            XMatches = true;
                        }
                    }
                    else
                    {
                        if (YValue == UserGuesses[i, j])
                        {
                            YMatches = true;
                        }else
                        {
                            XMatches = false;
                        }
                    }
                }

                if (XMatches && YMatches)
                {
                    return true;
                }
            }
            UserGuesses[shotsFired, 0] = XValue;
            UserGuesses[shotsFired, 1] = YValue;
            return false;           
        }

        public static bool DetermineHit(int XValue, int YValue)
        {
            bool XMatches = false;
            bool YMatches = false;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                    {
                        if (XValue == Battleship[i, j])
                        {
                            XMatches = true;
                        }
                    } else
                    {
                        if (YValue == Battleship[i, j])
                        {
                            YMatches = true;
                        }
                    }
                    
                }
            }

            if (XMatches && YMatches)
            {
                return true;
            }
            return false;
        }

        public static void InitializeGrid()
        {
            for (int i = 10; i >= 0; i--)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (i == 0)
                    {
                        Grid[i, j] = j.ToString();
                    } else
                    {
                        if (j == 0)
                        {
                            Grid[i, j] = i.ToString();
                        } else
                        {
                            Grid[i, j] = "-";
                        }
                    }
                    
                }
            }
        }
        public static void EditGrid(int Xvalue, int Yvalue, bool hit)
        {
            if (hit)
            {
                Grid[Yvalue, Xvalue] = "x";
            } else
            {
                Grid[Yvalue, Xvalue] = "o";
            }
        }

        public static void PrintGrid()
        {
            for (int i = 10; i >= 0; i--)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (i == 10 && j == 0)
                    {
                        Console.Write(Grid[i, j] + " ");
                    } else
                    {
                        Console.Write(Grid[i, j] + "  ");
                    }
                }
                Console.Write("\n");
            }
        }

        public static bool Tutorial()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Would you like a quick tutorial? (Y or N) : ");
                var tutorialInput = Console.ReadLine();
                if (tutorialInput == "y" || tutorialInput == "Y")
                {
                    Console.Clear();
                    Console.WriteLine("\n***************************************************************************************************************");
                    Console.WriteLine("The Game is simple, you will be prompted to select a point on a 10 x 10 grid.");
                    Console.WriteLine("The point is made up of an X-value and a Y-value that represent one square of the grid...Please see below");
                    Console.WriteLine("\n");
                    PrintGrid();
                    Console.WriteLine("\n");
                    Console.WriteLine("Once the point is selected you will be prompted with a hit or miss.");
                    Console.WriteLine("You will be given a total of 8 guesses. If you do not destroy the enemy vessel...");
                    Console.WriteLine("You are probably a fit for the 1588 spanish armada and lose the game.");
                    Console.WriteLine("However if you annihalate the enemy which takes up 5 grid spaces you win!");
                    Console.WriteLine("After which you can gloat to your friends and family, and garner the respect of your peers");
                    Console.WriteLine("***************************************************************************************************************");
                    Console.WriteLine("\nPress any key and lets fire up the boilers and ship off!");
                    Console.ReadLine();
                    return true;
                }
                else if (tutorialInput == "n" || tutorialInput == "N")
                {
                    Console.Write("\nLooks like we got ourselves a hero! Press Enter and lets see what you got!");
                    Console.ReadLine();
                    return true;
                }
                else
                {
                    Console.Write("Incorrect Input ensign! Press Enter to resume!");
                    Console.ReadLine();
                }   
            }
        }

        public static bool InputValidation(int XValue, int YValue)
        {
            if ((XValue > 0 && XValue < 11) && (YValue > 0 && YValue < 11))
            {
                return true;
            }
            return false;
        }

        public static void PlayBattleShip()
        {
            Console.Clear();
            Console.WriteLine("\nLets play Battlship!!");
            int shotsFired = 0;
            int NumberOfHits = 0;
            createBattleship();
            while (shotsFired < 8)
            {
                Console.Clear();
                Console.WriteLine("Shots Remaining = " + (8 - shotsFired));
                PrintGrid();
                Console.Write("\n(X-axis) - Select a spot [1-10] to fire upon : ");
                var XValue = Convert.ToInt32(Console.ReadLine()); //Need to fix inputs! create function to take in and if string is a number convert to number
                Console.Write("\n(Y-axis) - Select a spot [1-10] to fire upon : ");
                var YValue = Convert.ToInt32(Console.ReadLine()); //Need to fix inputs! create function to take in and if string is a number convert to number
                if (!InputValidation(XValue, YValue))
                {
                    Console.Clear();
                    Console.WriteLine("\nIncorrect Input ensign! Press Enter to resume!\n");
                    Console.ReadLine();
                } else
                {
                    if (DetermineIfGuessed(XValue, YValue, shotsFired))
                    {
                        Console.Write("\nRookie mistake ensign! Choose a spot you haven't already shot at! Press Enter to resume!");
                        Console.ReadLine();
                        Console.Clear();
                    } else
                    {
                        if (DetermineHit(XValue, YValue))
                        {
                            NumberOfHits++;
                            Console.WriteLine("\nHit!\n");
                            Console.Write("Press Enter to resume!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("\nMiss!\n");
                            Console.Write("Press Enter to resume!");
                            Console.ReadLine();
                        }
                        EditGrid(XValue, YValue, DetermineHit(XValue, YValue));
                        shotsFired++;
                    }
                }
                if (NumberOfHits == 5)
                {
                    Console.Clear();
                    PrintGrid();
                    Console.WriteLine("\nCongratulations!! Youve Sunk the Battleship!");
                    break;
                }
            }
        }
    }
}
