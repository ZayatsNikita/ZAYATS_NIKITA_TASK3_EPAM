using Task3.AbstractModels;
using Task3.ModelsOfGeometricShapes.PaperShapes;

namespace Task3.SheetsOfMaterials.ListOfPaper
{
    /// <summary>
    /// The class that is responsible for cutting out the  PaperRegularPentagon.
    /// </summary>
    internal class PaperRegularPentagonCreating : IСuttingShape
    {
        /// <summary>
        /// Method that cuts out  PaperRegularPentagon.
        /// </summary>
        /// <param name="lengthOfSodes">Length of the sides of the shape.</param>
        /// <returns>new  PaperRegularPentagon.</returns>
        /// <exception cref="InvalidOperationException">Thrown if a one of sides was passed less than or equal to zero.</exception>
        public Shape CutShape(double[] lengthOfSodes)
        {
            PaperRegularPentagon shaple = new PaperRegularPentagon(lengthOfSodes);
            return shaple;
        }
    }
}
