using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Task3;
namespace Task3Tests
{
    [TestFixture]
    class ExtensionMethodsTests
    {
        private static string[] words;
        [SetUp]
        public void Initialization()
        {
            words = new string[]{"hello", "123"};
        }
        [Test]
        public void DoesItContainTest_NotExsistWords_False()
        {
            bool actual = words.DoesItContain("papa");
            Assert.IsFalse(actual);
        }

        [TestCase("hello")]
        [TestCase("123")]
        public void DoesItContainTest_ExsistWords_True(string forSeach)
        {
            bool actual = words.DoesItContain(forSeach);
            Assert.IsTrue(actual);
        }
        [Test]
        public void DoesItContainTest_AnUninitializedArray_NullReferenceExceptionThrown()
        {
            string[] w1=null;
            bool actual = false;
            try
            {
                w1.DoesItContain("sdsd");
            }
            catch (NullReferenceException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }

        [Test]
        public void DoesItContainTest_AnUninitializedWord_NullReferenceExceptionThrown()
        {
            bool actual = false;
            try
            {
                words.DoesItContain(null);
            }
            catch (NullReferenceException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }





        [Test]
        public void intdexOfTest_NotExsistWords_minusOne()
        {
            int actual = actual = words.intdefOf("papa");
            int expected = -1;
            Assert.AreEqual(expected, actual);

        }

        [TestCase("hello",0)]
        [TestCase("123",1)]
        public void intdexOfTest_ExsistWords_IndexOfWord(string forSeach, int expected)
        {
            int actual = words.intdefOf(forSeach);
            Assert.AreEqual(expected,actual);
        }


        [Test]
        public void intdexOfTest_AnUninitializedArray_NullReferenceExceptionThrown()
        {
            string[] w1 = null;
            bool actual = false;
            try
            {
                w1.intdefOf("sdsd");
            }
            catch (NullReferenceException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }

        [Test]
        public void intdexOfTest_AnUninitializedWord_NullReferenceExceptionThrown()
        {
            bool actual = false;
            try
            {
                words.intdefOf(null);
            }
            catch (NullReferenceException)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
        }
    }
}
