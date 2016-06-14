using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TimespanUtils
{
    class SingleTermParser : ISingleTermParser
    {
        private readonly IList<TermTuple> _tuples = new List<TermTuple>()
        {
            new TermTuple() { RegExp = "^weeks?$", TimeSpanFunc = (int i) => TimeSpan.FromDays(i * 7) },
            new TermTuple() { RegExp = "^days?$", TimeSpanFunc = (int i) => TimeSpan.FromDays(i) },
            new TermTuple() { RegExp = "^hours?$", TimeSpanFunc = (int i) => TimeSpan.FromHours(i) },
            new TermTuple() { RegExp = "^minutes?$", TimeSpanFunc = (int i) => TimeSpan.FromMinutes(i) },
            new TermTuple() { RegExp = "^seconds?$", TimeSpanFunc = (int i) => TimeSpan.FromSeconds(i) },
            new TermTuple() { RegExp = "^milliseconds?$", TimeSpanFunc = (int i) => TimeSpan.FromMilliseconds(i) },
            new TermTuple() { RegExp = "^millis?$", TimeSpanFunc = (int i) => TimeSpan.FromMilliseconds(i) },
        };

        public TimeSpan Parse(string input)
        {
            var split = input.Split(' ');

            var termTuple = _tuples.FirstOrDefault(t => Regex.IsMatch(split[1], t.RegExp));

            if (termTuple != null)
                return termTuple.TimeSpanFunc(int.Parse(split[0]));

            throw new Exception();
        }

        private class TermTuple
        {
            public string RegExp { get; set; }
            public Func<int, TimeSpan> TimeSpanFunc { get; set; }
        }
    }
}
