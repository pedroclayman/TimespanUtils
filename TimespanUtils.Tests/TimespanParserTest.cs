using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TimespanUtils.Tests
{
    [TestClass]
    public class TimeSpanParserTest
    {
        [TestMethod]
        public void ShouldCallSingleTermParserWithCorrectParams()
        {
            var mockOfISingleTermParser = new Mock<ISingleTermParser>();

            
            var timeSpanParser = new TimeSpanParser(mockOfISingleTermParser.Object);
            timeSpanParser.Parse("1 week 6 hours 3 minutes 11 seconds 136 millis");
            
            mockOfISingleTermParser.Verify(m => m.Parse("1 week"), Times.Once);
            mockOfISingleTermParser.Verify(m => m.Parse("6 hours"), Times.Once);
            mockOfISingleTermParser.Verify(m => m.Parse("3 minutes"), Times.Once);
            mockOfISingleTermParser.Verify(m => m.Parse("11 seconds"), Times.Once);
            mockOfISingleTermParser.Verify(m => m.Parse("136 millis"), Times.Once);
            mockOfISingleTermParser.ResetCalls();

            timeSpanParser.Parse("1 week 6 hours 3 minutes 11 seconds 136 milliseconds");
            
            mockOfISingleTermParser.Verify(m => m.Parse("1 week"), Times.Once);
            mockOfISingleTermParser.Verify(m => m.Parse("6 hours"), Times.Once);
            mockOfISingleTermParser.Verify(m => m.Parse("3 minutes"), Times.Once);
            mockOfISingleTermParser.Verify(m => m.Parse("11 seconds"), Times.Once);
            mockOfISingleTermParser.Verify(m => m.Parse("136 milliseconds"), Times.Once);
            mockOfISingleTermParser.ResetCalls();
        }

        [TestMethod]
        public void ShouldCallSingleTermParserWithCorrectParamsInNotPureString()
        {
            var mockOfISingleTermParser = new Mock<ISingleTermParser>();

            
            var timeSpanParser = new TimeSpanParser(mockOfISingleTermParser.Object);
            timeSpanParser.Parse("we still have 1 week 6 hours 3 minutes 11 seconds 136 millis to go");
            
            mockOfISingleTermParser.Verify(m => m.Parse("1 week"), Times.Once);
            mockOfISingleTermParser.Verify(m => m.Parse("6 hours"), Times.Once);
            mockOfISingleTermParser.Verify(m => m.Parse("3 minutes"), Times.Once);
            mockOfISingleTermParser.Verify(m => m.Parse("11 seconds"), Times.Once);
            mockOfISingleTermParser.Verify(m => m.Parse("136 millis"), Times.Once);
            
        }

        [TestMethod]
        public void ShouldReturnNullWhenStringDoesNotMatchAnything()
        {
            var mockOfISingleTermParser = new Mock<ISingleTermParser>();

            
            var timeSpanParser = new TimeSpanParser(mockOfISingleTermParser.Object);
            var result = timeSpanParser.Parse("this string contains no timespan info");
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldFailWhenPassedNullToParse()
        {
            var mockOfISingleTermParser = new Mock<ISingleTermParser>();

            
            var timeSpanParser = new TimeSpanParser(mockOfISingleTermParser.Object);
            timeSpanParser.Parse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldFailWhenPassedNullToContainsTimeSpanInfo()
        {
            var mockOfISingleTermParser = new Mock<ISingleTermParser>();

            
            var timeSpanParser = new TimeSpanParser(mockOfISingleTermParser.Object);
            timeSpanParser.ContainsTimeSpanInfo(null);
        }

        [TestMethod]
        public void ShouldProvideInfoIfStringContainsTimespanInfo()
        {
            var mockOfISingleTermParser = new Mock<ISingleTermParser>();

            
            var timeSpanParser = new TimeSpanParser(mockOfISingleTermParser.Object);

            var result = timeSpanParser.ContainsTimeSpanInfo("this string contains no timespan info");
            Assert.IsFalse(result);

            result = timeSpanParser.ContainsTimeSpanInfo("we still have 1 week 6 hours 3 minutes 11 seconds 136 millis to go");
            Assert.IsTrue(result);

            result = timeSpanParser.ContainsTimeSpanInfo("6 hours 3 minutes");
            Assert.IsTrue(result);

            result = timeSpanParser.ContainsTimeSpanInfo("1 hour");
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldFailWhenPassedNullToCtor()
        {
            new TimeSpanParser(null);
        }
    }
}
