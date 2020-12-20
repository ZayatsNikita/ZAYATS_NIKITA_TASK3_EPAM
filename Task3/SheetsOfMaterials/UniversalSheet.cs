using System;
using Task3.AbstractModels;
using Task3.SheetsOfMaterials.ListOfFilm;
using Task3.SheetsOfMaterials.ListOfPaper;
using Task3.SheetsOfMaterials.ListOfPlastic;


namespace Task3.SheetsOfMaterials
{
    /// <summary>
    /// A class that is a universal sheet from which you can cut any shape.
    /// </summary>
    public static class UniversalSheet
    {
        /// <summary>
        ///A static constructor that initializes the "sheetsofmaterial" array with factories for special shapes,
        ///<para></para>and also initializes the "existshapes" array with names of shapes whose factories can be used.
        /// </summary>
        static UniversalSheet()
        {
            existShapes = Enum.GetNames(typeof(ExistShapes));
            sheetsOfMaterial = new IСuttingShape[] {new  FilmCircleCreating(), new FilmRectangleCreating(), new FilmRegularPentagonCreating(), new FilmTriangleCreating(),
                new PaperCircleCreating(), new PaperRectangleCreating(), new PaperRegularPentagonCreating(), new PaperTriangleCreating(),
                new PlasticCircleCreating(), new PlasticRectangleCreating(), new PlasticRegularPentagonCreating(), new PlasticTriangleCreating()
            };
        }
        private static string[] existShapes;
        private static IСuttingShape[] sheetsOfMaterial;
        /// <summary>
        /// A method that cuts a shape according to the specified parameters.
        /// </summary>
        /// <param name="shapeName">The name of the shape, which is the name of the class to be retrieved, not including the namespace.<para></para>for example: "PlasticTriangle".</param>
        /// <param name="lenghtOfSides">Length of the sides of the figure.</param>
        /// <param name="color">The color of the shape.</param>
        /// <param name="integrity">If this parameter is true, then the whole shape is not created.</param>
        /// <returns>new Shape new Shape that has type equal to shapeName param.</returns>
        /// <example>CutShape("PlasticRectangle", new double[]{1,1},"Red" , false) => new red PlasticRectangle with sides of 1,1.</example>
        /// <exception cref="ArgumentException">Throw if the shape is not in the list of possible shapes to create.</exception>
        /// <exception cref="InvalidOperationException">Throw if a painting error was received.</exception>
        /// <exception cref="ArgumentException">Throw if the values of the side lengths do not meet the requirements of the shape being created.</exception>
        static public Shape CutShape(string shapeName, double[] lenghtOfSides,ShapeColor color ,  bool integrity)
        {
            int indexOfShapeFactory = existShapes.intdefOf(shapeName);
            if(indexOfShapeFactory==-1)
            {
                throw new ArgumentException();
            }
            else
            {
                Shape shape = sheetsOfMaterial[indexOfShapeFactory].CutShape(lenghtOfSides);
                if(!integrity)
                {
                    shape.CutNewShape();
                }
                try
                {
                    if (color != ShapeColor.Transparent)
                    {
                        shape.Paint(color);
                    }
                }
                catch(Exception)
                {
                    throw new InvalidOperationException();
                }
                return shape;
            }
        }
    }
}
