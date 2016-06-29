using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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

        public TimeSpan? Parse(string input)
        {
            var regex = new Regex(@"(\d+ (?:weeks?|days?|hours?|minutes?|seconds?|milliseconds?|millis?))");
            var matchCollection = regex.Matches(input);
            
            if (matchCollection.Count > 0)
            {
                var result = TimeSpan.Zero;
                
                for (int i = 0; i < matchCollection.Count; i++)
                {
                    var match = matchCollection[i];
                    var timeSpan = _singleTermParser.Parse(match.Groups[0].Value);
                    result = result.Add(timeSpan);
                }
                return result;
            }

            return null;
        }
    }
}
