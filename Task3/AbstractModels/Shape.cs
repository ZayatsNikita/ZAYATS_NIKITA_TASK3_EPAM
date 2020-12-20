using System;
using System.Text;
namespace Task3.AbstractModels
{
    public abstract class Shape
    {
        protected double area;
        protected double perimetr;
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
        public double Area
        {
            get
            {
                if (IsIntact)
                {
                    return area;
                }
                throw new ArgumentException();
            }
            protected set
            {
                area = value;
            }
        }
        public double Perimeter
        {
            get
            {
                if (IsIntact)
                {
                    return perimetr;
                }
                throw new ArgumentException();
            }
            protected set
            {
                perimetr = value;
            }
        }
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
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{this.GetType().Name}; Perimeter = {Perimeter}; Area = {Area}; Color = {Color}; Sides:");
            foreach( double length in LengthsOfSides)
            {
                stringBuilder.Append($" {length};");
            }
            return stringBuilder.ToString();
        }
        public override int GetHashCode()
        {
            int res =  _color.GetHashCode() + IsIntact.GetHashCode() + Area.GetHashCode() + Perimeter.GetHashCode();
            foreach (double length in LengthsOfSides)
            {
                res += length.GetHashCode();
            }
            return res;
        }
    }
}
