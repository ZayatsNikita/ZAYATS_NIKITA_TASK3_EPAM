using Task3.AbstractModels;
using Task3.ModelsOfGeometricShapes.PaperShapes;

namespace Task3.SheetsOfMaterials.ListOfPaper
{
    class PaperRegularPentagonCreating : ISheetOfMaterial
    {
        public Shape CutShape(ShapeColor shapeColor, double[] lengthOfSodes)
        {
            PaperRegularPentagon shaple = new PaperRegularPentagon(lengthOfSodes);
            shaple.Paint(shapeColor);
            return shaple;
        }
    }
}
