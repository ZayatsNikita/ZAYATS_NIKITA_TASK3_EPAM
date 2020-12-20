using System;
using System.Xml;
using Task3.AbstractModels;
using System.Collections.Generic;
using System.IO;
using Task3.SheetsOfMaterials;

    
namespace Task3.XMLFileManager.XmlReaderWriter
{
    public static class XmlFileManager
    {
        static XmlWriterSettings xmlWriterSettings;
        static string[] existingshapes;
        static XmlFileManager()
        {
            xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            existingshapes = Enum.GetNames(typeof(ExistShapes));
        }

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
        static public List<Shape> Parse(string path)
        {
            if (File.Exists(path))
            {
                using (Stream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
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
                                        listOfShape.Add(UniversalSheet.CutShape(shapeName, array, color, isIntract));
                                    }
                                    else
                                    {
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
