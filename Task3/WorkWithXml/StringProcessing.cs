using System;
using System.Collections.Generic;
using System.Text;
using Task3.AbstractModels;
using Task3.SheetsOfMaterials;
using System.Text.RegularExpressions;
namespace Task3.WorkWithXml
{
    class StringProcessing
    {
        private static Regex extractingDouble;
        private static Regex itemShapeRegex;
        static StringProcessing()
        {
            string finalPatternForShape = @"<(?<shapeType>(?<material>Paper|Film|Plastic)(?<shapeForm>[A-z]+))\scolor=""(?<shapeColor>[A-z]+)""\sintegrity=""(?<integrity>True|False)"">\r\n\s+<count_of_sides>(?<countOfSides>\d+)</count_of_sides>\r\n\s+(?<lengthOfSides>(<double>\d+[,]?\d*</double>\r\n\s+)+)";
            itemShapeRegex = new Regex(finalPatternForShape);
            extractingDouble = new Regex(@"\d+[,]?\d*");
        }
        public static List<Shape> GetDescriptionOfTheShape(string forProcessing)
        {
                
                    double[] lengthOfsides;
                    List<Shape> listOfShape = new List<Shape>();
                
                    MatchCollection matches = itemShapeRegex.Matches(forProcessing);
                    if(matches.Count!=0)
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
                        
                        listOfShape.Add(UniversalSheet.CutShape(match.Groups["shapeType"].Value, lengthOfsides, color, integrity));

                        }
                        return listOfShape;
                    }
                    throw new FormatException();
            
        }

    }
}
