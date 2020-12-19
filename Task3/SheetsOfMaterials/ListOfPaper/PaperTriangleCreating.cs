using Task3.AbstractModels;
using Task3.ModelsOfGeometricShapes.PaperShapes;

namespace Task3.SheetsOfMaterials.ListOfPaper
{
    class PaperTriangleCreating : ISheetOfMaterial
    {
        public Shape CutShape(ShapeColor shapeColor, double[] lengthOfSodes)
        {
            PaperTriangle shaple = new PaperTriangle(lengthOfSodes);
            shaple.Paint(shapeColor);
            return shaple;
        }
    }
}
