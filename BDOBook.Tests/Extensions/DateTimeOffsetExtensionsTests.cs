using BDOBook.App.Extensions;
using System;
using Xunit;

namespace BDOBook.Tests.Extensions
{
    public class DateTimeOffsetExtensionsTests
    {
        [Theory]
        [InlineData("2021-09-01T00:00:00.0000000+00:00", "Wednesday, September 1, 2021 12:00 AM")]
        [InlineData("2021-09-01T12:00:00.0000000+00:00", "Wednesday, September 1, 2021 12:00 PM")]
        [InlineData("2021-09-01T23:59:59.0000000+00:00", "Wednesday, September 1, 2021 11:59 PM")]
        public void ToPrettyString_ShouldReturnCorrectString(string dateTimeOffsetString, string expected)
        {
            // Arrange
            var dateTimeOffset = DateTimeOffset.Parse(dateTimeOffsetString);

            // Act
            var actual = dateTimeOffset.ToPrettyString();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
