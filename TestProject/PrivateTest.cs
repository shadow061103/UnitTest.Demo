using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Demo;
using Xunit;

namespace TestProject
{
    public class PrivateTest
    {
        [Fact]
        public void Test_Internal_Method()
        {
            //arrange
            var sut = new Calculator();
            int first = 1;
            int second = 2;

            //act
            var act = sut.AddInternal(first, second);

            //assert
            Assert.Equal(first + second, act);
        }
    }
}