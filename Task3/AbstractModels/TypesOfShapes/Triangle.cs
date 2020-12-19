using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Task3.Validation;

namespace Task3.AbstractModels.TypesOfShapes
{
    public abstract class Triangle : Shape
    {
        public Triangle(Shape shape)
        {
            if (/*shape.GetType().BaseType == typeof(PaperShape)*/true)
            {
                shape.CutNewShape();

                double lengthOfSize = shape.SideOfSmallestLength * CutRatio;

                LengthsOfSides = new double[3] { lengthOfSize, lengthOfSize, lengthOfSize };

                Perimeter = LengthsOfSides[0] + LengthsOfSides[1] + LengthsOfSides[2];

                double semiperimeter = Perimeter / 2;

                Area = Math.Sqrt(semiperimeter * (semiperimeter - LengthsOfSides[0]) * (semiperimeter - LengthsOfSides[1]) * (semiperimeter - LengthsOfSides[2]));

                SideOfSmallestLength = LengthsOfSides.Min();

                Paint(shape.Color);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public Triangle(params double[] lengthsOfSides)
        {
            if (!CreatingShapesValidation.IsTreangle(lengthsOfSides))
                throw new ArgumentException();

            if (lengthsOfSides.Length == 1 || (lengthsOfSides.Length == 3 && (lengthsOfSides[0] == lengthsOfSides[1] && lengthsOfSides[0] == lengthsOfSides[2])))
            {
                LengthsOfSides = new double[3] { lengthsOfSides[0], lengthsOfSides[0], lengthsOfSides[0] };
                SideOfSmallestLength = lengthsOfSides[0];
            }
            else
            {
                LengthsOfSides = lengthsOfSides;
            }

            SideOfSmallestLength = LengthsOfSides[0] > LengthsOfSides[1] ? LengthsOfSides[1] : LengthsOfSides[0];
            SideOfSmallestLength = SideOfSmallestLength > LengthsOfSides[2] ? LengthsOfSides[2] : SideOfSmallestLength;

            Perimeter = LengthsOfSides[0] + LengthsOfSides[1] + LengthsOfSides[2];
            double semiperimeter = Perimeter / 2;
            Area = Math.Sqrt(semiperimeter * (semiperimeter - LengthsOfSides[0]) * (semiperimeter - LengthsOfSides[1]) * (semiperimeter - LengthsOfSides[2]));
        }
        public override double Area { get; protected set; }
        public override double Perimeter { get; protected set; }
    }
}

