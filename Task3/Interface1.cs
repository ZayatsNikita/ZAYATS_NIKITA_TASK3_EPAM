using System;
using System.Collections.Generic;
using System.Text;
using Task3.AbstractModels;
namespace Task3
{
    public interface ISheetOfMaterial
    {
        public Shape CutShape(ShapeColor shapeColor, double[] lengthOfSodes);
    }
}
