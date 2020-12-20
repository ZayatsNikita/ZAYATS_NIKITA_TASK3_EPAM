using Task3.ModelsOfGeometricShapes.PaperShapes;
using System;
using Task3.AbstractModels.TypesOfShapes;
using NUnit.Framework;

namespace Task3Tests
{
    [TestFixture]
    class TriangleTests
    {
        [TestCase(10.8,5)]
        [TestCase(6,3,4,5)]
        public void AreaTest_SidesLength_TriangleWithSpecificArea(double expexted, params double[] sides)
        {
            Triangle triangle = new PaperTriangle(sides);
            double actual = triangle.Area;
            Assert.AreEqual(expexted, actual, 0.1);
        }
        [TestCase(15, 5)]
        [TestCase(12, 3, 4, 5)]
        public void PerimetrTest_SidesLength_TriangleWithSpecificPerimetr(double expexted,params double[] sides)
        {
            Triangle triangle = new PaperTriangle(sides);
            double actual = triangle.Perimeter;
            Assert.AreEqual(expexted, actual, 0.1);
        }

        [TestCase(-1)]
        [TestCase(10, -20)]
        [TestCase(10, 20, -1)]
        [TestCase(10,20,8)]
        public void CreatingTest_WrongSides_ArgumentExceptionThrown(params double[] sides)
        {
            bool actual = false;
            try
            {
                new PaperTriangle(sides);
            }
            catch (ArgumentException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        [TestCase(10, 10, 10)]
        [TestCase(20,13,13)]
        [TestCase(10)]
        public void CreatingTest_CorrectSides_ArgumentExceptionNotThrown(params double[] sides)
        {
            bool actual = true;
            try
            {
                new PaperTriangle(sides);
            }
            catch (ArgumentException)
            {
                actual = false;
            }
            Assert.IsTrue(actual);
        }
    }
}
