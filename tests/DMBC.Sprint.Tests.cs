using NUnit.Framework;
using DMBC;
using System;


// tests for DMBC sprint calculator
// originally written in .net 6
// the function may be converted to a datetime extension
namespace SprintCalculator.Tests
{
    [TestFixture]
    public class SprintTests
    {
        [Test]
        [Sequential]
        public void Calculate_MajorPart_ExpectedBehavior(
            [Values(11, 10, 17, 18, 19, 20, 21, 22, 23, 30)] int day)
        {
            var testDate = new DateTime(2022, 10, day);

            var expected = 123;

            // Arrange
            var sut = new Sprint();

            // Act
            var result = sut.Major(testDate);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [Sequential]
        public void Calculate_MajorPartPre_120_ExpectedBehavior(
            [Values(25, 28, 23)] int day)
        {
            var testDate = new DateTime(2022, 7, day);

            var expected = 119;

            // Arrange
            var sut = new Sprint();

            // Act
            var actual = sut.Major(testDate);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void MinorPart_BaseDate_ExpectedBehavior()
        {
            // Arrange
            var sprint = new Sprint();
            DateTime datetime = new DateTime(2022, 08, 8);

            var expected = 1;

            // Act
            var actual = sprint.Minor(datetime);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Sequential]
        public void MinorPart_StateUnderTest_ExpectedBehavior_1(
            [Values(16, 10, 11, 12, 13, 14, 15)] int day)
        {
            // Arrange
            var sprint = new Sprint();
            DateTime datetime = new DateTime(2022, 10, day);

            var expected = 1;

            // Act
            var actual = sprint.Minor(datetime);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Sequential]
        public void MinorPart_StateUnderTest_ExpectedBehavior_2(
            [Values(17, 18, 19, 20, 21, 22, 23)] int day)
        {
            // Arrange
            var sprint = new Sprint();
            DateTime datetime = new DateTime(2022, 10, day);

            var expected = 2;

            // Act
            var actual = sprint.Minor(datetime);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Sequential]
        public void MinorPart_StateUnderTest_ExpectedBehavior_3(
            [Values(24, 25, 26, 27, 28, 29, 30)] int day)
        {
            // Arrange
            var sprint = new Sprint();
            DateTime datetime = new DateTime(2022, 10, day);

            var expected = 3;

            // Act
            var actual = sprint.Minor(datetime);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Sequential]
        public void MinorPart_StateUnderTest_ExpectedBehavior_Before_1(
            [Values(7, 6, 8, 9, 10, 11, 12)] int day)
        {
            // Arrange
            // Sprint 117.1
            var sprint = new Sprint();
            DateTime datetime = new DateTime(2022, 6, day);

            var expected = 1;

            // Act
            var actual = sprint.Minor(datetime);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Sequential]
        public void MinorPart_StateUnderTest_ExpectedBehavior_Before_2(
            [Values(9, 4, 5, 6, 7, 8, 10)] int day)
        {
            // Arrange
            // sprint 118.2
            var sprint = new Sprint();
            DateTime datetime = new DateTime(2022, 7, day);

            var expected = 2;

            // Act
            var actual = sprint.Minor(datetime);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Sequential]
        public void MinorPart_StateUnderTest_ExpectedBehavior_Before_3(
            [Values(1, 2, 3, 4, 5, 6, 7)] int day)
        {
            // Arrange
            // Sprint 119.3
            var sprint = new Sprint();
            DateTime datetime = new DateTime(2022, 8, day);

            var expected = 3;

            // Act
            var actual = sprint.Minor(datetime);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Sequential]
        public void Sprint_StateUnderTest_ExpectedBehavior(
            [Values(6, 6, 6, 8, 8, 10, 10)] int month,
            [Values(12, 19, 20, 8, 10, 6, 17)] int day,
            [Values("117.1.0.0", "117.2.0.0", "117.3.0.0", "120.1.0.0", "120.1.0.0", "122.3.0.0", "123.2.0.0")] string expected)
        {
            // Arrange

            var sprint = new Sprint();
            DateTime datetime = new DateTime(2022, month, day);

            // Act
            var actual = sprint.SprintNumber(datetime);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Extreme_expectedBehaviour_Min()
        {
            // Arrange

            var sprint = new Sprint();
            DateTime datetime = new DateTime(2021, 6, 14);

            // Act
            var actual = sprint.SprintNumber(datetime);

            // Assert
            Assert.That(actual, Is.Not.Null);
        }
    }
}