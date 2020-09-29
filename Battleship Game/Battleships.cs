using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship_Game
{
    class Battleships
    {

        public static int[,] BattleshipPositions = new int[5, 2];
        public static void createBattleship()
        {
            Random rand = new Random();

            int initXValue = rand.Next(1, 10);
            int initYValue = rand.Next(1, 10);
            BattleshipPositions[0, 0] = initXValue;
            BattleshipPositions[0, 1] = initYValue;

            if ((initXValue == 5 || initXValue == 6) && (initYValue == 5 || initYValue == 6))
            {
                setBattleshipOnGrid(initXValue, initYValue, getDirection(true, true, true, true));
            }
            else if ((initXValue == 5 || initXValue == 6) && initYValue < 5)
            {
                setBattleshipOnGrid(initXValue, initYValue, getDirection(true, true, true, false));
            }
            else if ((initXValue == 5 || initXValue == 6) && initYValue > 6)
            {
                setBattleshipOnGrid(initXValue, initYValue, getDirection(true, true, false, true));
            }
            else if (initXValue < 5 && (initYValue == 5 || initYValue == 6))
            {
                setBattleshipOnGrid(initXValue, initYValue, getDirection(false, true, true, true));
            }
            else if (initXValue > 6 && (initYValue == 5 || initYValue == 6))
            {
                setBattleshipOnGrid(initXValue, initYValue, getDirection(true, false, true, true));
            }
            else if (initXValue < 5 && initYValue < 5)
            {
                setBattleshipOnGrid(initXValue, initYValue, getDirection(false, true, true, false));
            }
            else if (initXValue < 5 && initYValue > 6)
            {
                setBattleshipOnGrid(initXValue, initYValue, getDirection(false, true, false, true));
            }
            else if (initXValue > 6 && initYValue < 5)
            {
                setBattleshipOnGrid(initXValue, initYValue, getDirection(true, false, true, false));
            }
            else if (initXValue > 6 && initYValue > 6)
            {
                setBattleshipOnGrid(initXValue, initYValue, getDirection(true, false, false, true));
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
                }
                else if (direction == 2)
                {
                    return "right";
                }
                else if (direction == 3)
                {
                    return "up";
                }
                else if (direction == 4)
                {
                    return "down";
                }
            }
            else if (left && right && !up && down)
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

            }
            else if (left && right && up && !down)
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

            }
            else if (!left && right && up && down)
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

            }
            else if (left && !right && up && down)
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

            }
            else if (!left && right && up && !down)
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

            }
            else if (!left && right && !up && down)
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

            }
            else if (left && !right && up && !down)
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

            }
            else if (left && !right && !up && down)
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
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            x--;
                            BattleshipPositions[i, j] = x;
                        }
                        else
                        {
                            BattleshipPositions[i, j] = Yinit;
                        }
                    }
                }
            }
            else if (direction == "right")
            {
                int x = Xinit;
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            x++;
                            BattleshipPositions[i, j] = x;
                        }
                        else
                        {
                            BattleshipPositions[i, j] = Yinit;
                        }
                    }
                }

            }
            else if (direction == "up")
            {
                int y = Yinit;
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            BattleshipPositions[i, j] = Xinit;
                        }
                        else
                        {
                            y++;
                            BattleshipPositions[i, j] = y;
                        }
                    }
                }
            }
            else if (direction == "down")
            {
                int y = Yinit;
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            BattleshipPositions[i, j] = Xinit;
                        }
                        else
                        {
                            y--;
                            BattleshipPositions[i, j] = y;
                        }
                    }
                }
            }
        }

    }
}
