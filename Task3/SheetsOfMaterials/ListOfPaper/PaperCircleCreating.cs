using Task3.AbstractModels;
using Task3.ModelsOfGeometricShapes.PaperShapes;

namespace Task3.SheetsOfMaterials.ListOfPaper
{
    class PaperCircleCreating : ISheetOfMaterial
    {
        public Shape CutShape(ShapeColor shapeColor, double[] lengthOfSodes)
        {
            PaperCircle shaple = new PaperCircle(lengthOfSodes);
            shaple.Paint(shapeColor);
            return shaple;
        }
    }
}
