
using Task3.AbstractModels;
using Task3.ModelsOfGeometricShapes.PaperShapes;
using Task3.ModelsOfGeometricShapes.PlasticShapes;
using Task3.ModelsOfGeometricShapes.FilmShapes;
using System;
using Task3.AbstractModels.TypesOfShapes;
using NUnit.Framework;

namespace Task3Tests
{
    [TestFixture]
    class CircleTests
    {
        [Test]
        public void AreaTest_Diametr5_10_35SqrtUnits()
        {
            Circle circle = new PaperCircle(5);
            double actual = circle.Area;
            double expexted = 2.5*2.5*Math.PI;
            Assert.AreEqual(expexted,actual,0.1);
        }
        [Test]
        public void PerimetrTest_Diametr5_10_35SqrtUnits()
        {
            Circle circle = new PaperCircle(5);
            double actual = circle.Perimeter;
            double expexted = 5*Math.PI;
            Assert.AreEqual(expexted, actual, 0.1);
        }

        [TestCase(-1)]
        [TestCase(10,20)]
        [TestCase(10,20,-1)]
        public void CreatingTest_WrongSides_ArgumentExceptionThrown(params double[] sides)
        {
            bool actual=false;
            try
            {
                new PaperCircle(sides);
            }
            catch(ArgumentException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }


    }
}
