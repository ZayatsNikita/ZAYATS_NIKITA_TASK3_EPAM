using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public enum ShapeColor
    {
        Red,
        Black,
        Yellow,
        Blue,
        Transparent
    }
    public enum ExistShapes
    {
        FilmCircle,
        FilmRectangle,
        FilmRegularPentagon,
        FilmTriangle,



        PaperCircle,
        PaperRectangle,
        PaperRegularPentagon,
        PaperTriangle,



        PlasticCircle,
        PlasticRectangle,
        PlasticRegularPentagon,
        PlasticTriangle

    }
    
    public enum ExsisMaterialsInterfaces
    {
        IFilm,
        IPaper,
        IPlastic
    }

}
