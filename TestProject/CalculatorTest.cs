using FluentAssertions;
using UnitTest.Demo;

namespace TestProject
{
    public class CalculatorTest
    {
        [Fact]
        [Trait("Category", "Add")]
        public void Add_first_1_second_2_should_be_3()
        {
            //arrange
            var sut = new Calculator();
            int first = 1;
            int second = 2;

            //act
            var act = sut.Add(first, second);

            //assert
            Assert.Equal(first + second, act);
        }

        [Fact]
        [Trait("Category", "Add")]
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
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", "Add")]
        public void MixTest_first��J1_second��J2_third��J0_���ߥXArgumentException_FluentAssertsion()
        {
            //arrange
            var sut = new Calculator();
            int first = 1;
            int second = 2;
            int third = 0;
            int expected = 1;

            //act
            Action act = () => sut.Mix(first, second, third);

            //assert

            act.Should().Throw<ArgumentException>().WithMessage("third���i���s");
        }

        [Fact]
        [Trait("Category", "Error")]
        public void MixTest_first��J1_second��J2_third��J0_���ߥXArgumentException_FluentAssertsion_V2()
        {
            var sut = new Calculator();
            int first = 1;
            int second = 2;
            int third = 0;
            int expected = 1;

            sut.Invoking(y => y.Mix(first, second, third))
                    .Should().Throw<ArgumentException>()
                    .WithMessage("third���i���s");
        }

        [Fact]
        public async Task MixAsync_first��J1_second��J2_third��J0_���ߥXArgumentException_FluentAssertsion()
        {
            //arrange
            var sut = new Calculator();
            int first = 1;
            int second = 2;
            int third = 0;

            //act
            Func<Task> action = async () => await sut.MixAsync(first, second, third);

            //assert
            await action.Should().ThrowAsync<ArgumentException>()
                 .Where(e => e.Message.Equals("third���i���s"));
        }

        /// <summary>
        /// �Φۭq�X�R��k����
        /// </summary>
        [Fact]
        [Trait("Category", "Error")]
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
            Assert.NotNull(actual);
            Assert.Equal(expectedMsg, actual.Message);
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
                return ex;
            }

            Assert.Fail($"Expected exception of type {typeof(T)}.");
            return null;
        }
    }
}