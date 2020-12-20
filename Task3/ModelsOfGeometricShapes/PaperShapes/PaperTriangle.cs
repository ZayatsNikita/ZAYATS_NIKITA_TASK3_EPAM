using System;
using Task3.AbstractModels;
using Task3.AbstractModels.Materials;
using Task3.AbstractModels.TypesOfShapes;

namespace Task3.ModelsOfGeometricShapes.PaperShapes
{
    /// <summary>
    /// Сlass that describes a Paper Triangle.
    /// </summary>
    public class PaperTriangle : Triangle, IPaper
    {
        /// <summary>
        /// A constructor that cuts paper triangle from another paper shape.
        /// </summary>
        /// <param name="shape">The shape from which the new triangle will be cut.</param>
        /// <exception cref="InvalidOperationException">Throw if another shape has already been cut from the shape.</exception>
        ///  <exception cref="ArgumentException">Throw if the shape is not made of paper.</exception>
        public PaperTriangle(Shape shape):base(shape)
        {
            if (shape.GetType().GetInterface("Task3.AbstractModels.Materials.IPaper") == null)
            {
                throw new ArgumentException();
            }
        }
        /// <summary>
        /// Constructor that creates a paper triangle with a given sides.
        /// </summary>
        /// <param name="lengthsOfSides">The length of the sides.<para>It is possible to transfer one side, all other sides will get the same value.</para></param>
        /// <exception cref="InvalidOperationException">Thrown if a one of sides was passed less than or equal to zero.</exception>
        public PaperTriangle(params double[] lengthsOfSides):base(lengthsOfSides)
        {
        }
        /// <summary>
        /// The method that is responsible for painting the paper tiangle.
        /// </summary>
        /// <param name="color">The new color of the shape.</param>
        /// <exception cref="ArgumentException">Throw if the figure is trying to be repainted in a transparent color.</exception>
        /// <exception cref="InvalidOperationException">Throw when the shape is repainted again.</exception>
        public override void Paint(ShapeColor color)
        {
            if (Color != ShapeColor.Transparent)
            {
                throw new InvalidOperationException();
            }
            else
            {
                _color = color;
            }
        }
    }
}
