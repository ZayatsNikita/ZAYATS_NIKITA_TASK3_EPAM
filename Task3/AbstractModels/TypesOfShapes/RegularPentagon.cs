using System;
using Task3.Validation;

namespace Task3.AbstractModels.TypesOfShapes
{
    /// <summary>
    /// Сlass that describes a Regular Pentagon.
    /// </summary>
    public abstract class RegularPentagon : Shape
    {
        /// <summary>
        /// A constructor that cuts regular pentagon from another shape.
        /// </summary>
        /// <param name="shape">The shape from which the new regular pentagon will be cut.</param>
        /// <exception cref="InvalidOperationException">Throw if another shape has already been cut from the shape.</exception>
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


        /// <summary>
        /// Constructor that creates a regular pentagon with a given sides.
        /// </summary>
        /// <param name="lengthsOfSides">The length of the sides.<para>It is possible to transfer one side, all other sides will get the same value.</para></param>
        /// <exception cref="InvalidOperationException">Thrown if a one of sides was passed less than or equal to zero.</exception>
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

