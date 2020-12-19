using System;
using Task3.AbstractModels.TypesOfShapes;
using Task3.AbstractModels;
using Task3.AbstractModels.ShapeMaterials;

namespace Task3.ModelsOfGeometricShapes.PlasticShapes
{
    class PlasticRegularPentagon : RegularPentagon,IPlastic
    {
        public PlasticRegularPentagon(Shape shape) : base(shape)
        {
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
