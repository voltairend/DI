using System.IO;
using System;

namespace DITestProject
{
    [TestClass]
    public class UnitTest1
    {
        private const string Expected = "Hello World";

        [TestMethod]
        public void TestMethod1()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                NumCalculation.SampleMethodCons.HelloWorld();
               
                var result = sw.ToString().Trim();
                Assert.AreEqual(Expected, result);

            }
        }
    }
}