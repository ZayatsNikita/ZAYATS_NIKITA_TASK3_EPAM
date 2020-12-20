using System;
using Task3.AbstractModels.TypesOfShapes;
using Task3.AbstractModels;
using Task3.AbstractModels.Materials;

namespace Task3.ModelsOfGeometricShapes.PlasticShapes
{
    /// <summary>
    /// Сlass that describes a Plastic Triangle.
    /// </summary>
    public class PlasticTriangle : Triangle,IPlastic
    {
        /// <summary>
        /// A constructor that cuts plastic triangle from another shape.
        /// </summary>
        /// <param name="shape">The plastic shape from which the new triangle will be cut.</param>
        /// <exception cref="InvalidOperationException">Throw if another shape has already been cut from the shape.</exception>
        /// <exception cref="ArgumentException">Throw if the shape is not made of plastic.</exception>
        public PlasticTriangle(Shape shape) : base(shape)
        {
            if (shape.GetType().GetInterface("Task3.AbstractModels.Materials.IPlastic") == null)
            {
                throw new ArgumentException();
            }
        }
        /// <summary>
        /// Constructor that creates a plastic triangle with a given sides.
        /// </summary>
        /// <param name="lengthsOfSides">The length of the sides.<para>It is possible to transfer one side, all other sides will get the same value.</para></param>
        /// <exception cref="InvalidOperationException">Thrown if a one of sides was passed less than or equal to zero.</exception>
        public PlasticTriangle(params double[] lengthsOfSides) : base(lengthsOfSides)
        {
        }
        /// <summary>
        /// The method that is responsible for painting the plastic trangle.
        /// </summary>
        /// <param name="color">The new color of the plastic trangle.</param>
        /// <exception cref="ArgumentException">Throw if the figure is trying to be repainted in a transparent color.</exception>
        public override void Paint(ShapeColor color)
        {
            base.Paint(color);
            _color = color;
        }
    }
}
