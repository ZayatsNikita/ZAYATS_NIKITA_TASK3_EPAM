using System;
using Task3.Validation;

namespace Task3.AbstractModels.TypesOfShapes
{
    /// <summary>
    /// Сlass that describes a Rectangle.
    /// </summary>
    public abstract class Rectangle : Shape
    {
        /// <summary>
        /// A constructor that cuts rectengle from another shape.
        /// </summary>
        /// <param name="shape">The shape from which the new rectengle will be cut.</param>
        /// <exception cref="InvalidOperationException">Throw if another shape has already been cut from the shape.</exception>
        public Rectangle(Shape shape)
        {
                shape.CutNewShape();

                double lengthOfSize = shape.SideOfSmallestLength * CutRatio;

                LengthsOfSides = new double[2] { lengthOfSize, lengthOfSize };

                Perimeter = 2 * (LengthsOfSides[0] + LengthsOfSides[1]);

                Area = LengthsOfSides[0] * LengthsOfSides[1];

                SideOfSmallestLength = LengthsOfSides[0] > LengthsOfSides[1] ? LengthsOfSides[1] : LengthsOfSides[0];

            if (shape.Color != ShapeColor.Transparent)
            {
                Paint(shape.Color);
            }
        }

        /// <summary>
        /// Constructor that creates a rectengle with a given sides.
        /// </summary>
        /// <param name="lengthsOfSides">The length of the sides.<para>It is possible to transfer one side, all other sides will get the same value.</para></param>
        /// <exception cref="InvalidOperationException">Thrown if a one of sides was passed less than or equal to zero.</exception>
        public Rectangle(params double[] lengthsOfSides)
        {
            if (!CreatingShapesValidation.IsRectangle(lengthsOfSides))
                throw new ArgumentException();

            if (lengthsOfSides.Length == 1)
            {
                LengthsOfSides = new double[2] { lengthsOfSides[0], lengthsOfSides[0] };
                SideOfSmallestLength = lengthsOfSides[0];
            }
            else
            {
                LengthsOfSides = lengthsOfSides;
            }
            SideOfSmallestLength = LengthsOfSides[0] > LengthsOfSides[1] ? LengthsOfSides[1] : LengthsOfSides[0];
            Perimeter = 2 * (LengthsOfSides[0] + LengthsOfSides[1]);
            Area = LengthsOfSides[0] * LengthsOfSides[1];
        }
    }
}

