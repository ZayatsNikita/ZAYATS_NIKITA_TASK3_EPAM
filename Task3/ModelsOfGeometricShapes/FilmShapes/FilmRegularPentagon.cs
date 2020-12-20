using System;
using Task3.AbstractModels.TypesOfShapes;
using Task3.AbstractModels;
using Task3.AbstractModels.ShapeMaterials;

namespace Task3.ModelsOfGeometricShapes.FilmShapes
{
    public class FilmRegularPentagon : RegularPentagon,IFilm
    {
        public FilmRegularPentagon(Shape shape) : base(shape)
        {
        }
        public FilmRegularPentagon(params double[] lengthsOfSides) : base(lengthsOfSides)
        {
        }
        public override void Paint(ShapeColor color)
        {
            throw new ArgumentException();
        }
    }
}
