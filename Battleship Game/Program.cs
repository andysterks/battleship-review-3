using System;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Schema;

namespace Battleship_Game
{
    class Program
    {
        static bool Alive = true;
        static bool PlayAgain = false;
        static bool PlayDecision = false;
        static void Main(string[] args)
        {
            while(Alive)
            { 
                GameGrid.InitializeGrid();
                Battleships.createBattleship();               
                if (!PlayAgain)
                {
                    PlayDecision = Prompts.GameIntro();
                }
                if (PlayDecision || PlayAgain)
                {
                    bool tutorialDecision = Prompts.Tutorial();
                    if (tutorialDecision)
                    {
                        PlayBattleShip();
                        if (!PlayAgain)
                        {
                            Alive = Prompts.PlayAgainPrompt();
                            PlayAgain = Alive;
                        } 
                        else
                        {
                            Alive = PlayAgain;
                        }
                        Console.Clear();
                    }
                }
            }

        }

        public static void PlayBattleShip()
        {
            int shotsFired = 0;
            int NumberOfHits = 0;
            int NumberOfMisses = 0;
            int XValue;
            int YValue;
            
            while (true)
            {
                Console.Clear();
                Console.Write("Shots Remaining = " + (8 - shotsFired));
                Console.Write(" Hits = " + NumberOfHits);
                Console.Write(" Misses = " + NumberOfMisses + "\n");
                GameGrid.PrintGrid();
                Console.Write("\n(X-axis) - Select a spot [1-10] to fire upon : ");
                while (!int.TryParse(Console.ReadLine(), out XValue)){
                    Console.Clear();
                    Console.WriteLine("---------Input needs to be a number!!---------\n");
                    Console.Write("Shots Remaining = " + (8 - shotsFired));
                    Console.Write(" Hits = " + NumberOfHits);
                    Console.Write(" Misses = " + NumberOfMisses + "\n");
                    GameGrid.PrintGrid();
                    Console.Write("\n(X-axis) - Select a spot [1-10] to fire upon : ");
                }
                Console.Write("\n(Y-axis) - Select a spot [1-10] to fire upon : ");
                while (!int.TryParse(Console.ReadLine(), out YValue))
                {
                    Console.Clear();
                    Console.WriteLine("---------Input needs to be a number!!---------\n");
                    Console.Write("Shots Remaining = " + (8 - shotsFired));
                    Console.Write(" Hits = " + NumberOfHits);
                    Console.Write(" Misses = " + NumberOfMisses + "\n");
                    GameGrid.PrintGrid();
                    Console.Write("\n(X-axis) - Select a spot [1-10] to fire upon : " + XValue + "\n");
                    Console.Write("\n(Y-axis) - Select a spot [1-10] to fire upon : ");
                }

                if (!GameDecision.InputValidation(XValue, YValue))
                {
                    Console.Clear();
                    Console.WriteLine("\nIncorrect Input ensign! Numbers from 1 - 10!!!! Press Enter to resume!\n");
                    Console.ReadLine();
                } 
                else 
                {
                    if (GameDecision.DetermineIfGuessed(XValue, YValue, shotsFired))
                    {
                        Console.Write("\nRookie mistake ensign! Choose a spot you haven't already shot at! Press Enter to resume!");
                        Console.ReadLine();
                        Console.Clear();
                    } 
                    else
                    {
                        if (GameDecision.DetermineHit(XValue, YValue))
                        {
                            NumberOfHits++;
                            Console.WriteLine("\nHit!\n");
                            Console.Write("Press Enter to resume!");
                            Console.ReadLine();
                        }
                        else
                        {
                            NumberOfMisses++;
                            Console.WriteLine("\nMiss!\n");
                            Console.Write("Press Enter to resume!");
                            Console.ReadLine();
                        }
                        GameGrid.EditGrid(XValue, YValue, GameDecision.DetermineHit(XValue, YValue));
                        shotsFired++;
                    }
                }

                if (NumberOfHits == 5)
                {
                    PlayAgain = false;
                    Console.Clear();
                    GameGrid.PrintGrid();
                    Console.WriteLine("\nCongratulations!! Youve Sunk the Battleship!");
                    break;
                }
                else if (shotsFired == 8)
                {
                    
                    PlayAgain = false;
                    Console.Clear();
                    Console.Write("Shots Remaining = " + (8 - shotsFired));
                    Console.Write(" Hits = " + NumberOfHits);
                    Console.Write(" Misses = " + NumberOfMisses + "\n");
                    GameGrid.PrintGrid();
                    Console.WriteLine("\nYou Lost!");
                    Console.WriteLine("Better Luck Next Time!");
                    break;
                }
                else if (shotsFired == 4 && NumberOfMisses == 4)
                {
                    bool restart = false;                
                    while (true)
                    {
                        Console.Clear();
                        Console.Write("\nListen kid, I'm going to be real with you...");
                        Console.Write("You're not going to win. Do you just want to restart? (Y or N) : ");
                        var PlayerInput = Console.ReadLine();
                        if (PlayerInput == "y" || PlayerInput == "Y")
                        {
                            restart = true;
                            break;
                        }
                        else if (PlayerInput == "n" || PlayerInput == "N")
                        {
                            restart = false;
                            break;
                        }
                        else
                        {
                            Console.Write("\nIncorrect Input press Enter to resume.");
                            Console.ReadLine();
                        }
                    }

                    if (restart)
                    {
                        PlayAgain = true;
                        break;
                    }
                }
            }
        }
    }
}