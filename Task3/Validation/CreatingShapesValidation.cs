using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Task3.Validation
{
    static public class CreatingShapesValidation
    {
        static public bool IsTreangle(in double[] lengthsOfSides)
        {
            if ((lengthsOfSides?.Length ?? 0) == 0 || (lengthsOfSides.Length != 3) && (lengthsOfSides.Length != 1))
                return false;

            if (AreThereAnyNegativeElements(lengthsOfSides))
            {
                return false;
            }

            if (lengthsOfSides.Length == 1 || (lengthsOfSides.Length == 3 && (lengthsOfSides[0] == lengthsOfSides[1] && lengthsOfSides[0] == lengthsOfSides[2])))
            {
                return true;
            }
            else
            {
                int maxIndex = lengthsOfSides[0] < lengthsOfSides[1] ? 1 : 0;
                maxIndex = lengthsOfSides[maxIndex] < lengthsOfSides[2] ? 2 : maxIndex;
                if (lengthsOfSides[0] == lengthsOfSides[1] || maxIndex == 2)
                {
                    if (!(lengthsOfSides[2] < lengthsOfSides[0] + lengthsOfSides[1]))
                        return false;
                }
                if (lengthsOfSides[0] == lengthsOfSides[2] || maxIndex == 1)
                {
                    if (!(lengthsOfSides[1] < lengthsOfSides[0] + lengthsOfSides[2]))
                        return false;
                }
                if (lengthsOfSides[1] == lengthsOfSides[2] || maxIndex == 0)
                {
                    if (!(lengthsOfSides[0] < lengthsOfSides[1] + lengthsOfSides[2]))
                        return false;
                }
                return true;
            }

        }

        static public bool IsRectangle(in double[] lengthsOfSides)
        {
            if ((lengthsOfSides?.Length ?? 0) == 0 || (lengthsOfSides.Length != 2) && (lengthsOfSides.Length != 1))
            {
                return false;
            }
            return !AreThereAnyNegativeElements(lengthsOfSides);
            
        }
        static public bool IsCircle(in double[] lengthsOfSides)
        {
            if ((lengthsOfSides?.Length ?? 0) != 1)
            {
                return false;
            }
            return !AreThereAnyNegativeElements(lengthsOfSides);
        }

        static public bool IsRegularPentagon(in double[] lengthsOfSides)
        {
            if ((lengthsOfSides?.Length ?? 0) != 1 && lengthsOfSides.Length != 5)
                return false;
            if (lengthsOfSides.Length == 5)
            {
                for (int i = 1; i < 5; i++)
                {
                    if(lengthsOfSides[i] != lengthsOfSides[i-1])
                    {
                        return false;
                    }
                }
            }
            return !AreThereAnyNegativeElements(lengthsOfSides);
        }


        private static bool AreThereAnyNegativeElements(in double[] lengthsOfSides)
        {
            foreach (double value in lengthsOfSides)
            {
                if (value <= 0)
                    return true;
            };
            return false;
        }
    }
}
