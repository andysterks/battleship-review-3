using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship_Game
{
    class Prompts
    {
        public static bool GameIntro()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Do you want play Battleship?! (Y or N) : ");
                var playGameInput = Console.ReadLine();
                if (playGameInput == "y" || playGameInput == "Y")
                {
                    return true;
                }
                else if (playGameInput == "n" || playGameInput == "N")
                {
                    Console.Write("\nYou don't really have a choice ensign! Press Enter and get ready for war!");
                    Console.ReadLine();
                    return true;
                }
                else
                {
                    Console.Write("\nIncorrect Input press Enter to resume.");
                    Console.ReadLine();
                }
            }
        }
        public static bool PlayAgainPrompt()
        {
            while (true)
            {
                Console.Write("\nWould you like to play again!? (Y or N) : ");
                var playGameInput = Console.ReadLine();
                if (playGameInput == "y" || playGameInput == "Y")
                {
                    return true;
                }
                else if (playGameInput == "n" || playGameInput == "N")
                {
                    Console.Write("\nGood Bye");
                    System.Environment.Exit(0);
                    return false;
                }
                else
                {
                    Console.Write("\nIncorrect Input press Enter to resume.");
                    Console.ReadLine();
                }
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
                    GameGrid.PrintGrid();
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
    }
}
