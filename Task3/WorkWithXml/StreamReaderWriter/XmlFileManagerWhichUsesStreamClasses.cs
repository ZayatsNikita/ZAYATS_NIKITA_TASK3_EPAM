using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Task3.AbstractModels;
namespace Task3.WorkWithXml.StreamReaderWriter
{
    //"<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<shapes>\r\n  <PaperRectangle color=\"Transparent\" integrity=\"True\">\r\n    <count_of_sides>2</count_of_sides>\r\n    <double>2</double>\r\n    <double>2</double>\r\n  </PaperRectangle>\r\n  <FilmRectangle color=\"Transparent\" integrity=\"True\">\r\n    <count_of_sides>2</count_of_sides>\r\n    <double>2</double>\r\n    <double>5</double>\r\n  </FilmRectangle>\r\n  <PlasticRectangle color=\"Transparent\" integrity=\"True\">\r\n    <count_of_sides>2</count_of_sides>\r\n    <double>5</double>\r\n    <double>5</double>\r\n  </PlasticRectangle>\r\n  <PaperCircle color=\"Transparent\" integrity=\"True\">\r\n    <count_of_sides>1</count_of_sides>\r\n    <double>4.5</double>\r\n  </PaperCircle>\r\n  <FilmCircle color=\"Transparent\" integrity=\"True\">\r\n    <count_of_sides>1</count_of_sides>\r\n    <double>4.5</double>\r\n  </FilmCircle>\r\n  <PlasticCircle color=\"Transparent\" integrity=\"True\">\r\n    <count_of_sides>1</count_of_sides>\r\n    <double>4.5</double>\r\n  </PlasticCircle>\r\n  <PaperTriangle color=\"Transparent\" integrity=\"True\">\r\n    <count_of_sides>3</count_of_sides>\r\n    <double>1.5</double>\r\n    <double>1.5</double>\r\n    <double>2</double>\r\n  </PaperTriangle>\r\n  <FilmTriangle color=\"Transparent\" integrity=\"True\">\r\n    <count_of_sides>3</count_of_sides>\r\n    <double>1.5</double>\r\n    <double>1.5</double>\r\n    <double>1.5</double>\r\n  </FilmTriangle>\r\n  <PlasticTriangle color=\"Transparent\" integrity=\"True\">\r\n    <count_of_sides>3</count_of_sides>\r\n    <double>1.5</double>\r\n    <double>1.5</double>\r\n    <double>2</double>\r\n  </PlasticTriangle>\r\n</shapes>"
    public static class XmlFileManagerWhichUsesStreamClasses
    {
        private static string startOfXmlDoc = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n";
        static public void SaveDataUsingStreamWriter(Shape[] shapes, string path)
        {
            double[] array;
            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                StreamWriter writer = new StreamWriter(fileStream);
                writer.Write(startOfXmlDoc);
                writer.Write($"<{nameof(shapes)}>\r\n");
                foreach(Shape shape in shapes)
                {
                    writer.Write($"  <{shape.GetType().Name} color=\"{shape.Color}\" integrity=\"{shape.IsIntact}\">\r\n");
                    writer.Write($"    <count_of_sides>{shape.LengthsOfSides.Length}</count_of_sides>\r\n");
                    array = shape.LengthsOfSides;
                    foreach (double db in array)
                    {
                        writer.Write($"    <double>{db}</double>\r\n");
                    }
                    writer.Write($"  </{shape.GetType().Name}>\r\n");
                }
                writer.Write($"</{nameof(shapes)}>\r\n");
                writer.Flush();
                writer.Close();
            }
        }
        static public /*List<Shape>*/ void Parse(string path)
        {
            if (File.Exists(path))
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    StreamReader streamReader = new StreamReader(fileStream);

                    string forProcessing = streamReader.ReadToEnd();

                    streamReader.Close();
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
