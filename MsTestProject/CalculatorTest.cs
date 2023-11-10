using FluentAssertions;
using UnitTest.Demo;

namespace MsTestProject
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        [Owner("steve")]
        [TestCategory("Calculator")]
        [TestProperty("Calculator", "Add1")]
        public void Add_first_1_second_2_should_be_3()
        {
            //arrange
            var sut = new Calculator();
            int first = 1;
            int second = 2;

            //act
            var act = sut.Add(first, second);

            //assert
            Assert.AreEqual(first + second, act);
        }

        [TestMethod]
        [Owner("steve")]
        [TestCategory("Calculator")]
        [TestProperty("Calculator", "Add2")]
        public void Add_first_輸入1_second輸入2_結果應為3()
        {
            //arrange
            var sut = new Calculator();
            int first = 1;
            int second = 2;
            int expected = 3;

            //act
            var actual = sut.Add(first, second);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 驗證Exception_錯誤版本()
        {
            //arrange
            var expected = "Attempted to divide by zero.";
            //act
            var actual = "";
            try
            {
                var zero = 0;
                var result = 1 / zero;
            }
            catch (DivideByZeroException ex)
            {
                actual = ex.Message;
            }

            //assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Owner("steve")]
        [TestCategory("Calculator")]
        [TestProperty("Calculator", "Mix")]
        [ExpectedException(typeof(ArgumentException))]
        public void MixTest_first輸入1_second輸入2_third輸入0_應拋出ArgumentException()
        {
            //arrange
            var sut = new Calculator();
            int first = 1;
            int second = 2;
            int third = 0;
            int expected = 1;
            //act
            var actual = sut.Mix(first, second, third);
            //assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 用自訂擴充方法驗證
        /// </summary>
        [TestMethod]
        [Owner("steve")]
        [TestCategory("Calculator")]
        [TestProperty("Calculator", "Mix")]
        [ExpectedException(typeof(ArgumentException))]
        public void MixTest_first輸入1_second輸入2_third輸入0_驗證ArgumentException訊息()
        {
            //arrange
            var sut = new Calculator();
            int first = 1;
            int second = 2;
            int third = 0;
            string expectedMsg = "third不可為零";
            //act
            var actual = AssertExtensions.ThrowException<ArgumentException>(() => sut.Mix(first, second, third));
            //assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(ArgumentException));
            Assert.AreEqual(expectedMsg, actual.Message);
        }
    }

    public static class AssertExtensions
    {
        public static T ThrowException<T>(Action action) where T : Exception
        {
            try
            {
                action();
            }
            catch (T ex)
            {
                throw ex;
            }

            return null;
        }
    }
}