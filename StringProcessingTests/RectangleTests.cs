using Task3.ModelsOfGeometricShapes.PaperShapes;
using System;
using Task3.AbstractModels.TypesOfShapes;
using NUnit.Framework;


namespace Task3Tests
{
    [TestFixture]
    class RectangleTests
    {
        [TestCase(20,5,4)]
        [TestCase(25,5)]
        public void AreaTest_SidesLength_RectengleWithSpecificArea(double expexted, params double[] sides)
        {
            Rectangle rectangle = new PaperRectangle(sides);
            double actual = rectangle.Area;
            Assert.AreEqual(expexted, actual, 0.1);
        }
        [TestCase(18, 5, 4)]
        [TestCase(20, 5)]
        public void PerimetrTest_SidesLength_RectangleWithSpecificPerimetr(double expexted, params double[] sides)
        {
            Rectangle rectangle = new PaperRectangle(sides);
            double actual = rectangle.Perimeter;
            Assert.AreEqual(expexted, actual, 0.1);
        }

        [TestCase(-1)]
        [TestCase(10, -20)]
        [TestCase(10, 20, 1)]
        public void CreatingTest_WrongSides_ArgumentExceptionThrown(params double[] sides)
        {
            bool actual = false;
            try
            {
                new PaperRectangle(sides);
            }
            catch (ArgumentException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        [TestCase(10, 20)]
        [TestCase(10)]
        public void CreatingTest_CorrectSides_ArgumentExceptionNotThrown(params double[] sides)
        {
            bool actual = true;
            try
            {
                new PaperRectangle(sides);
            }
            catch (ArgumentException)
            {
                actual = false;
            }
            Assert.IsTrue(actual);
        }
    }
}
