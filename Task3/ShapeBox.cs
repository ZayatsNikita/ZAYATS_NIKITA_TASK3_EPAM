using System;
using System.Collections.Generic;
using System.Text;
using Task3.AbstractModels.TypesOfShapes;
using Task3.AbstractModels;

using Task3.AbstractModels.ShapeMaterials;
using Task3.ModelsOfGeometricShapes.PlasticShapes;
using Task3.ModelsOfGeometricShapes.PaperShapes;

namespace Task3
{
    public class ShapeBox
    {
        private bool DoesFormExist(in Shape shape)
        {
            foreach (Shape sh in shapes)
            {
                if (shape.Equals(shape))
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
                foreach(Shape shape in shapes)
                {
                    resultArea += shape.Area;
                }
                return resultArea;
            }
        }
        public double ComonPerimeter
        {
            get
            {
                double resultArea = 0;
                foreach (Shape shape in shapes)
                {
                    resultArea += shape.Perimeter;
                }
                return resultArea;
            }
        }
        public ShapeBox()
        {
            shapes = new Shape[MaximumCapacity];
        }
        public void Add(Shape shape)
        {
            if (Count + 1 > MaximumCapacity)
            {
                throw new OutOfMemoryException();
            }
            if (DoesFormExist(shape))
            {
                throw new ArgumentException();
            }
            shapes[Count] = shape;
            Count++;
        }
        public int IndexOf(in Shape shape)
        {
            for (int i = 0; i < Count; i++)
            {
                if (shape.Equals(shapes[i]))
                {
                    return i;
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
            return result;
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
            return result;
        }
        public List<Shape> ExtractPlasticUnpaintedShapes()
        {
            List<Shape> result = new List<Shape>();
            for (int i = 0; i < Count; i++)
            {
                if (shapes[i] is IPlastic && shapes[i].Color == ShapeColor.Transparent)
                {
                    result.Add(shapes[i]);
                }
            }
            return result;
        }
        public Shape this[int numberOfShape]
        {
            get
            {
                if (numberOfShape > Count || numberOfShape < 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return shapes[Count - 1];
            }
            set
            {
                if (numberOfShape > Count || numberOfShape < 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                shapes[Count - 1] = value;
            }

        }
        public Shape ExtractShapeByNumber(int numberOfShape)
        {
            if (numberOfShape > Count || numberOfShape < 1)
                throw new ArgumentOutOfRangeException();
            
            Shape result = shapes[Count - 1];

            int length = Count + 1;

            for (int i = numberOfShape - 1; i < length; i++)
            {
                shapes[numberOfShape] = shapes[numberOfShape+1];
            }

            return result;
        }
         
    }
}
