using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Task3.AbstractModels;
using Task3.SheetsOfMaterials;
namespace Task3.WorkWithXml
{
    /// <summary>
    /// A class that processes strings that store information about shapes
    /// </summary>
    internal class StringProcessing
    {
        private static Regex extractingDouble;
        private static Regex itemShapeRegex;
        /// <summary>
        /// Static constructor that sets parameters for shape recognition
        /// </summary>
        static StringProcessing()
        {
            string finalPatternForShape = @"<(?<shapeType>(?<material>Paper|Film|Plastic)(?<shapeForm>[A-z]+))\scolor=""(?<shapeColor>[A-z]+)""\sintegrity=""(?<integrity>True|False)"">\r\n\s+<count_of_sides>(?<countOfSides>\d+)</count_of_sides>\r\n\s+(?<lengthOfSides>(<double>\d+[,]?\d*</double>\r\n\s+)+)";
            itemShapeRegex = new Regex(finalPatternForShape);
            extractingDouble = new Regex(@"\d+[,]?\d*");
        }
        /// <summary>
        /// A method that extracts information about shapes from a string and creates a list of shapes based on this information.
        /// </summary>
        /// <param name="forProcessing">String for extracting information.</param>
        /// <returns>List of shapes that you were able to extract information about.</returns>
        /// <exception cref="FormatException">Throw if the line does not contain information that meets the requirements</exception>
        internal static List<Shape> GetDescriptionOfTheShape(string forProcessing)
        {
                double[] lengthOfsides;
                List<Shape> listOfShape = new List<Shape>();
                MatchCollection matches = itemShapeRegex.Matches(forProcessing);
                if (matches.Count != 0)
                {
                    foreach (Match match in matches)
                    {
                        MatchCollection doubleNums = extractingDouble.Matches(match.Groups["lengthOfSides"].Value);
                        lengthOfsides = new double[doubleNums.Count];

                        for (int index = 0; index < lengthOfsides.Length; index++)
                        {
                            lengthOfsides[index] = Double.Parse(doubleNums[index].Value);
                        }

                        ShapeColor color = (ShapeColor)Enum.Parse(typeof(ShapeColor), match.Groups["shapeColor"].Value);

                        bool integrity = Boolean.Parse(match.Groups["integrity"].Value);
                        try
                        {
                            listOfShape.Add(UniversalSheet.CutShape(match.Groups["shapeType"].Value, lengthOfsides, color, integrity));
                        }
                        catch (ArgumentException)
                        {
                            throw new FormatException();
                        }
                        catch (InvalidOperationException)
                        {
                            throw new FormatException();
                        }
                    }

                    return listOfShape;
                }
                throw new FormatException();
        }

    }
}
