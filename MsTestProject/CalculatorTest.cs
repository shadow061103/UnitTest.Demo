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
        public void Add_first_��J1_second��J2_���G����3()
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
        public void ����Exception_���~����()
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
        public void MixTest_first��J1_second��J2_third��J0_���ߥXArgumentException()
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
        /// �Φۭq�X�R��k����
        /// </summary>
        [TestMethod]
        [Owner("steve")]
        [TestCategory("Calculator")]
        [TestProperty("Calculator", "Mix")]
        [ExpectedException(typeof(ArgumentException))]
        public void MixTest_first��J1_second��J2_third��J0_����ArgumentException�T��()
        {
            //arrange
            var sut = new Calculator();
            int first = 1;
            int second = 2;
            int third = 0;
            string expectedMsg = "third���i���s";
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