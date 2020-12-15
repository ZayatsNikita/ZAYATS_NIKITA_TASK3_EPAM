using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Task3.AbstractModels
{
    abstract class Shape
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
    }
}
