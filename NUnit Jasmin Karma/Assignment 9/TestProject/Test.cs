using Moq;
using NUnit.Framework;
using NUnitAssignment9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProject
{
    public class Test
    {
        private Product productRepo;

        [SetUp]
        public void Setup()
        {
            var productRepoMock = new Mock<Product>();

            productRepoMock.Setup(x => x.GetProducts())
                .Returns(new List<Product>()
                {
                    new Product
                    {
                        Id = 5,
                        Name = "Micromax 3100",
                        Quantity  = 30,
                        Price = 5000
                    }
                });
            productRepo = productRepoMock.Object;

        }
        /// <summary>
        /// Custom Constraint Test smaller number positive
        /// </summary>
        [Test]
        public void AlmostEqualToConstraint_Smaller_Number_Test_Positive()
        {
            int value = 93;
            Assert.That(95, Is.AlmostEqualTo(value, 5));
        }

        /// <summary>
        /// Custom Constraint Test bigger number positive
        /// </summary>
        [Test]
        public void AlmostEqualToConstraint_Bigger_Number_Test_Positive()
        {
            int value = 97;
            Assert.That(95, Is.AlmostEqualTo(value, 5));
        }

        /// <summary>
        /// Custom Constraint Test equal number positive
        /// </summary>
        [Test]
        public void AlmostEqualToConstraint_Equal_Number_Test()
        {
            int value = 95;
            Assert.That(95, Is.AlmostEqualTo(value, 5));
        }

        /// <summary>
        /// Custom Constraint Test smaller number negative
        /// </summary>
        [Test]
        public void AlmostEqualToConstraint_Smaller_Number_Test_Negative()
        {
            int value = 92;
            Assert.That(95, Is.AlmostEqualTo(value, 2));
        }

        /// <summary>
        /// Custom Constraint Test bigger number negative
        /// </summary>
        [Test]
        public void AlmostEqualToConstraint_Bigger_Number_Test_Negative()
        {
            int value = 98;
            Assert.That(95, Is.AlmostEqualTo(value, 2));
        }

        /// <summary>
        /// Mock Testing - Count Products - positive
        /// </summary>
        [Test]
        public void Mock_TestCase_Count_Products_Positive()
        {
            Assert.AreEqual(1, productRepo.GetProducts().Count());
        }

        /// <summary>
        /// Mock Testing - Count Products - Negative
        /// </summary>
        [Test]
        public void Mock_TestCase_Count_Products_Negative()
        {
            Assert.AreEqual(5, productRepo.GetProducts().Count());
        }

        /// <summary>
        /// Mock Testing - - Compare Name by id - Positive
        /// </summary>
        [Test]
        public void Mock_TestCase_CompareNameById_Positive()
        {
            Assert.AreEqual("Micromax 3100", productRepo.GetProducts().Where(x=>x.Id == 5).FirstOrDefault().Name);
        }

        /// <summary>
        /// Mock Testing - Compare Price by id - Positive
        /// </summary>
        [Test]
        public void Mock_TestCase_ComparePriceById_Positive()
        {
            Assert.AreEqual(5000, productRepo.GetProducts().Where(x => x.Id == 5).FirstOrDefault().Price);
        }

        /// <summary>
        /// Mock Testing - Compare Price by id - Negative
        /// </summary>
        [Test]
        public void Mock_TestCase_ComparePriceById_Negative()
        {
            Assert.AreEqual(6000, productRepo.GetProducts().Where(x => x.Id == 5).FirstOrDefault().Price);
        }

    }
}
