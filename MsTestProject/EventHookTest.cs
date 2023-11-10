using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsTestProject
{
    [TestClass]
    public class EventHookTest
    {
        private static int counter = 0;

        // 執行該類別中第一項測試前，使用 ClassInitialize 執行程式碼
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            Console.WriteLine("ClassInitialize: " + counter);
            counter++;
        }

        // 在類別中的所有測試執行後，使用 ClassCleanup 執行程式碼
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            Console.WriteLine("ClassCleanup: " + counter);
            counter = 0;
        }

        // 在執行每一項測試之前，先使用 TestInitialize 執行程式碼
        [TestInitialize()]
        public void MyTestInitialize()
        {
            Console.WriteLine("TestInitialize: " + counter);
            counter++;
        }

        // 在執行每一項測試之後，使用 TestCleanup 執行程式碼
        [TestCleanup()]
        public void MyTestCleanup()
        {
            Console.WriteLine("TestCleanup: " + counter);
            counter++;
        }

        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("TestMethod1: " + counter);
            counter++;
        }

        [TestMethod]
        public void TestMethod2()
        {
            Console.WriteLine("TestMethod2: " + counter);
            counter++;
        }
    }
}