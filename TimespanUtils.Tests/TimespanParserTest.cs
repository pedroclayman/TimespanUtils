using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimespanUtils.Tests
{
    [TestClass]
    public class TimeSpanParserTest
    {
        [TestMethod]
        [Ignore]
        public void ShouldParseSingleItem()
        {
            var timeSpanParser = new TimeSpanParser();
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldFailWhenPassedNullToCtor()
        {
            new TimeSpanParser(null);
        }
    }
}
