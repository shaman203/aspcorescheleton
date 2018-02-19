using AutoFixture.Xunit2;
using FluentAssertions;
using System;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        public void MyFirstTheory(int value)
        {
            //Assert.True(IsOdd(value));
            IsOdd(value).Should().BeTrue(because: " even numbers are boring");
        }

        bool IsOdd(int value)
        {
            return value % 2 == 1;
        }

        

        [Theory, AutoData]
        public void IntroductoryTest(int expectedNumber, MyClass sut)
        {
            int result = sut.Echo(expectedNumber);
            Assert.Equal(expectedNumber, result);
        }
    }

    public class MyClass
    {
        internal int Echo(int number)
        {
            return number;
        }
    }
}
