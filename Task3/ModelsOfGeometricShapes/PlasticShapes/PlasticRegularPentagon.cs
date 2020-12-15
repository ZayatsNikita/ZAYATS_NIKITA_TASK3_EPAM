using System;
using System.Collections.Generic;
using System.Text;
using Task3.AbstractModels;
using Task3.Validation;
namespace Task3.ModelsOfGeometricShapes.PlasticShapes
{
    class PlasticRegularPentagon : PlasticShape
    {
        public PlasticRegularPentagon(Shape shape)
        {
            if (shape.GetType().BaseType == typeof(PaperShape))
            {
                shape.CutNewShape();

                double length = shape.SideOfSmallestLength * CutRatio;

                LengthsOfSides = new double[5] { length, length, length, length, length };

                Perimeter = length * 5;

                Area = 5 * length * length / 4 / Math.Tan(36);

                SideOfSmallestLength = LengthsOfSides[0];

                Paint(shape.Color);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public PlasticRegularPentagon(params double[] lengthsOfSides)
        {
            if (!CreatingShapesValidation.IsRegularPentagon(lengthsOfSides))
                throw new ArgumentException();
            if (lengthsOfSides.Length == 5)
            {
                LengthsOfSides = lengthsOfSides;
            }
            else
            {
                LengthsOfSides = new double[5] { lengthsOfSides[0], lengthsOfSides[0], lengthsOfSides[0], lengthsOfSides[0], lengthsOfSides[0] };
            }

            Perimeter = LengthsOfSides[0] * 5;

            Area = Area = 5 * LengthsOfSides[0] * LengthsOfSides[0] / 4 / Math.Tan(36);

            SideOfSmallestLength = LengthsOfSides[0];
        }
        public override double Area { get; protected set; }
        public override double Perimeter { get; protected set; }
    }
}
