using System;
using Task3.AbstractModels.TypesOfShapes;
using Task3.AbstractModels;
using Task3.AbstractModels.ShapeMaterials;

namespace Task3.ModelsOfGeometricShapes.PlasticShapes
{
    class PlasticRectangle :Rectangle, IPlastic
    {
        public PlasticRectangle(Shape shape) :base(shape)
        {
        }
        public PlasticRectangle(params double[] lengthsOfSides):base(lengthsOfSides)
        {
        }
        public override void Paint(ShapeColor color)
        {
            _color = color;
        }
    }
}

