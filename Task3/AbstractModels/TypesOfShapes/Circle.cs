using System;
using Task3.Validation;

namespace Task3.AbstractModels.TypesOfShapes
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Circle : Shape
    {
        public Circle(Shape shape)
        {

                shape.CutNewShape();

                LengthsOfSides = new double[1] { shape.SideOfSmallestLength * CutRatio };

                Perimeter = LengthsOfSides[0] * Math.PI;

                Area = Math.PI * LengthsOfSides[0]/2 * LengthsOfSides[0]/2;

                SideOfSmallestLength = LengthsOfSides[0];

                if (shape.Color != ShapeColor.Transparent)
                {
                    Paint(shape.Color);
                }
        }
        public Circle(params double[] lengthsOfSides)
        {
            if (!CreatingShapesValidation.IsCircle(lengthsOfSides))
                throw new ArgumentException();

            LengthsOfSides = lengthsOfSides;

            Perimeter = LengthsOfSides[0] * Math.PI;

            Area = Math.PI * LengthsOfSides[0] / 2 * LengthsOfSides[0] / 2;
        }
    }
}