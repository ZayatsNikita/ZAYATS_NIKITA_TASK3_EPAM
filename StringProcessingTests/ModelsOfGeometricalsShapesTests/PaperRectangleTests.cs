using Task3.ModelsOfGeometricShapes.PaperShapes;
using Task3.ModelsOfGeometricShapes.PlasticShapes;
using Task3.ModelsOfGeometricShapes.FilmShapes;
using Task3.AbstractModels;
using System;
using NUnit.Framework;
namespace Task3Tests.ModelsOfGeometricalsShapesTests
{
    class PaperRectangleTests
    {
        private static Shape[] shapes;
        [SetUp]
        public void Initialization()
        {
            shapes = new Shape[] {new PaperCircle(3), new PaperRectangle(4), new PaperRegularPentagon(3),   new PaperTriangle(2),
            new FilmCircle(3),new FilmRectangle(4),  new FilmRegularPentagon(3), new FilmTriangle(2),
             new PlasticCircle(3),new PlasticRectangle(4),  new PlasticRegularPentagon(3), new PlasticTriangle(2) };
        }

        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        public void CutingTests_NotSuitableShapes_ArgumentExcemptionErrorThrown(int index)
        {
            bool actual = false;
            try
            {
                new PaperRectangle(shapes[index]);
            }
            catch (ArgumentException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]

        public void CutingTests_SuitableShapes_ArgumentExcemptionErrorNonThrown(int index)
        {
            bool actual = true;
            try
            {
                new PaperRectangle(shapes[index]);
            }
            catch (ArgumentException)
            {
                actual = false;
            }
            Assert.IsTrue(actual);
        }
    }
}
