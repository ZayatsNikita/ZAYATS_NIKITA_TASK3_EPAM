using System;
using Task3.AbstractModels.TypesOfShapes;
using Task3.AbstractModels;
using Task3.AbstractModels.ShapeMaterials;

namespace Task3.ModelsOfGeometricShapes.PlasticShapes
{
    public class PlasticTriangle : Triangle,IPlastic
    {
        public PlasticTriangle(Shape shape) : base(shape)
        {
            if (shape.GetType().GetInterface("Task3.AbstractModels.ShapeMaterials.IPlastic") == null)
            {
                throw new ArgumentException();
            }
        }
        public PlasticTriangle(params double[] lengthsOfSides) : base(lengthsOfSides)
        {
        }
        public override void Paint(ShapeColor color)
        {
            _color = color;
        }
    }
}
