using Task3.AbstractModels;
using System;
using Task3.ModelsOfGeometricShapes.PlasticShapes;
namespace Task3.SheetsOfMaterials.ListOfPlastic
{
    /// <summary>
    /// The class that is responsible for cutting out the  PlasticRegularPentagon.
    /// </summary>
    internal class PlasticRegularPentagonCreating : IСuttingShape
    {
        /// <summary>
        /// Method that cuts out  PlasticRegularPentagon.
        /// </summary>
        /// <param name="lengthOfSodes">length of the sides of the shape.</param>
        /// <returns>new  PlasticRegularPentagon.</returns>
        /// <exception cref="InvalidOperationException">Thrown if a one of sides was passed less than or equal to zero.</exception>
        public Shape CutShape(double[] lengthOfSodes)
        {
            PlasticRegularPentagon shaple = new PlasticRegularPentagon(lengthOfSodes);
            return shaple;
        }
    }
}
