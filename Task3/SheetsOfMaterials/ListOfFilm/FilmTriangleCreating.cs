using System;
using System.Collections.Generic;
using System.Text;
using Task3.AbstractModels;
using Task3.ModelsOfGeometricShapes.FilmShapes;
namespace Task3.SheetsOfMaterials.ListOfFilm
{
    /// <summary>
    /// The class that is responsible for cutting out the  FilmTriangle.
    /// </summary>
    internal class FilmTriangleCreating : IСuttingShape
    {
        /// <summary>
        /// Method that cuts out  FilmTriangle.
        /// </summary>
        /// <param name="lengthOfSodes">Length of the sides of the shape.</param>
        /// <returns>new  FilmTriangle.</returns>
        /// <exception cref="InvalidOperationException">Thrown if a one of sides was passed less than or equal to zero.</exception>
        public Shape CutShape(double[] lengthOfSodes)
        {
                return new FilmTriangle(lengthOfSodes);
        }
    }
}
