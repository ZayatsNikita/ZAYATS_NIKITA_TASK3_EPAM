using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.AbstractModels
{
    abstract class PlasticShape : Shape
    {
        public override void Paint(ShapeColor color)
        {
            this._color = color;
        }
    }
}
