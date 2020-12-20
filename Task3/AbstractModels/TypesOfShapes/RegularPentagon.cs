using System;
using Task3.AbstractModels;
using Task3.Validation;

namespace Task3.AbstractModels.TypesOfShapes
{
    public abstract class RegularPentagon : Shape
    {
        public RegularPentagon(Shape shape)
        {
                shape.CutNewShape();

                double length = shape.SideOfSmallestLength * CutRatio;

                LengthsOfSides = new double[5] { length, length, length, length, length };

                Perimeter = length * 5;

                Area =  Math.Sqrt(25+Math.Sqrt(5)*10)* length * length / 4 ;

                SideOfSmallestLength = LengthsOfSides[0];

            if (shape.Color != ShapeColor.Transparent)
            {
                Paint(shape.Color);
            }
        }
        public RegularPentagon(params double[] lengthsOfSides)
        {
            if (!CreatingShapesValidation.IsRegularPentagon(lengthsOfSides))
                throw new ArgumentException();
            if (lengthsOfSides.Length == 5)
            {
                LengthsOfSides = lengthsOfSides;
            }
            else
            {
                LengthsOfSides = new double[5] { lengthsOfSides[0], lengthsOfSides[0], lengthsOfSides[0], lengthsOfSides[0], lengthsOfSides[0] };
            }

            Perimeter = LengthsOfSides[0] * 5;


            Area = Math.Sqrt(25 + Math.Sqrt(5) * 10) * LengthsOfSides[0] * LengthsOfSides[0] / 4;

            SideOfSmallestLength = LengthsOfSides[0];
        }
    }
}

