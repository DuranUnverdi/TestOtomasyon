using NUnit.Framework;
using System;

namespace SeleniumLearning
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("Setup method execution");
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("This is test 1");
        }
        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("This is test 2");
        }
        [TearDown]
        public void CloseBrowser()
        {
            TestContext.Progress.WriteLine("Tear Down Method");
        }
    }
}