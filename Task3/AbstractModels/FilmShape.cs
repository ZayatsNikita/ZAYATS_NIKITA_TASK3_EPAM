using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.AbstractModels
{
    abstract class FilmShape : Shape
    {
        public override void Paint(ShapeColor color)
        {
            throw new NotImplementedException();
        }
    }
}
