using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Task3.AbstractModels;
namespace Task3.WorkWithXml.StreamReaderWriter
{
    public static class StreamFileManager
    {
        private static string startOfXmlDoc = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n";
        static public void SaveDataUsingStreamWriter(Shape[] shapes, string path)
        {
            if (shapes == null)
            {
                throw new NullReferenceException();
            }
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
                        writer.Write($"    <double>{db.ToString()}</double>\r\n");
                    }
                    writer.Write($"  </{shape.GetType().Name}>\r\n");
                }
                writer.Write($"</{nameof(shapes)}>\r\n");
                writer.Flush();
                writer.Close();
            }
        }
        static public List<Shape> Parse(string path)
        {
            if (File.Exists(path))
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    StreamReader streamReader = new StreamReader(fileStream);
                    List<Shape> shapes;
                    string forProcessing = streamReader.ReadToEnd();
                    try
                    {
                        shapes = StringProcessing.GetDescriptionOfTheShape(forProcessing);
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        streamReader.Close();
                    }
                    return shapes;
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
