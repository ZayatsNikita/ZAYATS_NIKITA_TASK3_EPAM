using Task3.ModelsOfGeometricShapes.PaperShapes;
using System;
using Task3.AbstractModels.TypesOfShapes;
using NUnit.Framework;
namespace Task3Tests
{
    [TestFixture]
    public class RegularPentogramsTests
    {
        [TestCase(43, 5)]
        [TestCase(43, 5, 5, 5,5,5)]
        public void AreaTest_SidesLength_PentagonWithSpecificArea(double expexted, params double[] sides)
        {
            RegularPentagon pentagon = new PaperRegularPentagon(sides);
            double actual = pentagon.Area;
            Assert.AreEqual(expexted, actual, 0.1);
        }
        [TestCase(25, 5)]
        [TestCase(25, 5, 5, 5,5,5)]
        public void PerimetrTest_SidesLength_PentagonWithSpecificPerimeter(double expexted, params double[] sides)
        {
            RegularPentagon pentagon = new PaperRegularPentagon(sides);
            double actual = pentagon.Perimeter;
            Assert.AreEqual(expexted, actual, 0.1);
        }

        [TestCase(-1)]
        [TestCase(2,2)]
        [TestCase(10, 20, 8)]
        [TestCase(5, 5, 5, 5)]
        [TestCase(5, 5, 5, 5, -5)]
        [TestCase(5, 5, 5, 5, 4)]
        public void CreatingTest_WrongSides_ArgumentExceptionThrown(params double[] sides)
        {
            bool actual = false;
            try
            {
                new PaperRegularPentagon(sides);
            }
            catch (ArgumentException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        [TestCase(5)]
        [TestCase(5,5,5,5,5)]
        public void CreatingTest_CorrectSides_ArgumentExceptionNotThrown(params double[] sides)
        {
            bool actual = true;
            try
            {
                new PaperRegularPentagon(sides);
            }
            catch (ArgumentException)
            {
                actual = false;
            }
            Assert.IsTrue(actual);
        }
    }
}
