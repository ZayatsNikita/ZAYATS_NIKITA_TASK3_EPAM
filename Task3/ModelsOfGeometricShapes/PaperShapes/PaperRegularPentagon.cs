using System;
using Task3.AbstractModels.TypesOfShapes;
using Task3.AbstractModels;
using Task3.AbstractModels.ShapeMaterials;

namespace Task3.ModelsOfGeometricShapes.PaperShapes
{
    public class PaperRegularPentagon : RegularPentagon,IPaper
    {
        public PaperRegularPentagon(Shape shape) : base(shape)
        {
        }
        public PaperRegularPentagon(params double[] lengthsOfSides) : base(lengthsOfSides)
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
