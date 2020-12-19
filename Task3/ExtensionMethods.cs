using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public static class ExtensionMethods
    {
        public static bool DoesItContain(this string[] array, string forSeach)
        {
            if (array == null)
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
    }
}
