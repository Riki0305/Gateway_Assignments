using NUnit.Framework;
using NUnitAssignment8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TestProject
{
    public class OrderCount
    {
        public int order;
    }
    public class Tests
    {
        private Program obj;
        private OrderCount MyOrder = new OrderCount();

        [SetUp]
        public void Setup()
        {
            obj = new Program();
            MyOrder.order = 0;
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

        [TearDown]
        public void CleanUpAfterTest()
        {
            //REngineExecutionContext.ClearLog();
        }

        [OrderedTest(0)]
        public void Test1() 
        {
            Assert.AreEqual(MyOrder.order, 0);
        }

       

        [OrderedTest(1)]
        public void Test2()
        {
            MyOrder.order++;
            Assert.AreEqual(MyOrder.order, 1);
        }

        [OrderedTest(2)]
        public void Test3()
        {
            MyOrder.order++;
           
            Assert.AreEqual(MyOrder.order, 2);
        }

        [TestCaseSource(sourceName: "TestSource")]
        public void MyTest(TestStructure test)
        {
            test.Test();
        }

        public static IEnumerable<TestCaseData> TestSource
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                Dictionary<int, List<MethodInfo>> methods = assembly
                    .GetTypes()
                    .SelectMany(x => x.GetMethods())
                    .Where(y => y.GetCustomAttributes().OfType<OrderedTestAttribute>().Any())
                    .GroupBy(z => z.GetCustomAttribute<OrderedTestAttribute>().Order)
                    .ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());

                foreach (var order in methods.Keys.OrderBy(x => x))
                {
                    foreach (var methodInfo in methods[order])
                    {
                        MethodInfo info = methodInfo;
                        yield return new TestCaseData(
                            new TestStructure
                            {
                                Test = () =>
                                {
                                    object classInstance = Activator.CreateInstance(info.DeclaringType, null);
                                    info.Invoke(classInstance, null);
                                }
                            }).SetName(methodInfo.Name);
                    }
                }

            }
        }
    }
}