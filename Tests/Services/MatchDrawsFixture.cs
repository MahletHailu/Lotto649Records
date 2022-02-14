using BusinessLogic.Services;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Services
{
    public class MatchDrawsFixture
    {
        [Test]
        public void CanCreateInstance()
        {
            var sut = new MatchedDraw();

            sut.Should().NotBeNull();
        }

        [Test]
        public void SettingDrawNumberChangesDrawNumber()
        {
            var drawNumber = 1245;

            var sut = new MatchedDraw
            {
                DrawNumber = drawNumber
            };

            sut.DrawNumber.Should().Be(drawNumber);
        }

        [Test]
        public void SettingDrawDateChangesDrawDate()
        {
            var drawDate = new DateTime();

            var sut = new MatchedDraw
            {
                DrawDate = drawDate
            };

            sut.DrawDate.Should().Be(drawDate);
        }

        [Test]
        public void SettingMatchChangesMatch()
        {
            var matchCount = 3;

            var sut = new MatchedDraw
            {
                matchCount = matchCount
            };

            sut.matchCount.Should().Be(matchCount);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void WonShoulBeCorrect(int matchCount)
        {
            var won = matchCount switch
            {
                4 => 85,
                5 => 3000,
                6 => 5000000,
                _ => 0
            };


            var sut = new MatchedDraw
            {
                DrawNumber = 1,
                DrawDate = new DateTime(),
                matchCount = matchCount
            };


            sut.Won.Should().Be(won);
        }
    }
}
