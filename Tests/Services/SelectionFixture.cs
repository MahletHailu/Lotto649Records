using BusinessLogic.Models.Services;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Tests.Services
{
    public class SelectionFixture
    {
        [Test]
        public void CanCreateInstance()
        {
            var sut = new Selection();

            sut.Should().NotBeNull();
        }

        [Test]
        public void SettingNumberDrawn1ChangesNumberDrawn1()
        {
            var numberDrawn1 = 15;

            var sut = new Selection
            {
                Number1 = numberDrawn1
            };

            sut.Number1.Should().Be(numberDrawn1);
        }

        [Test]
        public void SettingNumberDrawn2ChangesNumberDrawn2()
        {
            var numberDrawn2 = 1;

            var sut = new Selection
            {
                Number2 = numberDrawn2
            };

            sut.Number2.Should().Be(numberDrawn2);
        }

        [Test]
        public void SettingNumberDrawn3ChangesNumberDrawn3()
        {
            var numberDrawn3 = 3;

            var sut = new Selection
            {
                Number3 = numberDrawn3
            };

            sut.Number3.Should().Be(numberDrawn3);
        }

        [Test]
        public void SettingNumberDrawn4ChangesNumberDrawn4()
        {
            var numberDrawn4 = 4;

            var sut = new Selection
            {
                Number4 = numberDrawn4
            };

            sut.Number4.Should().Be(numberDrawn4);
        }

        [Test]
        public void SettingNumberDrawn5ChangesNumberDrawn5()
        {
            var numberDrawn5 = 5;

            var sut = new Selection
            {
                Number5 = numberDrawn5
            };

            sut.Number5.Should().Be(numberDrawn5);
        }

        /// <summary>
        /// Only number 1 - 49 allowed
        /// </summary>
        [TestCase(0)]
        [TestCase(50)]
        [TestCase(-1)]
        public void InvalidNumberShoulThrowAnError(int number)
        {
            Action sut = () => new Selection
            {
                Number1 = number
            };

            sut.Should()
              .Throw<ArgumentOutOfRangeException>();
        }
    }
}
