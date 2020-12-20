﻿using System;
using Task3.AbstractModels;
using Task3.Validation;
using System.Linq;

namespace Task3.AbstractModels.TypesOfShapes
{
    public abstract class Rectangle : Shape
    {
        public Rectangle(Shape shape)
        {
                shape.CutNewShape();

                double lengthOfSize = shape.SideOfSmallestLength * CutRatio;

                LengthsOfSides = new double[2] { lengthOfSize, lengthOfSize };

                Perimeter = 2 * (LengthsOfSides[0] + LengthsOfSides[1]);

                Area = LengthsOfSides[0] * LengthsOfSides[1];

                SideOfSmallestLength = LengthsOfSides[0] > LengthsOfSides[1] ? LengthsOfSides[1] : LengthsOfSides[0];

            if (shape.Color != ShapeColor.Transparent)
            {
                Paint(shape.Color);
            }
        }
        public Rectangle(params double[] lengthsOfSides)
        {
            if (!CreatingShapesValidation.IsRectangle(lengthsOfSides))
                throw new ArgumentException();

            if (lengthsOfSides.Length == 1)
            {
                LengthsOfSides = new double[2] { lengthsOfSides[0], lengthsOfSides[0] };
                SideOfSmallestLength = lengthsOfSides[0];
            }
            else
            {
                LengthsOfSides = lengthsOfSides;
            }
            SideOfSmallestLength = LengthsOfSides[0] > LengthsOfSides[1] ? LengthsOfSides[1] : LengthsOfSides[0];
            Perimeter = 2 * (LengthsOfSides[0] + LengthsOfSides[1]);
            Area = LengthsOfSides[0] * LengthsOfSides[1];
        }
    }
}

