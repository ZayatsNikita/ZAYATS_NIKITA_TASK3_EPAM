using System;
using Task3.AbstractModels;
using Task3.ModelsOfGeometricShapes.FilmShapes;

namespace Task3.SheetsOfMaterials.ListOfFilm
{
    /// <summary>
    /// The class that is responsible for cutting out the  FilmRectangle.
    /// </summary>
    internal class FilmRectangleCreating : IСuttingShape
    {
        /// <summary>
        /// Method that cuts out  FilmRectangle.
        /// </summary>
        /// <param name="lengthOfSodes">Length of the sides of the shape.</param>
        /// <returns>new  FilmRectangle.</returns>
        /// <exception cref="InvalidOperationException">Thrown if a one of sides was passed less than or equal to zero.</exception>
        public Shape CutShape(double[] lengthOfSodes)
        {
            return new FilmRectangle(lengthOfSodes);
        }
    }
}
