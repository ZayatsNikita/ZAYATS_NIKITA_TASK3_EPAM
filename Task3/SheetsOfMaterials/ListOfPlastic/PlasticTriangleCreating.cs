using Task3.AbstractModels;
using Task3.ModelsOfGeometricShapes.PlasticShapes;

namespace Task3.SheetsOfMaterials.ListOfPlastic
{
    class PlasticTriangleCreating : ISheetOfMaterial
    {
        public Shape CutShape(ShapeColor shapeColor, double[] lengthOfSodes)
        {
            PlasticTriangle shaple = new PlasticTriangle(lengthOfSodes);
            shaple.Paint(shapeColor);
            return shaple;
        }
    }
}
