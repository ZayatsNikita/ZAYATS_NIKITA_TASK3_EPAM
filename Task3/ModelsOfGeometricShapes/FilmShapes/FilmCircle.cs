using System;
using Task3.AbstractModels;
using Task3.AbstractModels.Materials;
using Task3.AbstractModels.TypesOfShapes;

namespace Task3.ModelsOfGeometricShapes.FilmShapes
{
    /// <summary>
    /// Сlass that describes a Film Сircle.
    /// </summary>
    public class FilmCircle :Circle ,IFilm
    {
        /// <summary>
        /// A constructor that cuts film circle from another film shape.
        /// </summary>
        /// <param name="shape">The shape from which the new circle will be cut.</param>
        /// <exception cref="InvalidOperationException">Throw if another shape has already been cut from the shape.</exception>
        ///  <exception cref="ArgumentException">Throw if the shape is not made of film.</exception>
        public FilmCircle(Shape shape) : base(shape)
        {
            if(shape.GetType().GetInterface("Task3.AbstractModels.Materials.IFilm") ==null)
            {
                throw new ArgumentException();
            }
        }
        /// <summary>
        /// Constructor that creates a paper circle with a given diameter.
        /// </summary>
        /// <param name="lengthsOfSides">The length of the diameter.</param>
        /// <exception cref="InvalidOperationException">Thrown if a number less than or equal to zero zero was passed.</exception>
        public FilmCircle(params double[] lengthsOfSides) : base(lengthsOfSides)
        { 
        }
        /// <summary>
        /// The method that is responsible for painting the film circle.
        /// </summary>
        /// <param name="color">The new color of the shape.</param>
        /// <exception cref="InvalidOperationException">Throw if the shape is trying to paint.</exception>
        /// <remarks>Shape from the film can not be painted</remarks>
        public override void Paint(ShapeColor color)
        {
            throw new InvalidOperationException();
        }
    }
}
