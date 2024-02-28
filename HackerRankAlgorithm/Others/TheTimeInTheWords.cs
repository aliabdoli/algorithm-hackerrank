using System.Text;

namespace HackerRankAlgorithm.Others
{
    public class TheTimeInTheWords
    {
        public string timeInWords(int h, int m)
        {
            //todo: validations
            var mapper = new MapperManager(new NumberFormatter());
            var hour = h;
            var minute = m;
            

            var formattedDateTime = mapper.FormatDateTime(hour, minute);
            return formattedDateTime;
        }

    }

    public class NumberFormatter
    {

        private readonly Dictionary<int, string> OnesMappings = new Dictionary<int, string>()
        {
            { 0, string.Empty },
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "four" },
            { 5, "five" },
            { 6, "six" },
            { 7, "seven" },
            { 8, "eight" },
            { 9, "nine" },
            { 10, "ten" },

        };

        private readonly Dictionary<int, string> TeensMappings = new Dictionary<int, string>()
        {
            { 11, "eleven" },
            { 12, "twelve" },
            { 13, "thirteen" },
            { 14, "fourteen" },
            { 15, "quarter" },
            { 16, "sixteen" },
            { 17, "seventeen" },
            { 18, "eighteen" },
            { 19, "nineteen" },
        };

        private readonly Dictionary<int, string> TensMappings = new Dictionary<int, string>()
        {
            { 2, "twenty" },
            { 3, "half" },
            { 4, "forty" },
            { 5, "fifty" },
        };

        public string FindWord(int number)
        {
            if (number <= 10)
            {
                return OnesMappings[number];
            }
            if (number < 20)
            {
                return TeensMappings[number];
            }

            if (number < 60)
            {
                if (number % 10 == 0)
                {
                    return $"{TensMappings[number / 10]}";
                }
                return $"{TensMappings[number / 10]} {OnesMappings[number % 10]}";
            }

            throw new ArgumentException("number is more than 60");

        }
    }

    public class MapperManager
    {
        private readonly NumberFormatter _numberFormatter;

        private const string OClock = "o' clock";
        private const string Past = "past";
        private const string To = "to";
        private const string Minute = "minute";
        private const string Minutes = "minutes";

        public MapperManager(NumberFormatter numberFormatter)
        {
            _numberFormatter = numberFormatter;
        }

        public string FormatDateTime(int hour, int minute)
        {
            var result = "";
            if (minute == 0)
            {
                var hourWord = _numberFormatter.FindWord(hour);
                result = $"{hourWord} {OClock}";
            } 
            else if (minute <= 30)
            {
                var hourWord = _numberFormatter.FindWord(hour);
                var minuteWord = _numberFormatter.FindWord(minute);

                var pastToWord = Past; 

                result = FormatMinutes(minute, minuteWord, pastToWord, hourWord);
            }

            else if (minute > 30)
            {
                hour++;
                minute = 60 - minute;
                var pastToWord = To;
                var hourWord = _numberFormatter.FindWord(hour);
                var minuteWord = _numberFormatter.FindWord(minute);
                result = FormatMinutes(minute, minuteWord, pastToWord, hourWord);

            }
            return result;
        }

        private static string FormatMinutes(int minute, string minuteWord, string pastToWord, string hourWord)
        {
            string result;
            if (minute == 1)
            {
                result = $"{minuteWord} {Minute} {pastToWord} {hourWord}";
            }
            else if (minute == 30 | minute == 15)
            {
                result = $"{minuteWord} {pastToWord} {hourWord}";
            }

            else
            {
                result = $"{minuteWord} {Minutes} {pastToWord} {hourWord}";
            }

            return result;
        }

        
    }

}
