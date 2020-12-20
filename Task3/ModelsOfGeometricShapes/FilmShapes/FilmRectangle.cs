﻿using System;
using Task3.AbstractModels;
using Task3.AbstractModels.Materials;
using Task3.AbstractModels.TypesOfShapes;

namespace Task3.ModelsOfGeometricShapes.FilmShapes
{
    public class FilmRectangle : Rectangle,IFilm
    {
        /// <summary>
        /// A constructor that cuts film rectangle from another film shape.
        /// </summary>
        /// <param name="shape">The shape from which the new rectangle will be cut.</param>
        /// <exception cref="InvalidOperationException">Throw if another shape has already been cut from the shape.</exception>
        ///  <exception cref="ArgumentException">Throw if the shape is not made of film.</exception>
        public FilmRectangle(Shape shape) : base(shape)
        {
            if (shape.GetType().GetInterface("Task3.AbstractModels.Materials.IFilm") == null)
            {
                throw new ArgumentException();
            }
        }
        /// <summary>
        /// Constructor that creates a film rectangle with a given sides.
        /// </summary>
        /// <param name="lengthsOfSides">The length of the sides.<para>It is possible to transfer one side, all other sides will get the same value.</para></param>
        /// <exception cref="InvalidOperationException">Thrown if a one of sides was passed less than or equal to zero.</exception>
        public FilmRectangle(params double[] lengthsOfSides) : base(lengthsOfSides)
        {
        }
        /// <summary>
        /// The method that is responsible for painting the film rectangle.
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
