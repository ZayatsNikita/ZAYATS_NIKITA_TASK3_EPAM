using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Task3.AbstractModels;
namespace Task3.WorkWithXml.StreamReaderWriter
{
    /// <summary>
    /// Class that allows you to read information about shapes in xml format to a file ,<para></para>
    /// as well as extract this information using the StreamWriter and StreamReader classes.
    /// </summary>
    public static class StreamFileManager
    {
        private static string startOfXmlDoc = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n";
        /// <summary>
        /// A method that writes information to a file.
        /// </summary>
        /// <param name="shapes">Array of shapes to be written.</param>
        /// <param name="path">Name of the file to which the information will be written.</param>
        /// <remarks>All information that was previously in the file will be deleted.</remarks>
        /// <exception cref="NullReferenceException">Throw if array was passed is equlas to null</exception>
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
        /// <summary>
        /// A method that translates information from a file specified in the required format into a list of shapes.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <returns>List of figures.</returns>
        /// <exception cref="FileNotFoundException">Throw if the file was not found.</exception>
        /// <exception cref="FormatException">Throw if the file contains information in the wrong format.</exception>
        static public List<Shape> Parse(string path)
        {
            bool catchEx = false;
            if (File.Exists(path))
            {
                List<Shape> shapes;
                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    StreamReader streamReader = new StreamReader(fileStream);
                    
                    string forProcessing = streamReader.ReadToEnd();
                    try
                    {
                        shapes = StringProcessing.GetDescriptionOfTheShape(forProcessing);
                    }
                    catch(FormatException ex)
                    {
                        catchEx = true;
                        throw ex;
                    }
                    catch(Exception ex)
                    {
                        catchEx = true;
                        throw ex;
                    }
                    finally
                    {
                        if (catchEx)
                        {
                            fileStream.Close();
                            streamReader.Close();
                        }
                        
                    }
                    streamReader.Close();
                }
                return shapes;
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
