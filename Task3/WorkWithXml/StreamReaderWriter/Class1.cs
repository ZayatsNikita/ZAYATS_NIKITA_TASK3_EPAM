using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Task3.WorkWithXml.StreamReaderWriter
{
    public static class XmlFileManagerWhichUsesStreamClasses
    {
        static public void SaveDataUsingXmlWriter(Shape[] shapes, string path)
        {
            using (Stream fileStream = new FileStream(path, FileMode.Create))
            {
                double[] sides;
                XmlWriter xmlWriter = XmlWriter.Create(fileStream, xmlWriterSettings);
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("shapes");
                foreach (Shape shape in shapes)
                {
                    xmlWriter.WriteStartElement(shape.GetType().Name.ToString());
                    xmlWriter.WriteAttributeString("color", shape.Color.ToString());
                    xmlWriter.WriteAttributeString("integrity", shape.IsIntact.ToString());
                    sides = shape.LengthsOfSides;
                    xmlWriter.WriteElementString("count_of_sides", sides.Length.ToString());
                    foreach (double length in sides)
                    {
                        xmlWriter.WriteElementString("double", length.ToString().Replace(',', '.'));
                    }
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }
        }
        static public /*List<Shape>*/void TryParse(string path, Shape[] shapes)
        {
            if (File.Exists(path))
            {
                using (Stream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    XmlReader reader = XmlReader.Create(fileStream);
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (existingshapes.DoesItContain(reader.Name))
                            {
                                if (reader.HasAttributes)
                                {
                                    ShapeColor color = (ShapeColor)Enum.Parse(typeof(ShapeColor), reader.GetAttribute("color"));
                                    bool IsIntract = Boolean.Parse(reader.GetAttribute("integrity"));
                                    int countOfSides = 0;
                                    reader.Read();
                                    reader.Read();
                                    if (reader.Name == "count_of_sides")
                                    {
                                        countOfSides = reader.ReadElementContentAsInt();
                                    }
                                    else
                                    {
                                        throw new ArgumentException();
                                    }
                                    double[] array = new double[countOfSides];
                                    Console.WriteLine(color + "    " + IsIntract);
                                    for (int i = 0; i < array.Length; i++)
                                    {
                                        reader.Skip();
                                        reader.Read();
                                        Console.WriteLine(reader.ReadString());
                                    }
                                }
                                else
                                {
                                    throw new ArgumentException();
                                }
                            }
                        }

                    }
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
