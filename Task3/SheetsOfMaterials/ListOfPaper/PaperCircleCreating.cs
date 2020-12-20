﻿using Task3.AbstractModels;
using Task3.ModelsOfGeometricShapes.PaperShapes;

namespace Task3.SheetsOfMaterials.ListOfPaper
{
    /// <summary>
    /// The class that is responsible for cutting out the  PaperCircle.
    /// </summary>
    internal class PaperCircleCreating : IСuttingShape
    {
        /// <summary>
        /// Method that cuts out  PaperCircle.
        /// </summary>
        /// <param name="lengthOfSodes">Length of the sides of the shape.</param>
        /// <returns>new  PaperCircle.</returns>
        /// <exception cref="InvalidOperationException">Thrown if a one of sides was passed less than or equal to zero.</exception>
        public Shape CutShape(double[] lengthOfSodes)
        {
            PaperCircle shaple = new PaperCircle(lengthOfSodes);
            return shaple;
        }
    }
}
