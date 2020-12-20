using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Task3.AbstractModels
{
    public abstract class Shape
    {
        protected const double CutRatio = 0.1;

        protected ShapeColor _color = ShapeColor.Transparent;
        abstract public void Paint(ShapeColor color);
        public void CutNewShape()
        {
            if (IsIntact)
            {
                IsIntact = false;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public bool IsIntact { get; private set; } = true;
        public double[] LengthsOfSides { get;protected set; }
        public ShapeColor Color { get => _color; }
        public double SideOfSmallestLength {get; protected set;}
        abstract public double Area { get; protected set; }
        abstract public double Perimeter { get; protected set; }
        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                throw new NullReferenceException();
            }
            if(obj.GetType() == GetType())
            {
                Shape shape = (Shape)obj;
                if(shape.Color!= Color)
                {
                    return false;
                }
                
                int length = shape.LengthsOfSides.Length;
                
                for (int i = 0; i < length; i++)
                {
                    if(shape.LengthsOfSides[i]!=this.LengthsOfSides[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
