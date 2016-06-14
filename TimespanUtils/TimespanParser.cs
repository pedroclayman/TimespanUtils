using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimespanUtils
{
    public class TimeSpanParser
    {
        private readonly ISingleTermParser _singleTermParser;

        internal TimeSpanParser(ISingleTermParser singleTermParser)
        {
            if (singleTermParser == null)
                throw new ArgumentNullException(nameof(singleTermParser));

            _singleTermParser = singleTermParser;
        }

        public TimeSpanParser() : this(new SingleTermParser())
        { }

        public TimeSpan Parse(string input)
        {
            return new SingleTermParser().Parse(input);
        }
    }
}
