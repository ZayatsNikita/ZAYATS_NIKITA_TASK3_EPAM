using System;
using System.Text;
using Task3.AbstractModels.ComonInterfaces;

namespace Task3.AbstractModels
{
    /// <summary>
    /// A class that describes an abstract shape.
    /// </summary>
    public abstract class Shape : IShape
    {
        protected double area;
        protected double perimetr;
        protected const double CutRatio = 0.1;
        protected ShapeColor _color = ShapeColor.Transparent;

        /// <summary>
        /// The method that is responsible for painting the shape.
        /// </summary>
        /// <param name="color">The new color of the shape.</param>
        /// <exception cref="ArgumentException">Throw if the figure is trying to be repainted in a transparent color.</exception>
        virtual public void Paint(ShapeColor color)
        {
            if (color == ShapeColor.Transparent)
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Method that sets the value of the <c>isintact</c> property to false.
        /// </summary>
        /// <remarks>Should be called if one shape is cut from another.</remarks>
        /// <exception cref="InvalidOperationException">Throw if another shape has already been cut from the shape.</exception>
        public void CutNewShape()
        {
            if (IsIntact)
            {
                IsIntact = false;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        /// <summary>
        /// Property describing the integrity of the shape.
        /// </summary>
        public bool IsIntact { get; private set; } = true;
        /// <summary>
        /// Property describing the length of the sides of the shape.
        /// </summary>
        public double[] LengthsOfSides { get;protected set; }
        /// <summary>
        /// Property describing the color of the shape.
        /// </summary>
        public ShapeColor Color { get => _color; }

        /// <summary>
        /// Property describing the smallest side of the shape.
        /// </summary>
        public double SideOfSmallestLength {get; protected set;}
        /// <summary>
        /// Property describing the area of the shape.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the integrity of the shape is broken.</exception>
        public double Area
        {
            get
            {
                if (IsIntact)
                {
                    return area;
                }
                throw new InvalidOperationException();
            }
            protected set
            {
                area = value;
            }
        }
        /// <summary>
        /// Property describing the perimeter of the shape.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the integrity of the shape is broken.</exception>
        public double Perimeter
        {
            get
            {
                if (IsIntact)
                {
                    return perimetr;
                }
                throw new InvalidOperationException();
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
