using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.AbstractModels
{
    abstract class PaperShape : Shape
    {
        private const int AllowedNumberOfPaintLayers = 1;

        private int NumberOfLayersOfPaint = 0;
        
        public override void Paint(ShapeColor color)
        {
            if (NumberOfLayersOfPaint  < AllowedNumberOfPaintLayers)
            {
                this._color = color;
                NumberOfLayersOfPaint ++;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Paper figures can only be painted 1 time!!!");
            }

        }
    }
}
