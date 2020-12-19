using System;
using Task3.AbstractModels;
using Task3.ModelsOfGeometricShapes.FilmShapes;

namespace Task3.SheetsOfMaterials.ListOfFilm
{
    class FilmRegularPentagonCreating : ISheetOfMaterial
    {
        public Shape CutShape(ShapeColor shapeColor, double[] lengthOfSodes)
        {
            if (shapeColor != ShapeColor.Transparent)
            {
                throw new ArgumentException();
            }
            else
            {
                return new FilmRegularPentagon(lengthOfSodes);
            }
        }
    }
}
