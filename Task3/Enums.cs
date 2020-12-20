using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    /// <summary>
    /// Enumeration containing shape colors
    /// </summary>
    public enum ShapeColor
    {
        Red,
        Black,
        Yellow,
        Blue,
        Transparent
    }
    /// <summary>
    /// An enumeration that contains the names of existing non abstract shapes
    /// </summary>
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
