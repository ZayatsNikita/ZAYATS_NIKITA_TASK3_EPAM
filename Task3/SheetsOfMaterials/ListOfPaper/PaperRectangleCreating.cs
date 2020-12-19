using Task3.AbstractModels;
using Task3.ModelsOfGeometricShapes.PaperShapes;

namespace Task3.SheetsOfMaterials.ListOfPaper
{
    class PaperRectangleCreating : ISheetOfMaterial
    {
        public Shape CutShape(ShapeColor shapeColor, double[] lengthOfSodes)
        {
            PaperRectangle shaple = new PaperRectangle(lengthOfSodes);
            shaple.Paint(shapeColor);
            return shaple;
        }
    }
}
