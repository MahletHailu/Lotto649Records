using BusinessLogic.Models;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Tests.ModelTests
{
    public class HistoricalDrawsFixture
    {
        [Test]
        public void CanCreateInstance()
        {
            var sut = new HistoricalDraws();

            sut.Should().NotBeNull();
        }

        [Test]
        public void SettingDrawNumberChangesDrawNumber()
        {
            var drawNumber = 12;

            var sut = new HistoricalDraws
            {
                DrawNumber = drawNumber
            };

            sut.DrawNumber.Should().Be(drawNumber);
        }

        [Test]
        public void SettingSequenceNumberChangesSequenceNumber()
        {
            var sequenceNumber = 15;

            var sut = new HistoricalDraws
            {
                SequenceNumber = sequenceNumber
            };

            sut.SequenceNumber.Should().Be(sequenceNumber);
        }

        [Test]
        public void SettingDrawDateChangesDrawDate()
        {
            var drawDate = new DateTime();

            var sut = new HistoricalDraws
            {
                DrawDate = drawDate
            };

            sut.DrawDate.Should().Be(drawDate);
        }

        [Test]
        public void SettingNumberDrawn1ChangesNumberDrawn1()
        {
            var numberDrawn1 = 15;

            var sut = new HistoricalDraws
            {
                NumberDrawn1 = numberDrawn1
            };

            sut.NumberDrawn1.Should().Be(numberDrawn1);
        }

        [Test]
        public void SettingNumberDrawn2ChangesNumberDrawn2()
        {
            var numberDrawn2 = 1;

            var sut = new HistoricalDraws
            {
                NumberDrawn2 = numberDrawn2
            };

            sut.NumberDrawn2.Should().Be(numberDrawn2);
        }

        [Test]
        public void SettingNumberDrawn3ChangesNumberDrawn3()
        {
            var numberDrawn3 = 3;

            var sut = new HistoricalDraws
            {
                NumberDrawn3 = numberDrawn3
            };

            sut.NumberDrawn3.Should().Be(numberDrawn3);
        }

        [Test]
        public void SettingNumberDrawn4ChangesNumberDrawn4()
        {
            var numberDrawn4 = 4;

            var sut = new HistoricalDraws
            {
                NumberDrawn4 = numberDrawn4
            };

            sut.NumberDrawn4.Should().Be(numberDrawn4);
        }

        [Test]
        public void SettingNumberDrawn5ChangesNumberDrawn5()
        {
            var numberDrawn5 = 5;

            var sut = new HistoricalDraws
            {
                NumberDrawn5 = numberDrawn5
            };

            sut.NumberDrawn5.Should().Be(numberDrawn5);
        }
    }
}
