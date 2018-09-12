using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank
{
    public class TheTimeInTheWords
    {
        public string timeInWords(int h, int m)
        {
            var result = new Dictionary<TimePosition,string>();

            var rules = new List<IRule>()
            {
                new MinuteConvert(result, m),
                new MinutesPostfixRule(result,m),
                new PastToRule(result, m),
                new HourConvert(result, h, m),
                new HourPostfixConvert(result, m),
            };

            foreach (var rule in rules)
            {
                rule.Apply();
            }

            return string.Join(" ", result.Select(x => x.Value).ToList());
        }
    }

    public enum TimePosition {
        Minutes,
        MinutesPostfix,
        ToPast,
        Hour,
        HourPostfix
    }


    public static class StringBuilderExtensions
    {
        private const string Formatter = " {0}";

        public static void AppendSpaceFormat(this StringBuilder builder, string toAdd)
        {
            builder.AppendFormat(Formatter, toAdd);
        }
    }

    public static class NumberConvertorHelper
    {
        public static Dictionary<int, string> SecondDigitToWords = new Dictionary<int, string>()
        {
            {0, ""},
            {1, "one"},
            {2, "two"},
            {3, "three"},
            {4, "four"},
            {5, "five"},
            {6, "six"},
            {7, "seven"},
            {8, "eight"},
            {9, "nine"},
        };

        public static Dictionary<int, string> TenToTwentyDigitToWords = new Dictionary<int, string>()
        {
            {10, "ten"},
            {11, "eleven"},
            {12, "twelve"},
            {13, "thirteen"},
            {14, "fourteen"},
            {16, "sixteen"},
            {17, "seventeen"},
            {18, "eighteen"},
            {19, "nineteen"}
        };

        public static Dictionary<int, string> FirstDigitToWords = new Dictionary<int, string>()
        {
            {2, "twenty"}
        };

        public static string ConvertNumber(int input)
        {
            var str = "";
            if (!SecondDigitToWords.TryGetValue(input, out str))
            {
                if (!TenToTwentyDigitToWords.TryGetValue(input, out str))
                {
                    var greater = FirstDigitToWords[input / 10];
                    var smaller = SecondDigitToWords[input % 10];
                    str = greater + " " + smaller;
                }
            }

            return str;
        }

    }
    public interface IRule
    {
        void Apply();
    }


    public class MinutesPostfixRule : IRule
    {
        private const string Quarter = "quarter";
        private const string Half = "half";


        private Dictionary<TimePosition, string> _builder;
        private int _minute;

        public MinutesPostfixRule(Dictionary<TimePosition, string> builder, int minute)
        {
            _builder = builder;
            _minute = minute;
        }

        public void Apply()
        {
            if (_minute == 0)
                return;

            if (_minute == 1)
            {
                _builder[TimePosition.MinutesPostfix] = "minute";
            }

            else if (_minute % 30 == 0)
            {
                _builder[TimePosition.MinutesPostfix] = Half;
            }
            else if (_minute % 15 == 0)
            {
                _builder[TimePosition.MinutesPostfix] = Quarter;
            }
            else
            {
                _builder[TimePosition.MinutesPostfix] = "minutes";
            }
        }
    }
    public class PastToRule : IRule
    {
        private readonly Dictionary<TimePosition, string> _builder;
        private readonly int _minute;
        private const string Past = "past";
        private const string To = "to";

        public PastToRule(Dictionary<TimePosition, string> builder,  int minute)
        {
            _builder = builder;
            _minute = minute;
        }
        public void Apply()
        {
            if (_minute > 0)
            {
                if (_minute > 30)
                {
                    _builder[TimePosition.ToPast] = To;
                }
                else
                {
                    _builder[TimePosition.ToPast] = Past;
                }
            }
        }
    }

    public class MinuteConvert : IRule
    {
        private Dictionary<TimePosition, string> _builder;
        private int _minute;

        public MinuteConvert(Dictionary<TimePosition, string> builder, int minute)
        {
            _builder = builder;
            _minute = minute;
        }
        public void Apply()
        {
            if (_minute % 15 != 0)
            {
                var result = "";
                if (_minute < 30)
                {
                    result = NumberConvertorHelper.ConvertNumber(_minute);
                }
                else
                {
                    result = NumberConvertorHelper.ConvertNumber(60 - _minute);
                }

                _builder[TimePosition.Minutes] = result;
            }
        }
    }

    public class HourConvert : IRule
    {
        private Dictionary<TimePosition, string> _builder;
        private int _minute;
        private int _hour;

        public HourConvert(Dictionary<TimePosition, string> builder, int hour, int minute)
        {
            _builder = builder;
            _minute = minute;
            _hour = hour;
        }
        public void Apply()
        {
            _builder[TimePosition.Hour] = _minute > 30
                ? NumberConvertorHelper.ConvertNumber(_hour + 1)
                : NumberConvertorHelper.ConvertNumber(_hour);
        }
    }

    public class HourPostfixConvert : IRule
    {
        private Dictionary<TimePosition, string> _builder;
        private int _minute;
        private const string OClock = "o' clock";
        public HourPostfixConvert(Dictionary<TimePosition, string> builder, int minute)
        {
            _builder = builder;
            _minute = minute;
        }

        public void Apply()
        {
            if (_minute == 0)
            {
                _builder[TimePosition.HourPostfix] = OClock;
            }
        }
    }
}
