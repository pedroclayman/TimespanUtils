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
        private readonly Regex _timeSpanExpression = new Regex(@"(\d+ (?:weeks?|days?|hours?|minutes?|seconds?|milliseconds?|millis?))");

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
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            
            var matchCollection = _timeSpanExpression.Matches(input);
            
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

        public bool ContainsTimeSpanInfo(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            
            return _timeSpanExpression.IsMatch(input);
        }
    }
}
