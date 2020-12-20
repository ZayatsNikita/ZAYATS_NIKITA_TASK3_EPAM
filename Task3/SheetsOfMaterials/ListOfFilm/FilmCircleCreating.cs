using System;
using Task3.AbstractModels;
using Task3.ModelsOfGeometricShapes.FilmShapes;
namespace Task3.SheetsOfMaterials.ListOfFilm
{
    /// <summary>
    /// The class that is responsible for cutting out the FilmCircle.
    /// </summary>
    internal class FilmCircleCreating : IСuttingShape
    {
        /// <summary>
        /// Method that cuts out  FilmCircle.
        /// </summary>
        /// <param name="lengthOfSodes">length of the sides of the shape.</param>
        /// <returns>new  FilmCircle.</returns>
        /// <exception cref="InvalidOperationException">Thrown if a one of sides was passed less than or equal to zero.</exception>
        public Shape CutShape(double[] lengthOfSodes)
        {
                return new FilmCircle(lengthOfSodes);
        }
    }
}
