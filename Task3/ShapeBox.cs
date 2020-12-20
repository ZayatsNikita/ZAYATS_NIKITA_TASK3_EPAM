using System;
using System.Collections.Generic;
using System.Text;
using Task3.AbstractModels.TypesOfShapes;
using Task3.AbstractModels;

using Task3.AbstractModels.ShapeMaterials;
using Task3.ModelsOfGeometricShapes.PlasticShapes;
using Task3.ModelsOfGeometricShapes.PaperShapes;
using Task3.WorkWithXml.StreamReaderWriter;
using Task3.XMLFileManager.XmlReaderWriter;

namespace Task3
{
    public class ShapeBox
    {
        private bool DoesShapeExist(in Shape shape)
        {
            for (int i = 0; i < Count; i++)
            {
                if (shape.Equals(shapes[i]))
                {
                    return true;
                }
            }
            return false;
        }
        private const int MaximumCapacity = 20;
        private Shape[] shapes;
        public int Count { get; protected set; }
        public double ComonArea 
        {
            get
            {
                double resultArea = 0;
                for (int i = 0; i < Count; i++)
                {
                    resultArea += shapes[i].Area;
                }

                return resultArea;
            }
        }
        public double ComonPerimeter
        {
            get
            {
                double resultPerimetr = 0;
                for (int i = 0; i < Count; i++)
                {
                    resultPerimetr += shapes[i].Perimeter;
                }
                return resultPerimetr;
            }
        }
        public ShapeBox()
        {
            shapes = new Shape[MaximumCapacity];
        }
        public void Add(Shape shape)
        {
            if(shape==null)
            {
                throw new ArgumentNullException();
            }
            if (Count + 1 > MaximumCapacity)
            {
                throw new OutOfMemoryException();
            }
            if (DoesShapeExist(shape))
            {
                throw new ArgumentException();
            }
            shapes[Count] = shape;
            Count++;
        }
        public int NumberOf(in Shape shape)
        {
            for (int i = 0; i < Count; i++)
            {
                if (shape.Equals(shapes[i]))
                {
                    return i+1;
                }
            }
            return -1;
        }
        public List<Shape> ExtractAllCircles()
        {
            List<Shape> result = new List<Shape>();
            for (int i = 0; i < Count; i++)
            {
                if(shapes[i] is Circle)
                {
                    result.Add(shapes[i]);
                }
            }
            if(result.Count!=0)
            {
                return result;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public List<Shape> ExtractAllFilmShapes()
        {
            List<Shape> result = new List<Shape>();
            for (int i = 0; i < Count; i++)
            {
                if (shapes[i] is IFilm)
                {
                    result.Add(shapes[i]);
                }
            }
            if (result.Count != 0)
            {
                return result;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public List<Shape> ExtractAllNonPaintedPlasticShapes()
        {
            List<Shape> result = new List<Shape>();
            for (int i = 0; i < Count; i++)
            {
                if (shapes[i] is IPlastic && shapes[i].Color == ShapeColor.Transparent)
                {
                    result.Add(shapes[i]);
                }
            }
            if (result.Count != 0)
            {
                return result;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public Shape this[int numberOfShape]
        {
            get
            {
                if (numberOfShape > Count || numberOfShape < 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return shapes[numberOfShape - 1];
            }
            set
            {
                if (numberOfShape > Count || numberOfShape < 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if(value==null)
                {
                    throw new ArgumentNullException();
                }
                shapes[numberOfShape - 1] = value;
            }
        }
        public Shape ExtractShapeByNumber(int numberOfShape)
        {
            if (numberOfShape > Count || numberOfShape < 1)
                throw new ArgumentOutOfRangeException();
            
            Shape result = shapes[Count - 1];

            Count--;

            for (int i = numberOfShape - 1; i < Count; i++)
            {
                shapes[numberOfShape] = shapes[numberOfShape+1];
            }
            
            return result;
        }
        public void SaveShapesToXmlUsingXmlWriter(string interfaceType,string path)
        {
            
            if(interfaceType.ToLower() == "all" && Count!=0)
            {
                Shape[] array = new Shape[Count];
                for (int i = 0; i < Count; i++)
                {
                    array[i] = shapes[i];
                }
                XmlFileManager.SaveDataUsingXmlWriter(array,path);
                return;
            }
            else
            {
                string[] exMat = Enum.GetNames(typeof(ExsisMaterialsInterfaces));
                int index = exMat.intdefOf(interfaceType);
                Type type;
                try
                {
                    type = Type.GetType($"Task3.AbstractModels.ShapeMaterials.{exMat[index]}");
                }
                catch(IndexOutOfRangeException)
                {
                    throw new ArgumentException();
                }

                List<Shape> result = new List<Shape>();
                for (int i = 0; i < Count; i++)
                {
                    if (shapes[i].GetType().GetInterface($"Task3.AbstractModels.ShapeMaterials.{exMat[index]}") == type)
                    {
                        result.Add(shapes[i]);
                    }
                }
                if (result.Count != 0)
                {
                    XmlFileManager.SaveDataUsingXmlWriter(result.ToArray(), path);
                    return;
                }
            }
            throw new InvalidOperationException();
        }
        public void SaveShapesToXmlUsingStreamWriter(string interfaceType, string path)
        {
                if (interfaceType.ToLower() == "all" && Count != 0)
                {
                    Shape[] array = new Shape[Count];
                    for (int i = 0; i < Count; i++)
                    {
                        array[i] = shapes[i];
                    }
                    XmlFileManager.SaveDataUsingXmlWriter(array, path);
                    return;
                }
                else
                {
                    string[] exMat = Enum.GetNames(typeof(ExsisMaterialsInterfaces));
                    int index = exMat.intdefOf(interfaceType);
                    Type type;
                    try
                    {
                        type = Type.GetType($"Task3.AbstractModels.ShapeMaterials.{exMat[index]}");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new ArgumentException();
                    }

                    List<Shape> result = new List<Shape>();
                    for (int i = 0; i < Count; i++)
                    {
                        if (shapes[i].GetType().GetInterface($"Task3.AbstractModels.ShapeMaterials.{exMat[index]}") == type)
                        {
                            result.Add(shapes[i]);
                        }
                    }
                    if (result.Count != 0)
                    {
                        XmlFileManager.SaveDataUsingXmlWriter(result.ToArray(), path);
                        return;
                    }
                }
                throw new InvalidOperationException();
        }
        public void LoadShapesFromXmlUsingStreamReader(string filePath)
        {
            List<Shape> shapesFromFile = StreamFileManager.Parse(filePath);
            AddCollection(shapesFromFile);
        }
        public void LoadShapesFromXmlUsingXmlReader(string filePath)
        {
            List<Shape> shapesFromFile = XmlFileManager.Parse(filePath);
            AddCollection(shapesFromFile);
        }
        public void AddCollection(List<Shape> list)
        {
            if(list==null)
            {
                throw new ArgumentNullException();
            }
            if (list.Count > 20)
            {
                throw new ArgumentException();
            }
            else
            {
                foreach (Shape shape in list)
                {
                    Add(shape);
                }
            }
        }

    }
}
