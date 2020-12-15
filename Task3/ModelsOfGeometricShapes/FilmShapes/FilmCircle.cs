using System;
using Task3.AbstractModels;
using Task3.Validation;
namespace Task3.ModelsOfGeometricShapes.FilmShapes
{
    class FilmCircle : FilmShape
    {
        public FilmCircle(Shape shape)
        {
            if (shape.GetType().BaseType == typeof(PaperShape))
            {
                shape.CutNewShape();

                LengthsOfSides = new double[1] { shape.SideOfSmallestLength * CutRatio };

                Perimeter = LengthsOfSides[0] * 2 * Math.PI;

                Area = Math.PI * LengthsOfSides[0] * LengthsOfSides[0];

                SideOfSmallestLength = LengthsOfSides[0];
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public FilmCircle(params double[] lengthsOfSides)
        {
            if (!CreatingShapesValidation.IsCircle(lengthsOfSides))
                throw new ArgumentException();

            LengthsOfSides = lengthsOfSides;

            Perimeter = LengthsOfSides[0] * 2 * Math.PI;

            Area = Math.PI * LengthsOfSides[0] * LengthsOfSides[0];

            SideOfSmallestLength = LengthsOfSides[0];
        }
        public override double Area { get; protected set; }
        public override double Perimeter { get; protected set; }
    }
}
