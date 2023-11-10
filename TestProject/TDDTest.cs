using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Demo;
using Xunit;

namespace TestProject
{
    public class TDDTest
    {
        [Fact]
        public void Test_Add_FirstNumber為1_SecondNumber為2_計算結果應為3()
        {
            // Scenario: 第一個數字為1，第二個數字為2，呼叫使用 Calculator 的 Add 方法，傳入兩個數字，
            //           應回傳兩數相加結果 3.
            // Given: 第一個數字為 1
            // And: 第二個數字為 2
            // When: 呼叫使用 Calculator 的 Add 方法，並傳入兩個數字
            // Then: 應回傳計算結果 3

            Assert.Fail("fail");
        }

        [Fact]
        public void Test_Add_FirstNumber為1_SecondNumber為2_計算結果應為3_Complete()
        {
            // arrange
            var firstNumber = 1;
            var secondNumber = 2;
            var expected = 3;

            Calculator sut = new Calculator();

            // act
            var actual = sut.Add(firstNumber, secondNumber);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_Minus_FirstNumber為3_SecondNumber為2_計算結果應為1()
        {
            // Scenario: 第一個數字為3，第二個數字為2，呼叫使用 Calculator 的 Minus 方法，傳入兩個數字，
            //           應回傳兩數相減結果 1.
            // Given: 第一個數字為 3
            // And: 第二個數字為 2
            // When: 呼叫使用 Calculator 的 Minus 方法，並傳入兩個數字
            // Then: 應回傳計算結果 1

            Assert.Fail("fail");
        }

        [Fact]
        public void Test_Minus_FirstNumber為3_SecondNumber為2_計算結果應為1_Complete()
        {
            // arrange
            var firstNumber = 3;
            var secondNumber = 2;
            var expected = 1;

            var sut = new Calculator();

            // act
            var actual = sut.Minus(firstNumber, secondNumber);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}