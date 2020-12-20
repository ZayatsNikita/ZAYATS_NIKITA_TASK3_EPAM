using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Task3.Validation;

namespace Task3.AbstractModels.TypesOfShapes
{
    /// <summary>
    /// Сlass that describes a Triangle.
    /// </summary>
    public abstract class Triangle : Shape
    {
        /// <summary>
        /// A constructor that cuts triangle from another shape.
        /// </summary>
        /// <param name="shape">The shape from which the new triangle will be cut.</param>
        /// <exception cref="InvalidOperationException">Throw if another shape has already been cut from the shape.</exception>
        public Triangle(Shape shape)
        {   
                shape.CutNewShape();

                double lengthOfSize = shape.SideOfSmallestLength * CutRatio;

                LengthsOfSides = new double[3] { lengthOfSize, lengthOfSize, lengthOfSize };

                Perimeter = LengthsOfSides[0] + LengthsOfSides[1] + LengthsOfSides[2];

                double semiperimeter = Perimeter / 2;

                Area = Math.Sqrt(semiperimeter * (semiperimeter - LengthsOfSides[0]) * (semiperimeter - LengthsOfSides[1]) * (semiperimeter - LengthsOfSides[2]));

                SideOfSmallestLength = LengthsOfSides.Min();

            if (shape.Color != ShapeColor.Transparent)
            {
                Paint(shape.Color);
            }
        }
        /// <summary>
        /// Constructor that creates a triangle with a given sides.
        /// </summary>
        /// <param name="lengthsOfSides">The length of the sides.<para>It is possible to transfer one side, all other sides will get the same value.</para></param>
        /// <exception cref="InvalidOperationException">Thrown if a one of sides was passed less than or equal to zero.</exception>
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
    }
}

