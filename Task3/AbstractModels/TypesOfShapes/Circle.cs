using System;
using Task3.Validation;

namespace Task3.AbstractModels.TypesOfShapes
{
    /// <summary>
    /// Сlass that describes a Сircle.
    /// </summary>
    public abstract class Circle : Shape
    {
        /// <summary>
        /// A constructor that cuts circle from another shape.
        /// </summary>
        /// <param name="shape">The shape from which the new circle will be cut.</param>
        /// <exception cref="InvalidOperationException">Throw if another shape has already been cut from the shape.</exception>
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
        /// <summary>
        /// Constructor that creates a circle with a given diameter.
        /// </summary>
        /// <param name="lengthsOfSides">The length of the diameter.</param>
        /// <exception cref="InvalidOperationException">Thrown if a number less than or equal to zero zero was passed.</exception>
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