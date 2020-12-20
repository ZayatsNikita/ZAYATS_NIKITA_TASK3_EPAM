using System;
using Task3.AbstractModels.TypesOfShapes;
using Task3.AbstractModels;
using Task3.AbstractModels.ShapeMaterials;

namespace Task3.ModelsOfGeometricShapes.PlasticShapes
{
    public class PlasticRegularPentagon : RegularPentagon,IPlastic
    {
        public PlasticRegularPentagon(Shape shape) : base(shape)
        {
            if (shape.GetType().GetInterface("Task3.AbstractModels.ShapeMaterials.IPlastic") == null)
            {
                throw new ArgumentException();
            }
        }
        public PlasticRegularPentagon(params double[] lengthsOfSides) : base(lengthsOfSides)
        {
        }
        public override void Paint(ShapeColor color)
        {
            _color = color;
        }
    }
}
