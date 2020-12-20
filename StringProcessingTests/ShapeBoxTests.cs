using System;
using System.Collections.Generic;
using Task3;
using Task3.ModelsOfGeometricShapes.FilmShapes;
using NUnit.Framework;
using System.IO;
using Task3.XMLFileManager.XmlReaderWriter;
using Task3.ModelsOfGeometricShapes.PaperShapes;
using Task3.ModelsOfGeometricShapes.PlasticShapes;
using Task3.AbstractModels;
namespace Task3Tests
{
    [TestFixture]
    public class ShapeBoxTests
    {
        private static Shape[] shapes;
        [SetUp]
        public void Initialize()
        {
            shapes = new Shape[] {new PaperCircle(3), new PaperCircle(3),new PaperRectangle(4), new PaperRectangle(4), new PaperRegularPentagon(3), new PaperRegularPentagon(3), new PaperTriangle(2), new PaperTriangle(2),
            new FilmCircle(3), new FilmCircle(3),new FilmRectangle(4), new FilmRectangle(4), new FilmRegularPentagon(3), new FilmRegularPentagon(3), new FilmTriangle(2), new FilmTriangle(2),
            new PlasticCircle(3), new PlasticCircle(3),new PlasticRectangle(4), new PlasticRectangle(4), new PlasticRegularPentagon(3), new PlasticRegularPentagon(3), new PlasticTriangle(2), new PlasticTriangle(2) };
        }
        [Test]
        public void CapacityTest_MoreThen20Shapes_OutOfMemoryExceptionThrown()
        {
            ShapeBox box = new ShapeBox();
            bool actual = false;
            for (int i = 0; i < 21; i++)
            {
                try
                {
                    box.Add(new PaperCircle(i + 1));
                }
                catch (OutOfMemoryException)
                {
                    actual = true;
                }
            }
            Assert.IsTrue(actual);
        }
        [TestCase(0, 1)]
        [TestCase(2, 3)]
        [TestCase(4, 5)]
        [TestCase(6, 7)]
        [TestCase(8, 9)]
        [TestCase(10, 11)]
        [TestCase(12, 13)]
        [TestCase(14, 15)]
        [TestCase(16, 17)]
        [TestCase(18, 19)]
        [TestCase(20, 21)]
        [TestCase(22, 23)]
        public void DoesShapeExsist_SameShapes_ArgumentExceptionThrow(int firstIndex, int secondIndex)
        {
            ShapeBox box = new ShapeBox();
            bool actual = false;


            box.Add(shapes[firstIndex]);
            try
            {
                box.Add(shapes[secondIndex]);
            }
            catch (ArgumentException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }


        [TestCase(0, 1)]
        [TestCase(2, 3)]
        [TestCase(4, 5)]
        [TestCase(6, 7)]
        [TestCase(8, 9)]
        [TestCase(10, 11)]
        [TestCase(12, 13)]
        [TestCase(14, 15)]
        [TestCase(16, 17)]
        [TestCase(18, 19)]
        [TestCase(20, 21)]
        [TestCase(22, 23)]
        public void AddCollectionTest_CollectionWichEqualsItems_ArgumentExcemption(int firstIndex, int SecondIndex)
        {
            bool actual = false;
            ShapeBox box = new ShapeBox();
            List<Shape> list = new List<Shape>() {shapes[firstIndex],shapes[SecondIndex]};
            try
            {
                box.AddCollection(list);
            }
            catch (ArgumentException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }



        [Test]
        public void AddCollectionTest_NullCollection_ArgumentNullExceptionThrown()
        {
            bool actual = false;
            ShapeBox box = new ShapeBox();
            try
            {
                box.AddCollection(null);
            }
            catch (ArgumentNullException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }

        [Test]
        public void AddCollectionTest_CollectionWichConteinMoreThen20Items_ArgumentExcemption()
        {
            bool actual = false;
            ShapeBox box = new ShapeBox();
            List<Shape> list = new List<Shape>();
            for (int i = 0; i < 25; i++)
            {
                list.Add(new PaperCircle(3));
            }

            try
            {
                box.AddCollection(list);
            }
            catch (ArgumentException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }

        [Test]
        public void AddTest_NullArgument_ArgumentNullExceptionTrown()
        {
            bool actual = false;
            ShapeBox box = new ShapeBox();
            try
            {
                box.Add(null);
            }
            catch(ArgumentNullException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }   
        [TestCase(10, 5)]
        public void CountTest_AddNSharpesRemoveMSharpes_TheResultIsEqualToNMinusM(int n, int m)
        {
            ShapeBox box = new ShapeBox();
            for (int i = 0; i < 10; i++)
            {
                box.Add(new PlasticCircle(i + 1));
            }

            for (int i = 0; i < 5; i++)
            {
                box.ExtractShapeByNumber(1);
            }
            int actual = box.Count;

            int expected = n - m;
            Assert.AreEqual(expected, actual);
        }


        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(2)]//больше чем обём
        public void IndexerSetTest_WrongNumber_ArgumentOutOfRangeException(int number)
        {
            ShapeBox box = new ShapeBox();
            bool actual = false;
            try
            {
                box[number] = new FilmRectangle(3, 4);
            }
            catch (ArgumentOutOfRangeException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        [Test]
        public void IndexerSetTest_CorrectNumber_TheElementWithNumberEqualToIndexIsChangedToTheSpecifiedOne()
        {
            ShapeBox box = new ShapeBox();
            PlasticCircle circle = new PlasticCircle(3);
            PaperRectangle rectangle = new PaperRectangle(5);

            box.Add(circle);

            bool isThereCircleInside = box[1].Equals(circle);

            box[1] = rectangle;

            bool isThereRectangleInside = box[1].Equals(rectangle);

            bool actual = isThereCircleInside && isThereRectangleInside;

            bool expected = true;

            Assert.AreEqual(actual,expected);
        }

        [Test]
        public void IndexerSetTest_NullArgument_ArgumentNullExceptionTrown()
        {
            bool actual = false;
            ShapeBox box = new ShapeBox();
            box.Add(new PaperCircle(2));
            try
            {
                box[1] = (null);
            }
            catch (ArgumentNullException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(2)]
        public void IndexerGetTest_WrongNumber_ArgumentOutOfRangeException(int number)
        {
            ShapeBox box = new ShapeBox();
            box.Add(new PlasticRectangle(2));
            bool actual = false;
            try
            {
                Shape shape = box[number];
            }
            catch (ArgumentOutOfRangeException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }

        [Test]
        public void IndexerGetTest_CorrectNumber_TheShapeWillBeReceivedWithoutDeletingIt()
        {
            ShapeBox box = new ShapeBox();
            PlasticCircle circle = new PlasticCircle(3);

            box.Add(circle);
  
            Shape shape = box[1];

            bool actual = box[1].Equals(circle) && circle.Equals(shape) && box.Count==1;

            bool expected = true;

            Assert.AreEqual(actual, expected);
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(2)]
        public void ExtractShapeByNumberTest_IncorrectNumber_ArgumentOutOfRangeExceptionThrown(int number)
        {
            ShapeBox box = new ShapeBox();
            PlasticCircle circle = new PlasticCircle(3);
            box.Add(circle);
            bool actual = false;
            try
            {
                box.ExtractShapeByNumber(number);
            }
            catch(ArgumentOutOfRangeException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        public void ExtractShapeByNumberTest_CorrectNumber_ShapeWithSpecifiedNumberWillBeDeleted(int number)
        {
            ShapeBox box = new ShapeBox();
            PlasticCircle circle = new PlasticCircle(3);
            PaperRectangle rectangle = new PaperRectangle(5);
            
            box.Add(circle);
            box.Add(rectangle);


            bool ThereAreTwoFiguresInTheBox = box.Count == 2 && box[1].Equals(circle) && box[2].Equals(rectangle);

            Shape extractShape = box.ExtractShapeByNumber(1);

            bool ThereAreOneFiguresInTheBox = box.Count == 1 && box[1].Equals(rectangle);
            bool errorWhenTryingToGetTheSecondShape = false;
            try
            {
                Shape shape = box[2];
            }
            catch(ArgumentOutOfRangeException)
            {
                errorWhenTryingToGetTheSecondShape = true;
            }

            bool actual = ThereAreTwoFiguresInTheBox && ThereAreOneFiguresInTheBox && errorWhenTryingToGetTheSecondShape && extractShape.Equals(circle);

            Assert.IsTrue(actual);
        }
        [TestCase(5,3,1,3,5,7,9)]
        [TestCase(9,5,1,3,5,7,9)]
        public void NumberOfTest_ExistingShape_NumberOfShape(int indexInShapes, int expectedNumber, params int[] forAdding)
        {
            ShapeBox box = new ShapeBox();
            foreach (int index in forAdding)
            {
                box.Add(shapes[index]);
            }
            int actual = box.NumberOf(shapes[indexInShapes]);
            Assert.AreEqual(expectedNumber, actual);
        }

        [TestCase(13, 1, 3, 5, 7, 9)]
        [TestCase(11, 1, 3, 5, 7, 9)]
        public void NumberOfTest_NonExistingShape_NumberOfShape(int indexInShapes, params int[] forAdding)
        {
            ShapeBox box = new ShapeBox();
            foreach (int index in forAdding)
            {
                box.Add(shapes[index]);
            }
            int actual = box.NumberOf(shapes[indexInShapes]);
            int expected = -1;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ComonAreaTests_ThereAreNoShapesInTheBox_Null()
        {
            ShapeBox box = new ShapeBox();
            double actual = box.ComonArea;
            double expected = 0;
            Assert.AreEqual(actual,expected);
        }
        [TestCase(1,3,5,7,9,11,13,15,17,19,21)]
        public void ComonAreaTests_ThereAreShapesInTheBox_NotNull(params int[] indexs)
        {
            ShapeBox box = new ShapeBox();
            
            foreach(int index in indexs)
            {
                box.Add(shapes[index]);
            }

            double expected = 0;

            foreach (int index in indexs)
            {
                expected +=shapes[index].Area;
            }

            double actual = box.ComonArea;

            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void ComonPerimetrTests_ThereAreNoShapesInTheBox_Null()
        {
            ShapeBox box = new ShapeBox();
            double actual = box.ComonPerimeter;
            double expected = 0;
            Assert.AreEqual(actual, expected);
        }
        [TestCase(1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21)]
        public void ComonPerimetrTests_ThereAreShapesInTheBox_NotNull(params int[] indexs)
        {
            ShapeBox box = new ShapeBox();

            foreach (int index in indexs)
            {
                box.Add(shapes[index]);
            }

            double expected = 0;

            foreach (int index in indexs)
            {
                expected += shapes[index].Perimeter;
            }

            double actual = box.ComonPerimeter;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 4, 6, 10, 12, 18, 14, 20, 22)]
        public void ExtractAllCirclesTest_ThereAreNoCirclesInTheBox_InvalidOperationExceptionThrown(params int[] indexs)
        {
            ShapeBox box = new ShapeBox();

            foreach (int index in indexs)
            {
                box.Add(shapes[index]);
            }

            bool actual = false;

            try 
            {
                box.ExtractAllCircles();
            }
            catch(InvalidOperationException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);

        }


        [TestCase(1, 9,16)]   
        [TestCase(1,9)]   
        [TestCase(1)]   
        public void ExtractAllCirclesTest_ThereAreCirclesInTheBox_ListWithCircles(params int[] indexs)
        {
            ShapeBox box = new ShapeBox();
            int[] arrayWithoutCirecle = new int[] { 2, 4, 6, 10, 12, 18, 14, 20, 22 };
            foreach (int index in arrayWithoutCirecle)
            {
                box.Add(shapes[index]);
            }
            foreach (int index in indexs)
            {
                box.Add(shapes[index]);
            }
            List<Shape> expected = new List<Shape>();
            foreach (int index in indexs)
            {
                expected.Add(shapes[index]);
            }

            List<Shape> actual = box.ExtractAllCircles();
            

            CollectionAssert.AreEqual(actual, expected);

        }


        [TestCase(0, 2, 4, 6, 17, 19, 21, 23)]
        public void ExtractAllFilmShapeTest_ThereAreFilmShapesInTheBox_InvalidOperationExceptionThrown(params int[] indexs)
        {
            ShapeBox box = new ShapeBox();

            foreach (int index in indexs)
            {
                box.Add(shapes[index]);
            }

            bool actual = false;

            try
            {
                box.ExtractAllFilmShapes();
            }
            catch (InvalidOperationException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);

        }

        [TestCase(8)]
        [TestCase(8, 10)]
        [TestCase(8,10,12,14)]
        public void ExtractAllFilmShapesTest_ThereAreFilmShapesInTheBox_ListWithFilmShapes(params int[] indexs)
        {
            ShapeBox box = new ShapeBox();
            int[] arrayWithoutCirecle = new int[] { 0, 2, 4, 6, 17, 19, 21, 23 };
            foreach (int index in arrayWithoutCirecle)
            {
                box.Add(shapes[index]);
            }
            foreach (int index in indexs)
            {
                box.Add(shapes[index]);
            }
            List<Shape> expected = new List<Shape>();
            foreach (int index in indexs)
            {
                expected.Add(shapes[index]);
            }

            List<Shape> actual = box.ExtractAllFilmShapes();


            CollectionAssert.AreEqual(actual, expected);

        }

        [Test]
        public void ExtractAllExtractAllNonPaintedPlasticShapesTest_ThereAreNoNonPaintedPlasticShapesInTheBox_InvalidOperationExceptionThrown()
        {
            ShapeBox box = new ShapeBox();

            for (int i = 0; i < 24; i+=2)
            {
                box.Add(shapes[i]);
            }
    
            bool actual = false;

            for(int i=9;i<13;i++)
            {
                box[i].Paint(ShapeColor.Red);
            }

            try
            {
                box.ExtractAllNonPaintedPlasticShapes();
            }
            catch (InvalidOperationException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }

        [TestCase(10,18,20,22)]
        [TestCase(11,20,22)]
        [TestCase(12,22)]
        public void ExtractAllExtractAllNonPaintedPlasticShapesTest_ThereAreNonPaintedPlasticShapesInTheBox_ListWithNonPaintedPlasticShapes(int numberOfPainting, params int[] indexsesOfnonPaintedPlsaticShapesInShapes)
        {
            ShapeBox box = new ShapeBox();

            for (int i = 0; i < 24; i += 2)
            {
                box.Add(shapes[i]);
            }

            for (int i = 9; i < numberOfPainting; i++)
            {
                box[i].Paint(ShapeColor.Red);
            }

            List<Shape> expected = new List<Shape>();
            foreach(int index in indexsesOfnonPaintedPlsaticShapesInShapes)
            {
                expected.Add(shapes[index]);
            }
            
            List<Shape> actual =  box.ExtractAllNonPaintedPlasticShapes();
            
            
            CollectionAssert.AreEqual(expected,actual);
        }

        [TestCase("All",0,24)]
        [TestCase("IPaper",0,7)]
        [TestCase("IPlastic",16,23)]
        [TestCase("IFilm", 8, 15)]
        public void SaveShapesToXmlUsingXmlWriterTest_CorectTypes_DataWillBePlacedInAFileAfterWhichListEqualToTheOriginalOneWillBeCreatedBasedOnTheDataFromTheFile(string type, int startindex, int stopIndex)
        {
            ShapeBox box = new ShapeBox();
            for (int i = 0; i < 24; i+=2)
            {
                box.Add(shapes[i]);
            }
            box.SaveShapesToXmlUsingXmlWriter(type,@"D:\Learn\EPAM\task3\Task3\testFile.xml");

            List<Shape> actual = XmlFileManager.Parse(@"D:\Learn\EPAM\task3\Task3\testFile.xml");
            List<Shape> expexted = new List<Shape>();

            for (int i = startindex; i < stopIndex; i+=2)
            {
                expexted.Add(shapes[i]);
            }

            CollectionAssert.AreEqual(expexted,actual);
        }
        [TestCase("IPaper", 8, 24)]
        [TestCase("IPlastic",  0, 15)]
        [TestCase("IFilm", 16, 24)]
        public void SaveShapesToXmlUsingXmlWriterTest_TypesThatAreNotContainedInTheBox_InvalidOperationExceptionThrown(string type, int startIndex, int stopIndex)
        {
            ShapeBox box = new ShapeBox();
            bool actual = false;
            for (int i = startIndex; i < stopIndex; i += 2)
            {
                box.Add(shapes[i]);
            }
            try
            {
                box.SaveShapesToXmlUsingXmlWriter(type, @"D:\Learn\EPAM\task3\Task3\testFile.xml");
            }
            catch(InvalidOperationException)
            {
                actual = true;
            }

            Assert.IsTrue(actual);
        }
        [TestCase("ksfdlj", 0, 24)]
        [TestCase("gffgfd", 0, 24)]
        public void SaveShapesToXmlUsingXmlWriterTest_NonExsisTypes_ArgumentExceptionThrown(string type, int startIndex, int stopIndex)
        {
            ShapeBox box = new ShapeBox();
            bool actual = false;
            for (int i = startIndex; i < stopIndex; i += 2)
            {
                box.Add(shapes[i]);
            }
            try
            {
                box.SaveShapesToXmlUsingXmlWriter(type, @"D:\Learn\EPAM\task3\Task3\testFile.xml");
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.IsTrue(actual);
        }

        [TestCase("All", 0, 24)]
        [TestCase("IPaper", 0, 7)]
        [TestCase("IPlastic", 16, 23)]
        [TestCase("IFilm", 8, 15)]
        public void SaveShapesToXmlUsingStreamWriterTest_CorectTypes_DataWillBePlacedInAFileAfterWhichListEqualToTheOriginalOneWillBeCreatedBasedOnTheDataFromTheFile(string type, int startindex, int stopIndex)
        {
            ShapeBox box = new ShapeBox();
            for (int i = 0; i < 24; i += 2)
            {
                box.Add(shapes[i]);
            }
            box.SaveShapesToXmlUsingStreamWriter(type, @"D:\Learn\EPAM\task3\Task3\testFile.xml");

            List<Shape> actual = XmlFileManager.Parse(@"D:\Learn\EPAM\task3\Task3\testFile.xml");
            List<Shape> expexted = new List<Shape>();

            for (int i = startindex; i < stopIndex; i += 2)
            {
                expexted.Add(shapes[i]);
            }

            CollectionAssert.AreEqual(expexted, actual);
        }
        [TestCase("IPaper", 8, 24)]
        [TestCase("IPlastic", 0, 15)]
        [TestCase("IFilm", 16, 24)]
        public void SaveShapesToXmlUsingStreamWriterTest_TypesThatAreNotContainedInTheBox_InvalidOperationExceptionThrown(string type, int startIndex, int stopIndex)
        {
            ShapeBox box = new ShapeBox();
            bool actual = false;
            for (int i = startIndex; i < stopIndex; i += 2)
            {
                box.Add(shapes[i]);
            }
            try
            {
                box.SaveShapesToXmlUsingStreamWriter(type, @"D:\Learn\EPAM\task3\Task3\testFile.xml");
            }
            catch (InvalidOperationException)
            {
                actual = true;
            }

            Assert.IsTrue(actual);
        }
        [TestCase("ksfdlj", 0, 24)]
        [TestCase("gffgfd", 0, 24)]
        public void SaveShapesToXmlUsingStreamWriterTest_NonExsisTypes_ArgumentExceptionThrown(string type, int startIndex, int stopIndex)
        {
            ShapeBox box = new ShapeBox();
            bool actual = false;
            for (int i = startIndex; i < stopIndex; i += 2)
            {
                box.Add(shapes[i]);
            }
            try
            {
                box.SaveShapesToXmlUsingStreamWriter(type, @"D:\Learn\EPAM\task3\Task3\testFile.xml");
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.IsTrue(actual);
        }

        [Test]
        public void LoadShapesFromXmlUsingStreamReaderTest_NonExsisFile_FileNotFoundExceptionThrown()
        {
            ShapeBox box = new ShapeBox();
            bool actual = false;
            try
            {
                box.LoadShapesFromXmlUsingStreamReader("abra_cadabra");
            }
            catch(FileNotFoundException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        [Test]
        public void LoadShapesFromXmlUsingStreamReaderTest_FileWichContainMoreThen20Shapes_FileNotFoundExceptionThrown()
        {
            ShapeBox box = new ShapeBox();
            bool actual = false;
            try
            {
                box.LoadShapesFromXmlUsingStreamReader(@"D:\Learn\EPAM\task3\StringProcessingTests\xmlFiles\xmlWithMoreThen20Elements.xml");
            }
            catch (ArgumentException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
       
        [TestCase(@"D:\Learn\EPAM\task3\StringProcessingTests\xmlFiles\xmlWitoutData.xml")]
        [TestCase(@"D:\Learn\EPAM\task3\StringProcessingTests\xmlFiles\xmlWithoutCountOfSides.xml")]
        public void LoadShapesFromXmlUsingStreamReaderTest_FileWichContainIncorrectData_FormatExceptionThrown(string path)
        {
            ShapeBox box = new ShapeBox();
            bool actual = false;
            try
            {
                box.LoadShapesFromXmlUsingStreamReader(path);
            }
            catch (FormatException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        [Test]
        public void LoadShapesFromXmlUsingStreamReaderTest_FileWithCorrectData_BoxWillContainFiguresFromTheFile()
        {
            ShapeBox box = new ShapeBox();
            List<Shape> expected = new List<Shape>();
            for (int i = 0; i < 24; i += 2)
            {
                expected.Add(shapes[i]);
            }

            box.LoadShapesFromXmlUsingStreamReader(@"D:\Learn\EPAM\task3\StringProcessingTests\xmlFiles\xmlWithCorrectData.xml");
            List<Shape> actual = new List<Shape>(box.Count);
            for (int i = 1; i <= box.Count; i++)
            {
                actual.Add(box[i]);
            }
            CollectionAssert.AreEqual(expected,actual);
        }
        [Test]
        public void LoadShapesFromXmlUsingXmlReaderTest_NonExsisFile_FileNotFoundExceptionThrown()
        {
            ShapeBox box = new ShapeBox();
            bool actual = false;
            try
            {
                box.LoadShapesFromXmlUsingXmlReader("abra_cadabra");
            }
            catch (FileNotFoundException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        [Test]
        public void LoadShapesFromXmlUsingXmlReaderTest_FileWichContainMoreThen20Shapes_FileNotFoundExceptionThrown()
        {
            ShapeBox box = new ShapeBox();
            bool actual = false;
            try
            {
                box.LoadShapesFromXmlUsingXmlReader(@"D:\Learn\EPAM\task3\StringProcessingTests\xmlFiles\xmlWithMoreThen20Elements.xml");
            }
            catch (ArgumentException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        [TestCase(@"D:\Learn\EPAM\task3\StringProcessingTests\xmlFiles\xmlWitoutData.xml")]
        [TestCase(@"D:\Learn\EPAM\task3\StringProcessingTests\xmlFiles\xmlWithoutCountOfSides.xml")]
        public void LoadShapesFromXmlUsingXmlReaderTest_FileWichContainIncorrectData_FormatExceptionThrown(string path)
        {
            ShapeBox box = new ShapeBox();
            bool actual = false;
            try
            {
                box.LoadShapesFromXmlUsingXmlReader(path);
            }
            catch (FormatException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
        [Test]
        public void LoadShapesFromXmlUsingXmlReaderTest_FileWithCorrectData_BoxWillContainFiguresFromTheFile()
        {
            ShapeBox box = new ShapeBox();
            List<Shape> expected = new List<Shape>();
            for (int i = 0; i < 24; i += 2)
            {
                expected.Add(shapes[i]);
            }

            box.LoadShapesFromXmlUsingXmlReader(@"D:\Learn\EPAM\task3\StringProcessingTests\xmlFiles\xmlWithCorrectData.xml");
            List<Shape> actual = new List<Shape>(box.Count);
            for (int i = 1; i <= box.Count; i++)
            {
                actual.Add(box[i]);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}
