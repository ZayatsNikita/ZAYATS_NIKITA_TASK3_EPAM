using System;
using Task3.ModelsOfGeometricShapes;
using Task3.AbstractModels;
using Task3.ModelsOfGeometricShapes.PlasticShapes;
using Task3.ModelsOfGeometricShapes.FilmShapes;
using Task3.ModelsOfGeometricShapes.PaperShapes;
using Task3.XMLFileManager;


namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = new Shape[9];

            shapes[0] = new PaperRectangle(2);
            shapes[1] = new FilmRectangle(2,5);
            shapes[2] = new PlasticRectangle(5);

            shapes[3] = new PaperCircle(4.5);
            shapes[4] = new FilmCircle(4.5);
            shapes[5] = new PlasticCircle(4.5);

            shapes[6] = new PaperTriangle(1.5, 1.5, 2);
            shapes[7] = new FilmTriangle(1.5);
            shapes[8] = new PlasticTriangle(1.5, 1.5, 2);


            XmlFileManager.SaveDataUsingXmlWriter(shapes, @"D:\Learn\EPAM\task3\Task3\testFile.xml");
            XmlFileManager.TryParse(@"D:\Learn\EPAM\task3\Task3\testFile.xml", null);
        }
    }
}
