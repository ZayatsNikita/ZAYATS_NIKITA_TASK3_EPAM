using System;
using Task3.AbstractModels.TypesOfShapes;
using Task3.AbstractModels;
using Task3.AbstractModels.ShapeMaterials;
namespace Task3.ModelsOfGeometricShapes.PaperShapes
{
    public class PaperCircle : Circle, IPaper
    {
        public PaperCircle(Shape shape) : base(shape)
        {
            
        }
        public PaperCircle(params double[] lengthsOfSides) : base(lengthsOfSides)
        {
          
        }
        public override void Paint(ShapeColor color)
        {
            if(Color != ShapeColor.Transparent)
            {
                throw new ArgumentException();
            }
            else
            {
                _color = color;
            }
        }
    }
}
