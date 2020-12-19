using System;
using Task3.AbstractModels;
using Task3.SheetsOfMaterials.ListOfPlastic;
using Task3.SheetsOfMaterials.ListOfPaper;
using Task3.SheetsOfMaterials.ListOfFilm;


namespace Task3.SheetsOfMaterials
{
    public static class UniversalSheet
    {
        static UniversalSheet()
        {
            existShapes = Enum.GetNames(typeof(ExistShapes));
            sheetsOfMaterial = new ISheetOfMaterial[] {new  FilmCircleCreating(), new FilmRectangleCreating(), new FilmRegularPentagonCreating(), new FilmTriangleCreating(),
                new PaperCircleCreating(), new PaperRectangleCreating(), new PaperRegularPentagonCreating(), new PaperTriangleCreating(),
                new PlasticCircleCreating(), new PlasticRectangleCreating(), new PlasticRegularPentagonCreating(), new PlasticTriangleCreating()
            };
        }
        private static string[] existShapes;
        private static ISheetOfMaterial[] sheetsOfMaterial;
        static public Shape CutShape(string shapeName, double[] lenghtOfSides,ShapeColor color ,  bool integrity)
        {
            int indexOfShapeFactory = existShapes.intdefOf(shapeName);
            if(indexOfShapeFactory==-1)
            {
                throw new ArgumentException();
            }
            else
            {
                Shape shape = sheetsOfMaterial[indexOfShapeFactory].CutShape(color,lenghtOfSides);
                if(!integrity)
                {
                    shape.CutNewShape();
                }
                return shape;
            }
        }
    }
}
