using Task3.AbstractModels;
using Task3.ModelsOfGeometricShapes.PaperShapes;

namespace Task3.SheetsOfMaterials.ListOfPaper
{
    /// <summary>
    /// The class that is responsible for cutting out the  PaperTriangle.
    /// </summary>
    internal class PaperTriangleCreating : IСuttingShape
    {
        /// <summary>
        /// Method that cuts out  PaperTriangle.
        /// </summary>
        /// <param name="lengthOfSodes">Length of the sides of the shape.</param>
        /// <returns>new  PaperTriangle.</returns>
        /// <exception cref="InvalidOperationException">Thrown if a one of sides was passed less than or equal to zero.</exception>
        public Shape CutShape(double[] lengthOfSodes)
        {
            PaperTriangle shaple = new PaperTriangle(lengthOfSodes);
            return shaple;
        }
    }
}
