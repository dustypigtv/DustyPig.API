using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace System
{
    public static class StringUtils
    {
        private static readonly List<string> RemovePrefixes = new List<string> { "the", "a", "an", "la", "les", "des", "l", "un", "el", "il", "le", "uno", };


        /// <summary>
        /// Converts a string to a list, splitting on null characters (\0)
        /// </summary>
        public static List<string> ConvertToList(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return new List<string>();
            return str.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        /// <summary>
        /// Converts a list of strings to a single null separated string
        /// </summary>
        public static string ConvertToString(List<string> lst)
        {
            if (lst == null || lst.Count == 0)
                return null;
            return string.Join("\0", lst);
        }


        /// <summary>
        /// Converts a list of strings to a single null separated string
        /// </summary>
        public static string ConvertToString(List<string> lst, int maxLen)
        {
            if (lst == null || lst.Count == 0)
                return null;

            string ret = string.Empty;
            for (int i = 0; i < lst.Count; i++)
            {
                int newLen = lst[i].Length;
                if (ret.Length > 0)
                    newLen++;

                if (ret.Length + newLen > maxLen)
                    return ret;

                if (ret.Length > 0)
                    ret += '\0';
                ret += lst[i];
            }

            return ret;
        }


        public static string Coalesce(params string[] values)
        {
            foreach (var value in values)
                if (!string.IsNullOrWhiteSpace(value))
                    return value;
            return null;
        }

        public static string SortTitle(string title)
        {
            title = (title + string.Empty).NormalizeMiscCharacters().Trim().ToLower();
            title = Regex.Replace(title, "[^a-z0-9 ]", " ").FixSpaces();
            var parts = title.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 1)
                if (RemovePrefixes.ICContains(parts[0]))
                    title = string.Join(" ", parts.Skip(1));

            return title.FixSpaces().ToLower();
        }

        public static void SortBySortTitle(List<string> lst)
        {
            lst.Sort((x, y) => x.SortTitle().CompareTo(y.SortTitle()));
        }

        public static bool ICEquals(string original, string compare)
        {
            if (original == null && compare == null)
                return true;

            if (original == null || compare == null)
                return false;

            return original.NormalizeMiscCharacters().Equals(compare.NormalizeMiscCharacters(), StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool ICStartsWith(string str, string text)
        {
            if (str == null && text == null)
                return true;

            if (str == null || text == null)
                return false;

            return str.NormalizeMiscCharacters().StartsWith(text.NormalizeMiscCharacters(), StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool ICEndsWith(string str, string text)
        {
            if (str == null && text == null)
                return true;

            if (str == null || text == null)
                return false;

            return str.NormalizeMiscCharacters().EndsWith(text.NormalizeMiscCharacters(), StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool ICContains(string str, string text)
        {
            if (str == null && text == null)
                return true;

            if (str == null || text == null)
                return false;

            return str.NormalizeMiscCharacters().ToLower().Contains(text.NormalizeMiscCharacters().ToLower());
        }

        public static bool ICContains(IEnumerable<string> lst, string text)
        {
            if (lst == null)
                return false;

            return lst.Any(item => item.ICEquals(text));
        }

        public static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;
            string normal = text.Normalize(NormalizationForm.FormD);
            var withoutDiacritics = normal.Where(
                c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);
            return new string(withoutDiacritics.ToArray());
        }

        public static string NormalizeMiscCharacters(string str)
        {
            str = (str + string.Empty).Trim();

            return str

                //The original annoyances
                .Replace("â€˜", "\"")
                .Replace("â€™", "'")
                .Replace("â€¦", "!")
                .Replace("â€œ", "\"")
                .Replace("â€", "\"")
                .Replace("â€“", "-")

                ////Latin diacritics (https://jkorpela.fi/latin1/3.3.html)
                
                .Replace("¨", "\"")
                .Replace("´", "'")
                .Replace("`", "'")
                .Replace("¸", ",")



                //Handle other diacritics
                .RemoveDiacritics()

                //Handle wierd versions of common chars
                .Replace("‘", "'")
                .Replace("’", "'")
                .Replace("–", "-")
                .Replace("·", "-")
                .Replace("…", "...")


                //Other misc fixes
                .Replace("\0", "")
                .Trim();
        }

        public static string NormalizeText(string str)
        {
            str = (str + string.Empty).Trim();

            return str
                .NormalizeMiscCharacters()

               //Other misc fixes
               .Replace("  ", " ")
               .Replace("\"\"", "\"")
               .Trim();
        }

        public static string NormalizedQueryString(string str)
        {
            str = NormalizeText(str);
            str = str.Replace("-", " ").Replace("/", " ");
            var tokens = Tokenize(str);

            for (int i = 0; i < tokens.Count; i++)
                if (long.TryParse(tokens[i], out long value))
                    tokens[i] = NumberToWords(value);

            return string.Join(" ", tokens).Trim();
        }

        public static List<string> Tokenize(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return new List<string>();

            str = str.ToLower().Trim();

            //Contractions and possessives are stored without an apostrophe in both databases
            str = str.Replace("'", "");

            //FOr things like Law & Order
            str = str.Replace(" & ", " and ");

            //Replace remaining special characters with a space
            str = Regex.Replace(str, "[^\\w ]", " ");

            //Split on spaces
            var ret = new List<string>(str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            return ret;
        }

        public static string NumberToWords(long number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";


            if ((number / 1000000000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " trillion ";
                number %= 1000000000000;
            }

            if ((number / 1000000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " billion ";
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        public static string FixSpaces(string text)
        {
            text += string.Empty;
            while (text.Contains("  "))
            {
                text = text.Replace("  ", " ");
            }
            return text.Trim();
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None);

                // Examines the domain part of the email and normalizes it.
                static string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }

                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        public static string GetInitials(string name)
        {
            name = (name + string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(name))
                return null;

            var parts = name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var ret = parts.First().ToUpperInvariant();
            if (parts.Length > 1)
                ret += parts.Last().ToUpperInvariant();
            return ret;
        }
    }
}
