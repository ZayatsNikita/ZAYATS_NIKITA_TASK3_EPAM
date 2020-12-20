using System;

namespace Task3
{
    /// <summary>
    /// A class that contains extension methods for string arrays.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Method that returns the index of the specified string.
        /// </summary>
        /// <param name="array">Array for seach.</param>
        /// <param name="forSeach">A string whose index is to be found.</param>
        /// <returns>True if the array contains the required element, otherwise return False.</returns>
        public static bool DoesItContain(this string[] array, string forSeach)
        {
            if (array == null || forSeach == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                foreach(string str in array)
                {
                    if(forSeach == str)
                    {
                        return true;
                    }
                }
                return false;

            }
        }
        /// <summary>
        /// Method that checks whether the array contains a string equal to the specified one.
        /// </summary>
        /// <param name="array">Array for seach.</param>
        /// <param name="forSeach">A string whose existence you want to check.</param>
        /// <returns>The index of a string in the specified array, if there is no such string, is returned minus 1.</returns>
        public static int intdefOf(this string[] array, string forSeach)
        {
            if (array == null || forSeach == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                int length = array.Length;
                for (int index = 0; index < length; index++)
                {
                    if (forSeach == array[index])
                    {
                        return index;
                    }
                }
                return -1;

            }

        }
    }
}
