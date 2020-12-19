using System;
using System.Collections.Generic;
using System.Text;
using Task3.AbstractModels;
using Task3.ModelsOfGeometricShapes.PlasticShapes;
namespace Task3.SheetsOfMaterials.ListOfPlastic
{
    class PlasticCircleCreating : ISheetOfMaterial
    {
        public Shape CutShape(ShapeColor shapeColor, double[] lengthOfSodes)
        {
            PlasticCircle shaple = new PlasticCircle(lengthOfSodes);
            shaple.Paint(shapeColor);
            return shaple;
        }
    }
}
