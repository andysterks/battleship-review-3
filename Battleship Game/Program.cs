using System;
using System.Xml.Schema;

namespace Battleship_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playDecision = GameIntro();
            if (playDecision)
            {
                bool tutorialDecision = Tutorial();
                if (tutorialDecision)
                {
                    PlayBattleShip();
                }
                
            }

        }

        public static bool GameIntro()
        {
            bool output = false;
            while (output == false) {
                Console.WriteLine("\nDo you want play Battleship?! Y or N?");
                var playGameInput = Console.ReadLine();
                if (playGameInput == "y" || playGameInput == "Y") {
                    output = true;
                } else if (playGameInput == "n" || playGameInput == "N") {
                    Console.WriteLine("\nYou don't really have a choice ensign! Press any key and get ready for war!");
                    Console.ReadLine();
                    output = true;
                } else {
                    Console.WriteLine("\nIncorrect Input press any key to resume.");
                }
  
            }
            return output;
        }

        public static void PlaceBattleShipOnGrid()
        {
            
        }

        public static bool ShipHit(int XValue, int YValue)
        {
            if (XValue == 1 && YValue == 1)
            {
                return true;
            }
            return false;
        }

        public static bool Tutorial()
        {
            Console.Clear();
            Console.WriteLine("\nWould you like a quick tutorial? Y or N");
            var tutorialInput = Console.ReadLine();
            bool tutorialBool = false;
            while (tutorialBool == false)
            {
                if (tutorialInput == "y" || tutorialInput == "Y")
                {
                    Console.Clear();
                    Console.WriteLine("\n***************************************************************************************************************");
                    Console.WriteLine("The Game is simple, you will be prompted to select a point on a 10 x 10 grid.");
                    Console.WriteLine("The point is made up of an X-value and a Y-value that represent one square of the grid...Please see below");
                    Console.WriteLine("\n");
                    Console.WriteLine("0  1  2  3  4  5  6  7  8  9  10");
                    Console.WriteLine("1  -  -  -  -  -  -  -  -  -  -");
                    Console.WriteLine("2  -  -  -  -  -  -  -  -  -  -");
                    Console.WriteLine("3  -  -  -  -  -  -  -  -  -  -");
                    Console.WriteLine("4  -  -  -  -  -  -  -  -  -  -");
                    Console.WriteLine("5  -  -  -  -  -  -  -  -  -  -");
                    Console.WriteLine("6  -  -  -  -  -  -  -  -  -  -");
                    Console.WriteLine("7  -  -  -  -  -  -  -  -  -  -");
                    Console.WriteLine("8  -  -  -  -  -  -  -  -  -  -");
                    Console.WriteLine("9  -  -  -  -  -  -  -  -  -  -");
                    Console.WriteLine("10 -  -  -  -  -  -  -  -  -  -");
                    Console.WriteLine("\n");
                    Console.WriteLine("Once the point is selected you will be prompted with a hit or miss.");
                    Console.WriteLine("You will be given a total of 8 guesses. If you do not destroy the enemy vessel...");
                    Console.WriteLine("You are probably a fit for the 1588 spanish armada and lose the game.");
                    Console.WriteLine("However if you annihalate the enemy which takes up 5 grid spaces you win!");
                    Console.WriteLine("After which you can gloat to your friends and family, and garner the respect of your peers");
                    Console.WriteLine("***************************************************************************************************************");
                    Console.WriteLine("\nPress any key and lets fire up the boilers and ship off!");
                    Console.ReadLine();
                    tutorialBool = true;
                }
                else if (tutorialInput == "n" || tutorialInput == "N")
                {
                    Console.WriteLine("\nLooks like we got ourselves a hero! Press any key and lets see what you got!");
                    Console.ReadLine();
                    tutorialBool = true;
                }
                else
                {
                    Console.WriteLine("Incorrect Input ensign! Press any key to resume!");
                }   
            }
            return tutorialBool;

        }

        public static void PlayBattleShip()
        {
            Console.Clear();
            Console.WriteLine("\nLets play Battlships!!");
            var shotsFired = 0;
            PlaceBattleShipOnGrid();
            while (shotsFired < 9)
            {
                Console.WriteLine("\n(X-axis) - Select a spot [1-10] to fire upon");
                var XValue = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n(Y-axis) - Select a spot [1-10] to fire upon");
                var YValue = Convert.ToInt32(Console.ReadLine());
                if (ShipHit(XValue, YValue))
                {
                    Console.WriteLine("\nHit!");
                } else
                {
                    Console.WriteLine("\nMiss");
                }
                shotsFired++;
            }
        }

        


    }
}
