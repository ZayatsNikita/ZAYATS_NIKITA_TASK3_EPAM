using System;
using Task3.AbstractModels;
using Task3.AbstractModels.Materials;
using Task3.AbstractModels.TypesOfShapes;

namespace Task3.ModelsOfGeometricShapes.PlasticShapes
{
    /// <summary>
    /// Сlass that describes a Plastic Circle.
    /// </summary>
    public class PlasticCircle : Circle,IPlastic
    {
        /// <summary>
        /// A constructor that cuts plastic сircle from another plastic shape.
        /// </summary>
        /// <param name="shape">The plastic shape from which the new circle will be cut.</param>
        /// <exception cref="InvalidOperationException">Throw if another shape has already been cut from the shape.</exception>
        /// <exception cref="ArgumentException">Throw if the shape is not made of plastic.</exception>
        public PlasticCircle(Shape shape) : base(shape)
        {
            if (shape.GetType().GetInterface("Task3.AbstractModels.Materials.IPlastic") == null)
            {
                throw new ArgumentException();
            }
        }
        /// <summary>
        /// Constructor that creates a plastic сircle with a given diameter.
        /// </summary>
        /// <param name="lengthsOfSides">The length of the diameter.</param>
        /// <exception cref="InvalidOperationException">Thrown if a number less than or equal to zero zero was passed.</exception>
        public PlasticCircle(params double[] lengthsOfSides) : base(lengthsOfSides)
        {
        }

        /// <summary>
        /// The method that is responsible for painting the plastic circle.
        /// </summary>
        /// <param name="color">The new color of the plastic circle.</param>
        /// <exception cref="ArgumentException">Throw if the figure is trying to be repainted in a transparent color.</exception>
        public override void Paint(ShapeColor color)
        {
            base.Paint(color);
            _color = color;
        }
    }
}
