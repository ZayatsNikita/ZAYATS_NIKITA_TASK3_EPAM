using System;
using System.Xml;
using Task3.AbstractModels;
using System.Collections.Generic;
using System.IO;
using Task3.SheetsOfMaterials;

    
namespace Task3.XMLFileManager.XmlReaderWriter
{
    /// <summary>
    /// Class that allows you to read information about shapes in xml format to a file ,<para></para>
    /// as well as extract this information using the XmlWriter and XmlReader classes.
    /// </summary>
    public static class XmlFileManager
    {

        static XmlWriterSettings xmlWriterSettings;
        static string[] existingshapes;
        /// <summary>
        /// A static constructor that sets the settings for writing data to a file, and also gets a list of all available shapes.
        /// </summary>
        static XmlFileManager()
        {
            xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            existingshapes = Enum.GetNames(typeof(ExistShapes));
        }
        /// <summary>
        /// A method that writes information to a file.
        /// </summary>
        /// <param name="shapes">Array of shapes to be written.</param>
        /// <param name="path">Name of the file to which the information will be written.</param>
        /// <remarks>All information that was previously in the file will be deleted.</remarks>
        /// <exception cref="NullReferenceException">Throw if array was passed is equlas to null</exception>
        static public void SaveDataUsingXmlWriter(Shape[] shapes, string path)
        {
                if(shapes==null)
                {
                    throw new NullReferenceException();
                }
                using (Stream fileStream = new FileStream(path, FileMode.Create))
                {
                    double[] sides;
                    XmlWriter xmlWriter = XmlWriter.Create(fileStream, xmlWriterSettings);
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("shapes");
                    foreach (Shape shape in shapes)
                    {                        
                        xmlWriter.WriteStartElement(shape.GetType().Name.ToString());
                        xmlWriter.WriteAttributeString("color",shape.Color.ToString());
                        xmlWriter.WriteAttributeString("integrity",shape.IsIntact.ToString());
                        sides = shape.LengthsOfSides;
                        xmlWriter.WriteElementString("count_of_sides", sides.Length.ToString());
                        foreach(double length in sides)
                        {
                            xmlWriter.WriteElementString("double",length.ToString());
                        }
                        xmlWriter.WriteEndElement();                        
                    }
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Close();
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
            if (File.Exists(path))
            {
                using (Stream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    bool cathEx = false;
                    XmlReader reader = XmlReader.Create(fileStream);
                    List<Shape> listOfShape= new List<Shape>();
                    try
                    {
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element)
                            {
                                if (existingshapes.DoesItContain(reader.Name))
                                {
                                    string shapeName = reader.Name;
                                    if (reader.HasAttributes)
                                    {
                                        ShapeColor color = (ShapeColor)Enum.Parse(typeof(ShapeColor), reader.GetAttribute("color"));
                                        bool isIntract = Boolean.Parse(reader.GetAttribute("integrity"));
                                        int countOfSides = 0;
                                        reader.Read();
                                        reader.Read();
                                        if (reader.Name == "count_of_sides")
                                        {
                                            countOfSides = reader.ReadElementContentAsInt();
                                        }
                                        else
                                        {
                                            throw new FormatException();
                                        }
                                        double[] array = new double[countOfSides];
                                        Console.WriteLine(color + "    " + isIntract);
                                        for (int i = 0; i < array.Length; i++)
                                        {
                                            reader.Skip();
                                            array[i] = Double.Parse(reader.ReadElementContentAsString());

                                        }
                                        try
                                        {
                                            listOfShape.Add(UniversalSheet.CutShape(shapeName, array, color, isIntract));
                                        }
                                        catch (FormatException ex)
                                        {
                                            cathEx = true ;
                                            throw ex;
                                        }
                                        catch (Exception ex)
                                        {
                                            cathEx = true;
                                            throw ex;
                                        }
                                        finally
                                        {
                                            if (cathEx)
                                            {
                                                reader.Close();
                                                fileStream.Close();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        reader.Close();
                                        fileStream.Close();
                                        throw new FormatException();
                                    }
                                }
                            }

                        }
                    }
                    catch(XmlException)
                    {
                        
                        throw new FormatException();
                    }
                    finally
                    {
                        reader.Close();
                        fileStream.Close();
                    }
                    if(listOfShape.Count==0)
                    {
                        throw new FormatException();
                    }
                    return listOfShape;
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
