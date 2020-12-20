using System;
using System.Collections.Generic;
using Task3.AbstractModels;
using Task3.AbstractModels.Materials;
using Task3.AbstractModels.TypesOfShapes;
using Task3.WorkWithXml.StreamReaderWriter;
using Task3.XMLFileManager.XmlReaderWriter;

namespace Task3
{
    /// <summary>
    /// A class that represents a collection of shapes.
    /// </summary>
    public class ShapeBox
    {
        /// <summary>
        /// A method that checks for the presence of the specified shape inside the collection.
        /// </summary>
        /// <param name="shape">Shape to search for.</param>
        /// <returns>True if such a figure exists, false otherwise.</returns>
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
        /// <summary>
        /// A property that reflects the number of shapes in a box.
        /// </summary>
        public int Count { get; protected set; }
        /// <summary>
        /// Property describing the total area of all stored shapes.
        /// </summary>
        public double ComonArea 
        {
            get
            {
                double resultArea = 0;
                for (int i = 0; i < Count; i++)
                {
                    try
                    {
                        resultArea += shapes[i].Area;
                    }
                    catch(InvalidOperationException)
                    {
                        resultArea += 0;
                    }
                }

                return resultArea;
            }
        }
        /// <summary>
        /// Property describing the total perimetr of all stored shapes.
        /// </summary>
        public double ComonPerimeter
        {
            get
            {
                double resultPerimetr = 0;
                for (int i = 0; i < Count; i++)
                {
                    try
                    {
                        resultPerimetr += shapes[i].Perimeter;
                    }
                    catch(InvalidOperationException)
                    {
                        resultPerimetr += 0;
                    }
                }
                return resultPerimetr;
            }
        }
        /// <summary>
        /// a constructor that allocates memory for storing 20 shapes.
        /// </summary>
        public ShapeBox()
        {
            shapes = new Shape[MaximumCapacity];
        }
        /// <summary>
        /// The method which performs the addition of the individual figures in the box.
        /// </summary>
        /// <param name="shape">The shape to add</param>
        /// <exception cref="ArgumentException">Throw if such a shape already exists.</exception>
        /// <exception cref="ArgumentNullException">Thrown when trying to add a null element.</exception>
        /// <exception cref="OutOfMemoryException">discarded if there are already 20 pieces in the box.</exception>
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
        /// <summary>
        /// Method that returns the number of the specified shape.
        /// </summary>
        /// <param name="shape">Shape to search for.</param>
        /// <returns>Shape number or minus one if the figure was not found.</returns>
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
        /// <summary>
        /// A method that returns a list of circles stored in a box
        /// </summary>
        /// <returns>List of circles stored in a box.</returns>
        /// <exception cref="InvalidOperationException">Throw if theare not any circles in ShapeBox.</exception>
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
        /// <summary>
        /// A method that returns a list of film shapes stored in a box.
        /// </summary>
        /// <returns>List of film shapes stored in a box.</returns>
        /// <exception cref="InvalidOperationException">Throw if theare not any film shapes in ShapeBox.</exception>
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

        /// <summary>
        /// A method that returns a list of all non painted plastic shapes stored in a box.
        /// </summary>
        /// <returns>List of non painted plastic shapes stored in a box.</returns>
        /// <exception cref="InvalidOperationException">Throw if theare not any non painted plastic shapes in ShapeBox.</exception>
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
        /// <summary>
        /// indexer that allows you to extract a shape by number without deleting it, and also allows you to set the shape by a given number.
        /// </summary>
        /// <param name="numberOfShape">Shape number in the box.</param>
        /// <returns>Shape with specifical number.</returns>
        /// <exception cref="ArgumentNullException">Throw if same shape threre is in box.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throw if the number passed is greater than the current number or less than one. </exception>
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
                if(DoesShapeExist(value))
                {
                    throw new ArgumentException();
                }
                shapes[numberOfShape - 1] = value;
            }
        }


        /// <summary>
        /// Retrieves a shape by number while removing it from the box.
        /// </summary>
        /// <param name="numberOfShape"></param>
        /// <returns>Shape with the specified number.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw if the number passed is greater than the current number or less than one.</exception>
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
        /// <summary>
        /// A method that saves shapes of the specified type to a file using XmlWriter.
        /// </summary>
        /// <param name="interfaceType">Name of the material that the shape consists of( interface name, without namespace) or the word "all" if you need to save all the shapes.</param>
        /// <param name="path">Name of the file to which the information will be written.</param>
        /// <exception cref="ArgumentException">Throw if wrong interfaceType was passed.</exception>
        /// <exception cref="InvalidOperationException">Throw if there are not any shapes of necessary type of count of shapes there are in box is null.</exception>
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
                    type = Type.GetType($"Task3.AbstractModels.Materials.{exMat[index]}");
                }
                catch(IndexOutOfRangeException)
                {
                    throw new ArgumentException();
                }

                List<Shape> result = new List<Shape>();
                for (int i = 0; i < Count; i++)
                {
                    if (shapes[i].GetType().GetInterface($"Task3.AbstractModels.Materials.{exMat[index]}") == type)
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
        /// <summary>
        /// A method that saves shapes of the specified type to a file using StreamWriterr.
        /// </summary>
        /// <param name="interfaceType">Name of the material that the shape consists of( interface name, without namespace) or the word "all" if you need to save all the shapes.</param>
        /// <param name="path">Name of the file to which the information will be written.</param>
        /// <exception cref="ArgumentException">Throw if wrong interfaceType was passed.</exception>
        /// <exception cref="InvalidOperationException">Throw if there are not any shapes of necessary type of count of shapes there are in box is null.</exception>
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
                        type = Type.GetType($"Task3.AbstractModels.Materials.{exMat[index]}");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new ArgumentException();
                    }

                    List<Shape> result = new List<Shape>();
                    for (int i = 0; i < Count; i++)
                    {
                        if (shapes[i].GetType().GetInterface($"Task3.AbstractModels.Materials.{exMat[index]}") == type)
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
        /// <summary>
        /// A method that extracts data about shapes from the specified file uses StreamReader and puts these shapes in a box.
        /// </summary>
        /// <param name="filePath">Path to file with data.</param>
        /// <exception cref="System.IO.FileNotFoundException">Throw file does not exsist.</exception>
        /// <exception cref="FormatException">Throw if there incorect information in the file.</exception>
        /// <exception cref="ArgumentException">Throw if there are more then 20 shapes in file.</exception>
        public void LoadShapesFromXmlUsingStreamReader(string filePath)
        {
            List<Shape> shapesFromFile = StreamFileManager.Parse(filePath);
            AddCollection(shapesFromFile);
        }
        /// <summary>
        /// A method that extracts data about shapes from the specified file uses XmlReader and puts these shapes in a box.
        /// </summary>
        /// <param name="filePath">Path to file with data.</param>
        /// <exception cref="System.IO.FileNotFoundException">Throw file does not exsist.</exception>
        /// <exception cref="FormatException">Throw if there incorect information in the file.</exception>
        /// <exception cref="ArgumentException">Throw if there are more then 20 shapes in file or there is same shape in box.</exception>
        public void LoadShapesFromXmlUsingXmlReader(string filePath)
        {
            List<Shape> shapesFromFile = XmlFileManager.Parse(filePath);
            AddCollection(shapesFromFile);
        }
        /// <summary>
        /// Methods that list of shapes to box.
        /// </summary>
        /// <param name="list">List with shapes.</param>
        /// <exception cref="ArgumentException">Throw if there are more then 20 shapes in file or there is same shape in box.</exception>
        /// <exception cref="ArgumentNullException">Throw if list is referens to null, or one of elements in list referens to null.</exception>
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

        public override string ToString()
        {
            return $"Box contain {Count} shapes.";
        }
        public override int GetHashCode()
        {
            int code = 0;
            for(int i=0;i<Count;i++)
            {
                code += shapes[i].GetHashCode();
            }
            return code;
        }
        public override bool Equals(object obj)
        {
            if(obj is ShapeBox && obj!=null)
            {
                ShapeBox box = (ShapeBox)obj;
                if(box.Count==Count)
                {
                    for(int i=0;i<Count;i++)
                    {
                        if (box[i + 1] != shapes[i])
                            return false;
                    }
                    return true;

                }
            }
            return false;
        }

    }
}
