using Task3.AbstractModels;
using Task3.ModelsOfGeometricShapes.PlasticShapes;

namespace Task3.SheetsOfMaterials.ListOfPlastic
{
    class PlasticRectangleCreating : ISheetOfMaterial
    {
        public Shape CutShape(ShapeColor shapeColor, double[] lengthOfSodes)
        {
            PlasticRectangle shaple = new PlasticRectangle(lengthOfSodes);
            shaple.Paint(shapeColor);
            return shaple;
        }
    }
}
