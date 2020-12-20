namespace Task3.Validation
{
    /// <summary>
    /// A class that provides the ability to check the sides for compliance with certain geometric shapes.
    /// </summary>
    static internal class CreatingShapesValidation
    {
        /// <summary>
        /// A method that checks whether it is possible to get a triangle from the specified sides.
        /// </summary>
        /// <param name="lengthsOfSides">The lengths of the sides.</param>
        /// <returns>True if you can create a triangle, False otherwise.</returns>
        static internal bool IsTreangle(in double[] lengthsOfSides)
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

        /// <summary>
        /// A method that checks whether it is possible to get a rectangle from the specified sides.
        /// </summary>
        /// <param name="lengthsOfSides">The lengths of the sides.</param>
        /// <returns>True if you can create a rectangle, False otherwise.</returns>
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

        /// <summary>
        /// A method that checks whether it is possible to get a regular pentagon from the specified sides.
        /// </summary>
        /// <param name="lengthsOfSides">The lengths of the sides.</param>
        /// <returns>True if you can create a regular pentagon, False otherwise.</returns>
        static internal bool IsRegularPentagon(in double[] lengthsOfSides)
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

        /// <summary>
        /// A method that checks an array of sides for negative length sides.
        /// </summary>
        /// <param name="lengthsOfSides">The lengths of the sides.</param>
        /// <returns>True if there are negative sides in array, False in otherwise</returns>
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
