using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToString;

namespace NumberToStringTests
{
    [TestClass]
    public class NumberByWordsTest
    {
        [TestMethod]
        public void TransformToWords_SetNumber_ReturnString()
        {
            //arrange
            int number = 12;
            EN english = new EN();

            //act
            string actual = english.TransformToWords(number);

            //assert
            Assert.AreEqual("twelve", actual);
        }

        [TestMethod]
        public void DefineTens_UniqValues()
        {
            //arrange
            EN english = new EN();
            Ru russian = new Ru();

            //assert
            CollectionAssert.AllItemsAreUnique(english.DefineTens());
            CollectionAssert.AllItemsAreUnique(russian.DefineTens());
        }

        [TestMethod]
        public void DefineUnits_UniqValues()
        {
            //arrange
            EN english = new EN();
            Ru russian = new Ru();

            //assert
            CollectionAssert.AllItemsAreUnique(english.DefineUnits());
            CollectionAssert.AllItemsAreUnique(russian.DefineUnits());
        }

        [TestMethod]
        public void ListInitialazier_UniqValues()
        {
            //arrange
            EN english = new EN();
            Ru russian = new Ru();

            //assert
            CollectionAssert.AllItemsAreUnique(english.ListInitialazier());
            CollectionAssert.AllItemsAreUnique(russian.ListInitialazier());
        }

        [TestMethod]
        public void InitializeDictionary_UniqValues()
        {
            //arrange
            BusinessLogic bl = new BusinessLogic();

            //assert
            CollectionAssert.AllItemsAreUnique(bl.InitializeDictionary());
        }

        [TestMethod]
        public void GetWords_SetValue_ReturnByWords()
        {
            //arrange
            BusinessLogic bl = new BusinessLogic();
            string number = "-12,48";
            string point = "point";
            string minus = "minus";

            //act
            string words = bl.GetWords(number, point, minus);

            //assert
            Assert.AreEqual("minus twelve point forty-eight", words);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void GetWords_IncorrectValue_Exception()
        {
            //arrange
            BusinessLogic bl = new BusinessLogic();
            string number = "-12p48";
            string point = "point";
            string minus = "minus";

            //act
            string words = bl.GetWords(number, point, minus);
        }
    }
}
