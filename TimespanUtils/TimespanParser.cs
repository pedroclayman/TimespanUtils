using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimespanUtils
{
    public class TimeSpanParser
    {
        public TimeSpan Parse(string input)
        {
            return new SingleTermParser().Parse(input);
        }
    }
}
