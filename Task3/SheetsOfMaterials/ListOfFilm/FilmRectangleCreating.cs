using System;
using System.Collections.Generic;
using System.Text;
using Task3.AbstractModels;
using Task3.ModelsOfGeometricShapes.FilmShapes;

namespace Task3.SheetsOfMaterials.ListOfFilm
{
    public class FilmRectangleCreating : ISheetOfMaterial
    {
        public Shape CutShape(ShapeColor shapeColor, double[] lengthOfSodes)
        {
            if(shapeColor!= ShapeColor.Transparent)
            {
                throw new ArgumentException();
            }
            else
            {
                return new FilmRectangle(lengthOfSodes);
            }
        }
    }
}
