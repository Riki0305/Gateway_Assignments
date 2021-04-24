using NUnit.Framework;
using NUnitAssignment8;

namespace TestProject
{
    public class Tests
    {
        private Program obj;

        [SetUp]
        public void Setup()
        {
            obj = new Program();
        }

        [Test]
        public void TestGetUserInfo_For_Age_GreaterThan_30()
        {
            //Act
            var result = obj.GetUserInfo();
            Assert.That(result, Has
                .Count.EqualTo(4)
                .And.Exactly(2).Property("Age").GreaterThan(30)
                );
        }
        [Test]
        public void TestGetUserInfo_For_Age_LessThan_30()
        {
            //Act
            var resultCollection = obj.GetUserInfo();
            Assert.That(resultCollection, Has
                .Count.EqualTo(4)
                .And.Exactly(1).Property("Age").LessThan(30)
                );
        }

        [Test]
        public void TestGetUserInfo_For_Age_GreaterThan_30_And_City_Yuganda()
        {
            //Act
            var resultCollection = obj.GetUserInfo();
            Assert.That(resultCollection, Has
                .Count.EqualTo(4)
                .And.Exactly(2).Property("Age").GreaterThan(30)
                .And.Exactly(1).Property("Address").EqualTo("Yuganda")
                );
        }

        [Test]
        public void TestGetUserInfo_For_Name_And_Address()
        {
            //Act
            var resultCollection = obj.GetUserInfo();
            Assert.That(resultCollection, Has
                .Count.EqualTo(4)
                .And.Exactly(1).Property("Name").EqualTo("Sam")
                .And.Property("Address").EqualTo("Austrailia")
                );
        }

        [Test]
        public void TestGetUserInfo_For_Name_Age_And_Address()
        {
            //Act
            var resultCollection = obj.GetUserInfo();
            Assert.That(resultCollection, Has
                .Count.EqualTo(4)
                .And.Exactly(1).Property("Name").EqualTo("Bucky")
                .And.Property("Address").EqualTo("London")
                .And.Property("Age").EqualTo(119)
                );
        }
    }
}