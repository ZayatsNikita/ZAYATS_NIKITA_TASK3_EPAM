using System;
using System.Collections.Generic;
using System.Text;
using Task3;
using Task3.AbstractModels;
using Task3.ModelsOfGeometricShapes.FilmShapes;
namespace Task3.SheetsOfMaterials.ListOfFilm
{
    class FilmCircleCreating : ISheetOfMaterial
    {
        Shape ISheetOfMaterial.CutShape(ShapeColor shapeColor, double[] lengthOfSodes)
        {
            if (shapeColor != ShapeColor.Transparent)
            {
                throw new ArgumentException();
            }
            else
            {
                return new FilmCircle(lengthOfSodes);
            }
        }
    }
}
