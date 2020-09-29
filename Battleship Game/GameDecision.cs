using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship_Game
{
    class GameDecision
    {
        static int[,] UserGuesses = new int[8, 2];
        static int[,] battleshipPositions = Battleships.BattleshipPositions;
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
                        }
                        else
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
                        if (XValue == battleshipPositions[i, j])
                        {
                            XMatches = true;
                        }
                    }
                    else
                    {
                        if (YValue == battleshipPositions[i, j])
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
        public static bool InputValidation(int XValue, int YValue)
        {
            if ((XValue > 0 && XValue < 11) && (YValue > 0 && YValue < 11))
            {
                return true;
            }
            return false;
        }
    }
}
