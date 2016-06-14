using System;

namespace TimespanUtils
{
    internal interface ISingleTermParser
    {
        TimeSpan Parse(string input);
    }
}