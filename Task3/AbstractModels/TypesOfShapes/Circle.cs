using System;
using Task3.Validation;
using Task3.AbstractModels;

namespace Task3.AbstractModels.TypesOfShapes
{
    public abstract class Circle : Shape
    {
        public Circle(Shape shape)
        {
            if (shape.GetType().GetInterfaces() == this.GetType().GetInterfaces())
            {
                shape.CutNewShape();

                LengthsOfSides = new double[1] { shape.SideOfSmallestLength * CutRatio };

                Perimeter = LengthsOfSides[0] * 2 * Math.PI;

                Area = Math.PI * LengthsOfSides[0] * LengthsOfSides[0];

                SideOfSmallestLength = LengthsOfSides[0];

                Paint(shape.Color);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public Circle(params double[] lengthsOfSides)
        {
            if (!CreatingShapesValidation.IsCircle(lengthsOfSides))
                throw new ArgumentException();

            LengthsOfSides = lengthsOfSides;

            Perimeter = LengthsOfSides[0] * 2 * Math.PI;

            Area = Math.PI * LengthsOfSides[0] * LengthsOfSides[0];

            SideOfSmallestLength = LengthsOfSides[0];
        }
        public override double Area { get; protected set; }
        public override double Perimeter { get; protected set; }
    }
}