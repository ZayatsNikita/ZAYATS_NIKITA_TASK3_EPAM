using System;
using Task3.AbstractModels.TypesOfShapes;
using Task3.AbstractModels;
using Task3.AbstractModels.ShapeMaterials;

namespace Task3.ModelsOfGeometricShapes.FilmShapes
{
    public class FilmCircle :Circle ,IFilm
    {
        public FilmCircle(Shape shape) : base(shape)
        {
        }
        public FilmCircle(params double[] lengthsOfSides) : base(lengthsOfSides)
        { 
        }
        public override void Paint(ShapeColor color)
        {
            throw new ArgumentException();
        }
    }
}
