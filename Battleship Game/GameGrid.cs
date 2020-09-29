using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship_Game
{
    class GameGrid
    {
        static string[,] Grid = new string[11, 11];
        public static void InitializeGrid()
        {
            for (int i = 10; i >= 0; i--)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (i == 0)
                    {
                        Grid[i, j] = j.ToString();
                    }
                    else
                    {
                        if (j == 0)
                        {
                            Grid[i, j] = i.ToString();
                        }
                        else
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
            }
            else
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
                    }
                    else
                    {
                        Console.Write(Grid[i, j] + "  ");
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
