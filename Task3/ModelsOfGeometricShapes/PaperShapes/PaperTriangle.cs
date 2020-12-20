using System;
using Task3.AbstractModels.TypesOfShapes;
using Task3.AbstractModels;
using Task3.AbstractModels.ShapeMaterials;

namespace Task3.ModelsOfGeometricShapes.PaperShapes
{
    public class PaperTriangle : Triangle, IPaper
    {
        public PaperTriangle(Shape shape):base(shape)
        {
            if (shape.GetType().GetInterface("Task3.AbstractModels.ShapeMaterials.IPaper") == null)
            {
                throw new ArgumentException();
            }
        }
        public PaperTriangle(params double[] lengthsOfSides):base(lengthsOfSides)
        {
        }
        public override void Paint(ShapeColor color)
        {
            if (Color != ShapeColor.Transparent)
            {
                throw new NotSupportedException();
            }
            else
            {
                _color = color;
            }
        }
    }
}
