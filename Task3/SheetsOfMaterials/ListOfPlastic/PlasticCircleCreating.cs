using System;
using Task3.AbstractModels;
using Task3.ModelsOfGeometricShapes.PlasticShapes;
namespace Task3.SheetsOfMaterials.ListOfPlastic
{
    /// <summary>
    /// The class that is responsible for cutting out the  PlasticCircle.
    /// </summary>
    internal class PlasticCircleCreating : IСuttingShape
    {
        /// <summary>
        /// Method that cuts out  PlasticCircle.
        /// </summary>
        /// <param name="lengthOfSodes">Length of the sides of the shape.</param>
        /// <returns>new  PlasticCircle.</returns>
        /// <exception cref="InvalidOperationException">Thrown if a one of sides was passed less than or equal to zero.</exception>

        public Shape CutShape(double[] lengthOfSodes)
        {
            PlasticCircle shaple = new PlasticCircle(lengthOfSodes);
            return shaple;
        }
    }
}
