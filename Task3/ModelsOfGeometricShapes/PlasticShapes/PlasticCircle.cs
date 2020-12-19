using System;
using Task3.AbstractModels.TypesOfShapes;
using Task3.AbstractModels;
using Task3.AbstractModels.ShapeMaterials;

namespace Task3.ModelsOfGeometricShapes.PlasticShapes
{
    class PlasticCircle : Circle,IPlastic
    {
        public PlasticCircle(Shape shape) : base(shape)
        {
        }
        public PlasticCircle(params double[] lengthsOfSides) : base(lengthsOfSides)
        {
        }
        public override void Paint(ShapeColor color)
        {
            _color = color;
        }
    }
}
