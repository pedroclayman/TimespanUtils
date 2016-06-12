using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimespanUtils.Tests
{
    [TestClass]
    public class SingleTermParserTest
    {
        [TestMethod]
        public void ShouldParse()
        {
            var timeSpanParser = new SingleTermParser();
            Assert.AreEqual(TimeSpan.FromDays(6), timeSpanParser.Parse("6 days"));
            Assert.AreEqual(TimeSpan.FromDays(12), timeSpanParser.Parse("12 days"));
            Assert.AreEqual(TimeSpan.FromDays(1), timeSpanParser.Parse("1 day"));

            Assert.AreEqual(TimeSpan.FromDays(6 * 7), timeSpanParser.Parse("6 weeks"));
            Assert.AreEqual(TimeSpan.FromDays(12 * 7), timeSpanParser.Parse("12 weeks"));
            Assert.AreEqual(TimeSpan.FromDays(1 * 7), timeSpanParser.Parse("1 week"));

            Assert.AreEqual(TimeSpan.FromHours(6), timeSpanParser.Parse("6 hours"));
            Assert.AreEqual(TimeSpan.FromHours(12), timeSpanParser.Parse("12 hours"));
            Assert.AreEqual(TimeSpan.FromHours(1), timeSpanParser.Parse("1 hour"));

            Assert.AreEqual(TimeSpan.FromMinutes(6), timeSpanParser.Parse("6 minutes"));
            Assert.AreEqual(TimeSpan.FromMinutes(12), timeSpanParser.Parse("12 minutes"));
            Assert.AreEqual(TimeSpan.FromMinutes(1), timeSpanParser.Parse("1 minute"));

            Assert.AreEqual(TimeSpan.FromSeconds(6), timeSpanParser.Parse("6 seconds"));
            Assert.AreEqual(TimeSpan.FromSeconds(12), timeSpanParser.Parse("12 seconds"));
            Assert.AreEqual(TimeSpan.FromSeconds(1), timeSpanParser.Parse("1 second"));

            Assert.AreEqual(TimeSpan.FromMilliseconds(6), timeSpanParser.Parse("6 milliseconds"));
            Assert.AreEqual(TimeSpan.FromMilliseconds(12), timeSpanParser.Parse("12 milliseconds"));
            Assert.AreEqual(TimeSpan.FromMilliseconds(1), timeSpanParser.Parse("1 millisecond"));

            Assert.AreEqual(TimeSpan.FromMilliseconds(6), timeSpanParser.Parse("6 millis"));
            Assert.AreEqual(TimeSpan.FromMilliseconds(12), timeSpanParser.Parse("12 millis"));
            Assert.AreEqual(TimeSpan.FromMilliseconds(1), timeSpanParser.Parse("1 milli"));
            
        }
    }
}
