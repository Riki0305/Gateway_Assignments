using NUnit.Framework;
using Operations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Operations_Testing
{
    [TestFixture]
    public class Operations_Tests
    {
        private Operation _operations;
        private static object[] oddNumbersLists =
        {
            new object[] {new List<int> {1}},
            new object[] {new List<int> {1,3,5}},
        };

        [SetUp]
        public void Setup()
        {
            _operations = new Operation();
        }

        /// <summary>
        /// While loop testing
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expected"></param>
        [TestCase(-1, 9)]
        [TestCase(0, 10)]
        [TestCase(1, 11)]
        public void Add10_Test(int value, int expected)
        {
            // Act
            var result = _operations.Add10ToNumber(value);

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Testing of switch case
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expected"></param>
        [TestCase("red", 1)]
        [TestCase("blue", 2)]
        [TestCase("green", 3)]
        [TestCase("", -1)]
        public void GetGenderCode_Test(string value, int expected)
        {
            // Act
            var result = _operations.GetColorCode(value);

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Testing of if-else
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expected"></param>
        [TestCase(2, true)]
        [TestCase(1, false)]
        [TestCase(0, true)]
        public void IsEven_Test(int value, bool expected)
        {
            // Act
            var result = _operations.IsEven(value);

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Testing of for-each
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        [TestCaseSource(typeof(OddNumberListClass), nameof(OddNumberListClass.TestCases))]
        public int FindOddNumbers_Test(List<int> values)
        {
            // Act
            var result = _operations.FindOddNumbers(values);

            // Assert
            return result;
        }

        /// <summary>
        ///  Testing of for loop
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expected"></param>
        [TestCase(20, 10)]
        [TestCase(11, 1)]
        public void Subtract10_Test(int value, int expected)
        {
            // Act
            var result = _operations.Subtract10(value);

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Testing of exception handling
        /// </summary>
        [Test]
        public void GetGender_Test()
        {
            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => _operations.GetColorCode(null));
        }

        /// <summary>
        /// Testing of exception handling
        /// </summary>
        [Test]
        public void Divide_Test()
        {
            // Act, Assert
            Assert.Throws<InvalidOperationException>(() => _operations.Divide(5, 0));
        }

        /// <summary>
        /// Testing of exception handling
        /// </summary>
        [Test]
        public void NotImplemented_Test()
        {
            // Act, Assert
            Assert.Throws<NotImplementedException>(() => _operations.NotImplemented());
        }

        /// <summary>
        /// Testing of exception handling
        /// </summary>
        [Test]
        public void ValidateName_Test1()
        {
            // Act, Assert
            Assert.Throws<InvalidNameException>(() => _operations.ValidateName("Reserved_Word"));
        }

        /// <summary>
        /// Testing of exception handling
        /// </summary>
        [Test]
        public void ValidateName_Test2()
        {
            // Act, Assert
            Assert.Throws<FormatException>(() => _operations.ValidateName(null));
        }



    }
}

public class OddNumberListClass
{
    public static IEnumerable TestCases
    {
        get
        {
            yield return new TestCaseData(new List<int> { 1 }).Returns(1);
            yield return new TestCaseData(new List<int> { 1, 3, 5 }).Returns(3);
        }
    }
}