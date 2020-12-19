using Task3.AbstractModels;
using Task3.ModelsOfGeometricShapes.PlasticShapes;
namespace Task3.SheetsOfMaterials.ListOfPlastic
{
    class PlasticRegularPentagonCreating : ISheetOfMaterial
    {
        public Shape CutShape(ShapeColor shapeColor, double[] lengthOfSodes)
        {
            PlasticRegularPentagon shaple = new PlasticRegularPentagon(lengthOfSodes);
            shaple.Paint(shapeColor);
            return shaple;
        }
    }
}
