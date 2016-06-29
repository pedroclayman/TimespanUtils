# TimespanUtils [![NuGet version](https://badge.fury.io/nu/TimeSpanUtils.svg)](https://badge.fury.io/nu/TimeSpanUtils)
This project aims to provide some useful utilities when working with TimeSpans. Currently it provides a parser which parses TimeSpan informations from string formed like this: "6 hours", "3 weeks 5 minutes", etc.
## Usage
```cs
var parser = new TimeSpanParser();
var timespan = parser.Parse("6 hours"); // returns TimeSpan.FromHours(6);
timespan = parser.Parse("6 hours 30 minutes"); // returns TimeSpan.FromHours(6.5);
timespan = parser.Parse("we still have 6 hours 30 minutes to go"); // returns TimeSpan.FromHours(6.5);
timespan = parser.Parse("no timespan info here"); // returns null

// you can also check if a string contains any TimeSpan information
parser.ContainsTimeSpanInfo("6 hours 30 minutes") // true
parser.ContainsTimeSpanInfo("we still have 6 hours 30 minutes to go") // true
parser.ContainsTimeSpanInfo("nothing to see here") // false
```
## Installation
```
NuGet: Install-Package TimespanUtils
```